using System;
using System.Data;
using System.Drawing;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;

namespace SarasaviLibrarySystem
{
    public partial class ReservationForm : Form
    {
        private readonly DbConnection _db = new DbConnection();
        private bool _isMemberValid = false;
        private bool _isBookValid = false;

        public ReservationForm()
        {
            InitializeComponent();
        }

        // Form load
        private void ReservationForm_Load(object sender, EventArgs e)
        {
            LoadReservationsQueue();
        }

        // Verify member
        private void btnCheckUser_Click(object sender, EventArgs e)
        {
            string rawInput = txtUserID.Text.Trim();
            if (string.IsNullOrEmpty(rawInput))
            {
                MessageBox.Show("Please enter Member User ID.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string userId = rawInput.StartsWith("U", StringComparison.OrdinalIgnoreCase)
                            ? rawInput.ToUpper()
                            : "U" + rawInput;
            txtUserID.Text = userId;

            string query = "SELECT Name FROM USERS WHERE UserID = @UserID";
            SqlParameter[] parameters = { new SqlParameter("@UserID", userId) };
            DataTable dt = _db.ExecuteQuery(query, parameters);

            if (dt.Rows.Count > 0)
            {
                lblMemberName.Text = $"Member: {dt.Rows[0]["Name"]}";
                lblMemberName.ForeColor = Color.FromArgb(16, 185, 129);
                _isMemberValid = true;
            }
            else
            {
                lblMemberName.Text = "Member: User Not Found!";
                lblMemberName.ForeColor = Color.FromArgb(239, 68, 68);
                _isMemberValid = false;
            }
        }

        // Verify book title
        private void btnCheckBook_Click(object sender, EventArgs e)
        {
            string bookNumber = txtBookNumber.Text.Trim().ToUpper();
            txtBookNumber.Text = bookNumber;

            if (string.IsNullOrEmpty(bookNumber))
            {
                MessageBox.Show("Please enter Book Number.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = @"SELECT 
                                b.Title, 
                                COUNT(c.CopyNumber) AS TotalCopies, 
                                SUM(CASE WHEN c.CopyStatus = 'Available' AND c.IsReferenceOnly = 0 THEN 1 ELSE 0 END) AS AvailableCopies 
                             FROM BOOKS b 
                             LEFT JOIN BOOKCOPIES c ON b.BookNumber = c.BookNumber 
                             WHERE b.BookNumber = @BookNumber 
                             GROUP BY b.Title";

            SqlParameter[] parameters = { new SqlParameter("@BookNumber", bookNumber) };
            DataTable dt = _db.ExecuteQuery(query, parameters);

            if (dt.Rows.Count > 0)
            {
                string title = dt.Rows[0]["Title"].ToString();
                int total = Convert.ToInt32(dt.Rows[0]["TotalCopies"]);
                int available = dt.Rows[0]["AvailableCopies"] != DBNull.Value ? Convert.ToInt32(dt.Rows[0]["AvailableCopies"]) : 0;

                lblBookTitle.Text = $"Title: {title}";
                lblBookTitle.ForeColor = Color.White;
                lblCopiesAvailability.Text = $"Total Copies: {total} | Available for Loan: {available}";

                if (available > 0)
                {
                    lblCopiesAvailability.ForeColor = Color.FromArgb(16, 185, 129);
                }
                else
                {
                    lblCopiesAvailability.ForeColor = Color.FromArgb(245, 158, 11);
                }

                _isBookValid = true;
            }
            else
            {
                lblBookTitle.Text = "Title: Book Not Found!";
                lblBookTitle.ForeColor = Color.FromArgb(239, 68, 68);
                lblCopiesAvailability.Text = "Availability: -";
                _isBookValid = false;
            }
        }

        // Add reservation
        private void btnReserve_Click(object sender, EventArgs e)
        {
            if (!_isMemberValid || !_isBookValid)
            {
                MessageBox.Show("Please verify both Member and Book before placing a reservation.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string userId = txtUserID.Text.Trim();
            string bookNumber = txtBookNumber.Text.Trim();

            // Check duplicate reservation
            string checkQuery = "SELECT COUNT(*) FROM RESERVATIONS WHERE UserID = @UserID AND BookNumber = @BookNumber";
            SqlParameter[] checkParams = {
                new SqlParameter("@UserID", userId),
                new SqlParameter("@BookNumber", bookNumber)
            };

            DataTable dtCheck = _db.ExecuteQuery(checkQuery, checkParams);
            if (Convert.ToInt32(dtCheck.Rows[0][0]) > 0)
            {
                MessageBox.Show("This member has already reserved this title!", "Duplicate Reservation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Insert reservation
            string insertQuery = @"INSERT INTO RESERVATIONS (UserID, BookNumber, ReservationDate) 
                                   VALUES (@UserID, @BookNumber, GETDATE())";

            SqlParameter[] insertParams = {
                new SqlParameter("@UserID", userId),
                new SqlParameter("@BookNumber", bookNumber)
            };

            _db.ExecuteNonQuery(insertQuery, insertParams);

            MessageBox.Show($"Reservation placed successfully for book {bookNumber}!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            ResetInputs();
            LoadReservationsQueue();
        }

        // Cancel reservation
        private void btnCancelReservation_Click(object sender, EventArgs e)
        {
            if (dgvReservations.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a reservation from the queue to cancel.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int resId = Convert.ToInt32(dgvReservations.SelectedRows[0].Cells["Reservation ID"].Value);
            string memberName = dgvReservations.SelectedRows[0].Cells["Member Name"].Value.ToString();
            string title = dgvReservations.SelectedRows[0].Cells["Book Title"].Value.ToString();

            DialogResult result = MessageBox.Show($"Are you sure you want to cancel the reservation for {memberName} ({title})?", "Confirm Cancellation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                string deleteQuery = "DELETE FROM RESERVATIONS WHERE ReservationID = @ResID";
                SqlParameter[] parameters = { new SqlParameter("@ResID", resId) };
                _db.ExecuteNonQuery(deleteQuery, parameters);

                MessageBox.Show("Reservation cancelled successfully.", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadReservationsQueue();
            }
        }

        // Load queue
        private void LoadReservationsQueue(string searchKeyword = "")
        {
            string query = @"SELECT 
                                r.ReservationID AS [Reservation ID], 
                                r.BookNumber AS [Book ID], 
                                b.Title AS [Book Title], 
                                r.UserID AS [User ID], 
                                u.Name AS [Member Name], 
                                r.ReservationDate AS [Reserved Date] 
                             FROM RESERVATIONS r
                             JOIN BOOKS b ON r.BookNumber = b.BookNumber
                             JOIN USERS u ON r.UserID = u.UserID";

            if (!string.IsNullOrEmpty(searchKeyword))
            {
                query += " WHERE b.Title LIKE @kw OR r.BookNumber LIKE @kw OR u.Name LIKE @kw OR r.UserID LIKE @kw";
            }

            query += " ORDER BY r.ReservationDate ASC";

            SqlParameter[] parameters = string.IsNullOrEmpty(searchKeyword) ? null : new SqlParameter[] {
                new SqlParameter("@kw", "%" + searchKeyword + "%")
            };

            DataTable dt = _db.ExecuteQuery(query, parameters);
            dgvReservations.DataSource = dt;

            ApplyDarkGridStyle();
        }

        // Style grid
        private void ApplyDarkGridStyle()
        {
            dgvReservations.EnableHeadersVisualStyles = false;
            dgvReservations.BorderStyle = BorderStyle.None;
            dgvReservations.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvReservations.GridColor = Color.FromArgb(51, 65, 85);
            dgvReservations.BackgroundColor = Color.FromArgb(30, 41, 59);
            dgvReservations.RowHeadersVisible = false;
            dgvReservations.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvReservations.MultiSelect = false;

            dgvReservations.ColumnHeadersHeight = 38;
            dgvReservations.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(51, 65, 85);
            dgvReservations.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvReservations.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);

            dgvReservations.RowTemplate.Height = 32;
            dgvReservations.DefaultCellStyle.BackColor = Color.FromArgb(15, 23, 42);
            dgvReservations.DefaultCellStyle.ForeColor = Color.FromArgb(226, 232, 240);
            dgvReservations.DefaultCellStyle.Font = new Font("Segoe UI", 9F);
            dgvReservations.DefaultCellStyle.SelectionBackColor = Color.FromArgb(245, 158, 11);
            dgvReservations.DefaultCellStyle.SelectionForeColor = Color.FromArgb(15, 23, 42);

            dgvReservations.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(30, 41, 59);
            dgvReservations.AlternatingRowsDefaultCellStyle.ForeColor = Color.FromArgb(226, 232, 240);
            dgvReservations.AlternatingRowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(245, 158, 11);
            dgvReservations.AlternatingRowsDefaultCellStyle.SelectionForeColor = Color.FromArgb(15, 23, 42);

            foreach (DataGridViewColumn col in dgvReservations.Columns)
            {
                col.HeaderCell.Style.BackColor = Color.FromArgb(51, 65, 85);
                col.HeaderCell.Style.ForeColor = Color.White;
            }

            dgvReservations.ClearSelection();
        }

        // Search event
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadReservationsQueue(txtSearch.Text.Trim());
        }

        // Reset inputs
        private void ResetInputs()
        {
            txtUserID.Clear();
            txtBookNumber.Clear();
            lblMemberName.Text = "Member: Not verified";
            lblMemberName.ForeColor = Color.White;
            lblBookTitle.Text = "Title: Not verified";
            lblCopiesAvailability.Text = "Availability: -";
            _isMemberValid = false;
            _isBookValid = false;
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