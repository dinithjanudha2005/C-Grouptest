using System;
using System.Data;
using System.Drawing;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;

namespace SarasaviLibrarySystem
{
    public partial class ReturnProcessingForm : Form
    {
        private readonly DbConnection _db = new DbConnection();
        private int _currentLoanId = 0;
        private string _currentBookNumber = "";

        public ReturnProcessingForm()
        {
            InitializeComponent();
        }

        // Form load
        private void ReturnProcessingForm_Load(object sender, EventArgs e)
        {
            LoadReturnedLoansGrid();
        }

        // Find active loan
        private void btnFindLoan_Click(object sender, EventArgs e)
        {
            string copyNumber = txtCopyNumber.Text.Trim().ToUpper();
            txtCopyNumber.Text = copyNumber;

            if (string.IsNullOrEmpty(copyNumber))
            {
                MessageBox.Show("Please enter Copy Number.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = @"SELECT 
                                l.LoanID, 
                                l.CopyNumber, 
                                b.BookNumber, 
                                b.Title, 
                                u.UserID, 
                                u.Name, 
                                l.LoanDate, 
                                l.ExpectedReturnDate 
                             FROM LOANS l
                             JOIN USERS u ON l.UserID = u.UserID
                             JOIN BOOKCOPIES c ON l.CopyNumber = c.CopyNumber
                             JOIN BOOKS b ON c.BookNumber = b.BookNumber
                             WHERE l.CopyNumber = @CopyNumber AND l.ActualReturnDate IS NULL";

            SqlParameter[] parameters = { new SqlParameter("@CopyNumber", copyNumber) };
            DataTable dt = _db.ExecuteQuery(query, parameters);

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("No active loan found for this copy number!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ResetDetails();
                return;
            }

            _currentLoanId = Convert.ToInt32(dt.Rows[0]["LoanID"]);
            _currentBookNumber = dt.Rows[0]["BookNumber"].ToString();

            lblBookTitle.Text = $"Book: {dt.Rows[0]["Title"]} ({_currentBookNumber})";
            lblBorrower.Text = $"Borrower: {dt.Rows[0]["Name"]} ({dt.Rows[0]["UserID"]})";

            DateTime loanDate = Convert.ToDateTime(dt.Rows[0]["LoanDate"]);
            DateTime dueDate = Convert.ToDateTime(dt.Rows[0]["ExpectedReturnDate"]);

            lblIssuedDate.Text = $"Issued Date: {loanDate:yyyy-MM-dd}";
            lblDueDate.Text = $"Due Date: {dueDate:yyyy-MM-dd}";

            // Check overdue
            if (DateTime.Now.Date > dueDate.Date)
            {
                int overdueDays = (DateTime.Now.Date - dueDate.Date).Days;
                lblOverdueStatus.Text = $"OVERDUE by {overdueDays} Days! (Late Return)";
                lblOverdueStatus.ForeColor = Color.FromArgb(239, 68, 68);
            }
            else
            {
                lblOverdueStatus.Text = "Status: Returned on time (No Overdue)";
                lblOverdueStatus.ForeColor = Color.FromArgb(16, 185, 129);
            }

            // Check reservations
            CheckReservationsForTitle(_currentBookNumber);

            btnAcceptReturn.Enabled = true;
        }

        // Check reservations
        private void CheckReservationsForTitle(string bookNumber)
        {
            string resQuery = @"SELECT TOP 1 
                                    r.ReservationID, 
                                    r.UserID, 
                                    u.Name, 
                                    r.ReservationDate 
                                FROM RESERVATIONS r
                                JOIN USERS u ON r.UserID = u.UserID
                                WHERE r.BookNumber = @BookNumber
                                ORDER BY r.ReservationDate ASC";

            SqlParameter[] resParams = { new SqlParameter("@BookNumber", bookNumber) };
            DataTable dtRes = _db.ExecuteQuery(resQuery, resParams);

            if (dtRes.Rows.Count > 0)
            {
                string resMember = dtRes.Rows[0]["Name"].ToString();
                string resUser = dtRes.Rows[0]["UserID"].ToString();
                DateTime resDate = Convert.ToDateTime(dtRes.Rows[0]["ReservationDate"]);

                lblAlertTitle.Text = "⚠️ RESERVATION QUEUE DETECTED!";
                lblAlertTitle.ForeColor = Color.FromArgb(245, 158, 11);
                lblAlertMsg.Text = $"This Title has an active reservation!\n\nMember: {resMember} ({resUser})\nReserved On: {resDate:yyyy-MM-dd}\n\nAction: Keep this copy aside and notify the member upon returning.";
                lblAlertMsg.ForeColor = Color.White;
            }
            else
            {
                lblAlertTitle.Text = "✓ No Pending Reservations";
                lblAlertTitle.ForeColor = Color.FromArgb(16, 185, 129);
                lblAlertMsg.Text = "No members are currently waiting for this Title. It will be marked Available in the library shelf.";
                lblAlertMsg.ForeColor = Color.FromArgb(148, 163, 184);
            }
        }

        // Accept return
        private void btnAcceptReturn_Click(object sender, EventArgs e)
        {
            string copyNumber = txtCopyNumber.Text.Trim();

            // 1. Update loan
            string updateLoanQuery = "UPDATE LOANS SET ActualReturnDate = GETDATE() WHERE LoanID = @LoanID";
            SqlParameter[] loanParams = { new SqlParameter("@LoanID", _currentLoanId) };
            _db.ExecuteNonQuery(updateLoanQuery, loanParams);

            // 2. Check oldest reservation to fulfill
            string resQuery = @"SELECT TOP 1 
                                    r.ReservationID, 
                                    u.Name, 
                                    r.UserID 
                                FROM RESERVATIONS r
                                JOIN USERS u ON r.UserID = u.UserID
                                WHERE r.BookNumber = @BookNumber
                                ORDER BY r.ReservationDate ASC";

            SqlParameter[] resParams = { new SqlParameter("@BookNumber", _currentBookNumber) };
            DataTable dtRes = _db.ExecuteQuery(resQuery, resParams);

            if (dtRes.Rows.Count > 0)
            {
                int resId = Convert.ToInt32(dtRes.Rows[0]["ReservationID"]);
                string memberName = dtRes.Rows[0]["Name"].ToString();
                string memberId = dtRes.Rows[0]["UserID"].ToString();

                // Delete fulfilled reservation
                string delResQuery = "DELETE FROM RESERVATIONS WHERE ReservationID = @ResID";
                SqlParameter[] delParams = { new SqlParameter("@ResID", resId) };
                _db.ExecuteNonQuery(delResQuery, delParams);

                // Set copy status as Reserved
                string updateCopyQuery = "UPDATE BOOKCOPIES SET CopyStatus = 'Reserved' WHERE CopyNumber = @CopyNumber";
                SqlParameter[] cParams = { new SqlParameter("@CopyNumber", copyNumber) };
                _db.ExecuteNonQuery(updateCopyQuery, cParams);

                MessageBox.Show($"Book returned successfully!\n\nRESERVATION NOTICE:\nPlease keep this book aside. Notify member {memberName} ({memberId}) that their reserved book is ready for pickup.", "Reservation Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Set copy status as Available
                string updateCopyQuery = "UPDATE BOOKCOPIES SET CopyStatus = 'Available' WHERE CopyNumber = @CopyNumber";
                SqlParameter[] cParams = { new SqlParameter("@CopyNumber", copyNumber) };
                _db.ExecuteNonQuery(updateCopyQuery, cParams);

                MessageBox.Show($"Book Copy {copyNumber} returned successfully and is now Available!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            ResetDetails();
            LoadReturnedLoansGrid();
        }

        // Reset details
        private void ResetDetails()
        {
            txtCopyNumber.Clear();
            lblBookTitle.Text = "Book Title: -";
            lblBorrower.Text = "Borrower: -";
            lblIssuedDate.Text = "Issued Date: -";
            lblDueDate.Text = "Due Date: -";
            lblOverdueStatus.Text = "Status: -";
            lblAlertTitle.Text = "📌 Reservation Notice";
            lblAlertTitle.ForeColor = Color.FromArgb(245, 158, 11);
            lblAlertMsg.Text = "When a book copy is returned, the system automatically checks for reservations on this Title.";
            lblAlertMsg.ForeColor = Color.FromArgb(148, 163, 184);

            _currentLoanId = 0;
            _currentBookNumber = "";
            btnAcceptReturn.Enabled = false;
        }

        // Load grid
        private void LoadReturnedLoansGrid(string searchKeyword = "")
        {
            string query = @"SELECT TOP 25 
                                l.LoanID AS [Loan ID], 
                                u.UserID AS [User ID], 
                                u.Name AS [Member Name], 
                                l.CopyNumber AS [Copy Number], 
                                b.Title AS [Book Title], 
                                l.ExpectedReturnDate AS [Due Date], 
                                l.ActualReturnDate AS [Returned Date] 
                             FROM LOANS l
                             JOIN USERS u ON l.UserID = u.UserID
                             JOIN BOOKCOPIES c ON l.CopyNumber = c.CopyNumber
                             JOIN BOOKS b ON c.BookNumber = b.BookNumber
                             WHERE l.ActualReturnDate IS NOT NULL";

            if (!string.IsNullOrEmpty(searchKeyword))
            {
                query += " AND (u.Name LIKE @kw OR u.UserID LIKE @kw OR l.CopyNumber LIKE @kw OR b.Title LIKE @kw)";
            }

            query += " ORDER BY l.ActualReturnDate DESC";

            SqlParameter[] parameters = string.IsNullOrEmpty(searchKeyword) ? null : new SqlParameter[] {
                new SqlParameter("@kw", "%" + searchKeyword + "%")
            };

            DataTable dt = _db.ExecuteQuery(query, parameters);
            dgvReturnedBooks.DataSource = dt;

            ApplyDarkGridStyle();
        }

        // Style grid
        // Style grid
        private void ApplyDarkGridStyle()
        {
            dgvReturnedBooks.EnableHeadersVisualStyles = false;
            dgvReturnedBooks.BorderStyle = BorderStyle.None;
            dgvReturnedBooks.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvReturnedBooks.GridColor = Color.FromArgb(51, 65, 85);
            dgvReturnedBooks.BackgroundColor = Color.FromArgb(30, 41, 59);
            dgvReturnedBooks.RowHeadersVisible = false;
            dgvReturnedBooks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvReturnedBooks.MultiSelect = false;

            dgvReturnedBooks.ColumnHeadersHeight = 38;
            dgvReturnedBooks.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(51, 65, 85);
            dgvReturnedBooks.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvReturnedBooks.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);

            dgvReturnedBooks.RowTemplate.Height = 32;
            dgvReturnedBooks.DefaultCellStyle.BackColor = Color.FromArgb(15, 23, 42);
            dgvReturnedBooks.DefaultCellStyle.ForeColor = Color.FromArgb(226, 232, 240);
            dgvReturnedBooks.DefaultCellStyle.Font = new Font("Segoe UI", 9F);
            dgvReturnedBooks.DefaultCellStyle.SelectionBackColor = Color.FromArgb(6, 182, 212);
            dgvReturnedBooks.DefaultCellStyle.SelectionForeColor = Color.FromArgb(15, 23, 42);

            dgvReturnedBooks.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(30, 41, 59);
            dgvReturnedBooks.AlternatingRowsDefaultCellStyle.ForeColor = Color.FromArgb(226, 232, 240);
            dgvReturnedBooks.AlternatingRowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(6, 182, 212);
            dgvReturnedBooks.AlternatingRowsDefaultCellStyle.SelectionForeColor = Color.FromArgb(15, 23, 42);

            foreach (DataGridViewColumn col in dgvReturnedBooks.Columns)
            {
                col.HeaderCell.Style.BackColor = Color.FromArgb(51, 65, 85);
                col.HeaderCell.Style.ForeColor = Color.White;
            }

            dgvReturnedBooks.ClearSelection();
        }

        // Search event
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadReturnedLoansGrid(txtSearch.Text.Trim());
        }

        // Back to dashboard
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            DashboardForm dashboard = new DashboardForm();
            dashboard.Show();
        }
    }
}