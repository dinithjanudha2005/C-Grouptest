using System;
using System.Data;
using System.Drawing;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;

namespace SarasaviLibrarySystem
{
    public partial class LoanProcessingForm : Form
    {
        private readonly DbConnection _db = new DbConnection();
        private bool _isMemberValid = false;
        private bool _isBookValid = false;

        public LoanProcessingForm()
        {
            InitializeComponent();
        }

        // Form load
        private void LoanProcessingForm_Load(object sender, EventArgs e)
        {
            txtLoanDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            txtDueDate.Text = DateTime.Now.AddDays(14).ToString("yyyy-MM-dd");

            LoadActiveLoansGrid();
        }

        // Verify member
        private void btnCheckMember_Click(object sender, EventArgs e)
        {
            string rawInput = txtUserID.Text.Trim();
            if (string.IsNullOrEmpty(rawInput))
            {
                MessageBox.Show("Please enter User ID.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Auto format ID if user types without U
            string userId = rawInput.StartsWith("U", StringComparison.OrdinalIgnoreCase)
                            ? rawInput.ToUpper()
                            : "U" + rawInput;

            txtUserID.Text = userId;

            // Consolidated user query
            string query = @"SELECT 
                                u.Name,
                                (SELECT COUNT(*) FROM LOANS WHERE UserID = u.UserID AND ActualReturnDate IS NULL) AS ActiveLoans,
                                (SELECT COUNT(*) FROM LOANS WHERE UserID = u.UserID AND ActualReturnDate IS NULL AND ExpectedReturnDate < GETDATE()) AS OverdueLoans
                             FROM USERS u 
                             WHERE u.UserID = @UserID";

            SqlParameter[] parameters = { new SqlParameter("@UserID", userId) };
            DataTable dt = _db.ExecuteQuery(query, parameters);

            if (dt.Rows.Count == 0)
            {
                lblMemberName.Text = "Member: User Not Found!";
                lblMemberName.ForeColor = Color.FromArgb(239, 68, 68);
                lblActiveLoansCount.Text = "Current Active Loans: 0 / 5";
                lblValidationStatus.Text = "Invalid User ID. Please check the directory table.";
                lblValidationStatus.ForeColor = Color.FromArgb(239, 68, 68);
                _isMemberValid = false;
                EvaluateLoanEligibility();
                return;
            }

            string name = dt.Rows[0]["Name"].ToString();
            int activeCount = Convert.ToInt32(dt.Rows[0]["ActiveLoans"]);
            int overdueCount = Convert.ToInt32(dt.Rows[0]["OverdueLoans"]);

            lblMemberName.Text = $"Member: {name}";
            lblMemberName.ForeColor = Color.White;
            lblActiveLoansCount.Text = $"Current Active Loans: {activeCount} / 5";

            if (activeCount >= 5)
            {
                lblValidationStatus.Text = "Borrow limit reached! Member already has 5 active books.";
                lblValidationStatus.ForeColor = Color.FromArgb(239, 68, 68);
                _isMemberValid = false;
            }
            else if (overdueCount > 0)
            {
                lblValidationStatus.Text = "Blocked! Member has overdue books that must be returned first.";
                lblValidationStatus.ForeColor = Color.FromArgb(239, 68, 68);
                _isMemberValid = false;
            }
            else
            {
                _isMemberValid = true;
                lblValidationStatus.Text = "Member is eligible. Now verify the Book Copy.";
                lblValidationStatus.ForeColor = Color.FromArgb(6, 182, 212);
            }

            EvaluateLoanEligibility();
        }

        // Verify book copy
        private void btnCheckBook_Click(object sender, EventArgs e)
        {
            string copyNumber = txtCopyNumber.Text.Trim().ToUpper();
            txtCopyNumber.Text = copyNumber;

            if (string.IsNullOrEmpty(copyNumber))
            {
                MessageBox.Show("Please enter Copy Number.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string bookQuery = @"SELECT b.Title, c.IsReferenceOnly, c.CopyStatus 
                                 FROM BOOKCOPIES c 
                                 JOIN BOOKS b ON c.BookNumber = b.BookNumber 
                                 WHERE c.CopyNumber = @CopyNumber";

            SqlParameter[] bParams = { new SqlParameter("@CopyNumber", copyNumber) };
            DataTable dtBook = _db.ExecuteQuery(bookQuery, bParams);

            if (dtBook.Rows.Count == 0)
            {
                lblBookTitle.Text = "Book: Copy Not Found!";
                lblBookTitle.ForeColor = Color.FromArgb(239, 68, 68);
                lblBookType.Text = "Type: - | Status: -";
                lblValidationStatus.Text = "Book copy number does not exist.";
                lblValidationStatus.ForeColor = Color.FromArgb(239, 68, 68);
                _isBookValid = false;
                EvaluateLoanEligibility();
                return;
            }

            string title = dtBook.Rows[0]["Title"].ToString();
            bool isRef = Convert.ToBoolean(dtBook.Rows[0]["IsReferenceOnly"]);
            string status = dtBook.Rows[0]["CopyStatus"].ToString();

            lblBookTitle.Text = $"Book: {title}";
            lblBookTitle.ForeColor = Color.White;
            lblBookType.Text = $"Type: {(isRef ? "Reference Only" : "Borrowable")} | Status: {status}";

            if (isRef)
            {
                lblValidationStatus.Text = "Cannot loan! This copy is marked as Reference Only.";
                lblValidationStatus.ForeColor = Color.FromArgb(239, 68, 68);
                _isBookValid = false;
            }
            else if (!status.Equals("Available", StringComparison.OrdinalIgnoreCase))
            {
                lblValidationStatus.Text = $"Cannot loan! Copy status is currently '{status}'.";
                lblValidationStatus.ForeColor = Color.FromArgb(239, 68, 68);
                _isBookValid = false;
            }
            else
            {
                _isBookValid = true;
            }

            EvaluateLoanEligibility();
        }

        // Evaluate eligibility
        private void EvaluateLoanEligibility()
        {
            if (_isMemberValid && _isBookValid)
            {
                lblValidationStatus.Text = "✓ Loan Approved! Member and Book Copy are eligible.";
                lblValidationStatus.ForeColor = Color.FromArgb(16, 185, 129);
                btnAccept.Enabled = true;
            }
            else
            {
                btnAccept.Enabled = false;
            }
        }

        // Issue loan
        private void btnAccept_Click(object sender, EventArgs e)
        {
            string userId = txtUserID.Text.Trim();
            string copyNumber = txtCopyNumber.Text.Trim();
            DateTime loanDate = DateTime.Now;
            DateTime dueDate = loanDate.AddDays(14);

            string insertLoanQuery = @"INSERT INTO LOANS (UserID, CopyNumber, LoanDate, ExpectedReturnDate) 
                                       VALUES (@UserID, @CopyNumber, @LoanDate, @DueDate)";

            SqlParameter[] loanParams = {
                new SqlParameter("@UserID", userId),
                new SqlParameter("@CopyNumber", copyNumber),
                new SqlParameter("@LoanDate", loanDate),
                new SqlParameter("@DueDate", dueDate)
            };

            _db.ExecuteNonQuery(insertLoanQuery, loanParams);

            // Update copy status
            string updateCopyQuery = "UPDATE BOOKCOPIES SET CopyStatus = 'Borrowed' WHERE CopyNumber = @CopyNumber";
            SqlParameter[] copyParams = { new SqlParameter("@CopyNumber", copyNumber) };
            _db.ExecuteNonQuery(updateCopyQuery, copyParams);

            MessageBox.Show($"Book Copy {copyNumber} issued to Member {userId} successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            ResetForm();
            LoadActiveLoansGrid();
        }

        // Cancel request
        private void btnCancel_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        // Reset inputs
        private void ResetForm()
        {
            txtUserID.Clear();
            txtCopyNumber.Clear();
            lblMemberName.Text = "Member: Not verified";
            lblMemberName.ForeColor = Color.White;
            lblActiveLoansCount.Text = "Current Active Loans: 0 / 5";
            lblBookTitle.Text = "Book: Not verified";
            lblBookTitle.ForeColor = Color.White;
            lblBookType.Text = "Type: - | Status: -";
            lblValidationStatus.Text = "Please verify Member and Book Copy to check loan eligibility.";
            lblValidationStatus.ForeColor = Color.FromArgb(148, 163, 184);

            _isMemberValid = false;
            _isBookValid = false;
            btnAccept.Enabled = false;
        }

        // Load grid
        private void LoadActiveLoansGrid(string searchKeyword = "")
        {
            string query = @"SELECT 
                                l.LoanID AS [Loan ID], 
                                u.UserID AS [User ID], 
                                u.Name AS [Member Name], 
                                l.CopyNumber AS [Copy Number], 
                                b.Title AS [Book Title], 
                                l.LoanDate AS [Issued Date], 
                                l.ExpectedReturnDate AS [Due Date] 
                             FROM LOANS l
                             JOIN USERS u ON l.UserID = u.UserID
                             JOIN BOOKCOPIES c ON l.CopyNumber = c.CopyNumber
                             JOIN BOOKS b ON c.BookNumber = b.BookNumber
                             WHERE l.ActualReturnDate IS NULL";

            if (!string.IsNullOrEmpty(searchKeyword))
            {
                query += " AND (u.Name LIKE @kw OR u.UserID LIKE @kw OR l.CopyNumber LIKE @kw OR b.Title LIKE @kw)";
            }

            query += " ORDER BY l.LoanDate DESC";

            SqlParameter[] parameters = string.IsNullOrEmpty(searchKeyword) ? null : new SqlParameter[] {
                new SqlParameter("@kw", "%" + searchKeyword + "%")
            };

            DataTable dt = _db.ExecuteQuery(query, parameters);
            dgvActiveLoans.DataSource = dt;

            ApplyDarkGridStyle();
        }

        // Style grid
        private void ApplyDarkGridStyle()
        {
            dgvActiveLoans.EnableHeadersVisualStyles = false;
            dgvActiveLoans.BorderStyle = BorderStyle.None;
            dgvActiveLoans.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvActiveLoans.GridColor = Color.FromArgb(51, 65, 85);
            dgvActiveLoans.BackgroundColor = Color.FromArgb(30, 41, 59);
            dgvActiveLoans.RowHeadersVisible = false;
            dgvActiveLoans.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvActiveLoans.MultiSelect = false;

            dgvActiveLoans.ColumnHeadersHeight = 38;
            dgvActiveLoans.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(51, 65, 85);
            dgvActiveLoans.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvActiveLoans.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);

            dgvActiveLoans.RowTemplate.Height = 32;
            dgvActiveLoans.DefaultCellStyle.BackColor = Color.FromArgb(15, 23, 42);
            dgvActiveLoans.DefaultCellStyle.ForeColor = Color.FromArgb(226, 232, 240);
            dgvActiveLoans.DefaultCellStyle.Font = new Font("Segoe UI", 9F);
            dgvActiveLoans.DefaultCellStyle.SelectionBackColor = Color.FromArgb(6, 182, 212);
            dgvActiveLoans.DefaultCellStyle.SelectionForeColor = Color.FromArgb(15, 23, 42);

            dgvActiveLoans.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(30, 41, 59);
            dgvActiveLoans.AlternatingRowsDefaultCellStyle.ForeColor = Color.FromArgb(226, 232, 240);
            dgvActiveLoans.AlternatingRowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(6, 182, 212);
            dgvActiveLoans.AlternatingRowsDefaultCellStyle.SelectionForeColor = Color.FromArgb(15, 23, 42);

            foreach (DataGridViewColumn col in dgvActiveLoans.Columns)
            {
                col.HeaderCell.Style.BackColor = Color.FromArgb(51, 65, 85);
                col.HeaderCell.Style.ForeColor = Color.White;
            }

            dgvActiveLoans.ClearSelection();
        }

        // Search event
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadActiveLoansGrid(txtSearch.Text.Trim());
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