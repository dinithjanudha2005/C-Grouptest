using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace SarasaviLibrarySystem
{
    public partial class DashboardForm : Form
    {
        private readonly DbConnection _db = new DbConnection();

        public DashboardForm()
        {
            InitializeComponent();
        }

        // Form load
        private void DashboardForm_Load(object sender, EventArgs e)
        {
            lblGreeting.Text = $"Welcome back, {UserSession.FullName}!";
            lblRoleBadge.Text = $"Role: {UserSession.RoleName}";

            LoadDashboardMetrics();
            LoadRecentLoans();
        }

        // Load metrics
        private void LoadDashboardMetrics()
        {
            // Books count
            DataTable dtBooks = _db.ExecuteQuery("SELECT COUNT(*) FROM BOOKS");
            lblBooksCount.Text = dtBooks.Rows[0][0].ToString();

            // Members count
            DataTable dtMembers = _db.ExecuteQuery("SELECT COUNT(*) FROM USERS");
            lblMembersCount.Text = dtMembers.Rows[0][0].ToString();

            // Active loans count
            DataTable dtLoans = _db.ExecuteQuery("SELECT COUNT(*) FROM LOANS WHERE ActualReturnDate IS NULL");
            lblActiveLoansCount.Text = dtLoans.Rows[0][0].ToString();

            // Reservations count
            DataTable dtRes = _db.ExecuteQuery("SELECT COUNT(*) FROM RESERVATIONS");
            lblReservationsCount.Text = dtRes.Rows[0][0].ToString();
        }

        // Load grid
        private void LoadRecentLoans()
        {
            string query = @"SELECT TOP 10 
                                l.LoanID AS [Loan ID], 
                                u.Name AS [Member Name], 
                                l.CopyNumber AS [Copy Number], 
                                l.LoanDate AS [Loan Date], 
                                l.ExpectedReturnDate AS [Due Date]
                             FROM LOANS l
                             JOIN USERS u ON l.UserID = u.UserID
                             ORDER BY l.LoanDate DESC";

            DataTable dt = _db.ExecuteQuery(query);
            dgvRecentLoans.DataSource = dt;

            // Apply styles after binding
            ApplyDarkGridStyle();
        }

        // Force grid styling
        private void ApplyDarkGridStyle()
        {
            dgvRecentLoans.EnableHeadersVisualStyles = false;
            dgvRecentLoans.BorderStyle = BorderStyle.None;
            dgvRecentLoans.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvRecentLoans.GridColor = Color.FromArgb(51, 65, 85);
            dgvRecentLoans.BackgroundColor = Color.FromArgb(30, 41, 59);
            dgvRecentLoans.RowHeadersVisible = false;
            dgvRecentLoans.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRecentLoans.MultiSelect = false;

            // Header styling
            dgvRecentLoans.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvRecentLoans.ColumnHeadersHeight = 40;
            dgvRecentLoans.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(51, 65, 85);
            dgvRecentLoans.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvRecentLoans.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);

            // Row styling
            dgvRecentLoans.RowTemplate.Height = 35;
            dgvRecentLoans.DefaultCellStyle.BackColor = Color.FromArgb(15, 23, 42);
            dgvRecentLoans.DefaultCellStyle.ForeColor = Color.FromArgb(226, 232, 240);
            dgvRecentLoans.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F);
            dgvRecentLoans.DefaultCellStyle.SelectionBackColor = Color.FromArgb(6, 182, 212);
            dgvRecentLoans.DefaultCellStyle.SelectionForeColor = Color.FromArgb(15, 23, 42);

            // Alternating row styling
            dgvRecentLoans.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(30, 41, 59);
            dgvRecentLoans.AlternatingRowsDefaultCellStyle.ForeColor = Color.FromArgb(226, 232, 240);
            dgvRecentLoans.AlternatingRowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(6, 182, 212);
            dgvRecentLoans.AlternatingRowsDefaultCellStyle.SelectionForeColor = Color.FromArgb(15, 23, 42);

            // Force each column style
            foreach (DataGridViewColumn col in dgvRecentLoans.Columns)
            {
                col.HeaderCell.Style.BackColor = Color.FromArgb(51, 65, 85);
                col.HeaderCell.Style.ForeColor = Color.White;
                col.HeaderCell.Style.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            }

            dgvRecentLoans.ClearSelection();
        }

        // Navigation events
        private void btnBooks_Click(object sender, EventArgs e)
        {
            this.Hide();
            BookManagementForm booksForm = new BookManagementForm();
            booksForm.Show();
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            this.Hide();
            MemberManagementForm membersForm = new MemberManagementForm();
            membersForm.Show();
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoanProcessingForm loanForm = new LoanProcessingForm();
            loanForm.Show();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Hide();
            ReturnProcessingForm returnForm = new ReturnProcessingForm();
            returnForm.Show();
        }

        private void btnReservations_Click(object sender, EventArgs e)
        {
            this.Hide();
            ReservationForm resForm = new ReservationForm();
            resForm.Show();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.Hide();
            InquiryForm searchForm = new InquiryForm();
            searchForm.Show();
        }

        // Logout
        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm login = new LoginForm();
            login.Show();
        }
    }
}