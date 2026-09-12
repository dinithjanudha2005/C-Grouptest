using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;

namespace SarasaviLibrarySystem
{
    public partial class InquiryForm : Form
    {
        private readonly DbConnection _db = new DbConnection();

        public InquiryForm()
        {
            InitializeComponent();
        }

        // Form load
        private void InquiryForm_Load(object sender, EventArgs e)
        {
            LoadCategoryFilterOptions();
            LoadStatusFilterOptions();
            ExecuteSearch();
        }

        // Load categories
        private void LoadCategoryFilterOptions()
        {
            cmbCategoryFilter.Items.Clear();
            cmbCategoryFilter.Items.Add("All Categories");
            cmbCategoryFilter.Items.Add("S - Science");
            cmbCategoryFilter.Items.Add("N - Novels");
            cmbCategoryFilter.Items.Add("T - Technology");
            cmbCategoryFilter.Items.Add("F - Fiction");
            cmbCategoryFilter.Items.Add("H - History");
            cmbCategoryFilter.SelectedIndex = 0;
        }

        // Load statuses
        private void LoadStatusFilterOptions()
        {
            cmbStatusFilter.Items.Clear();
            cmbStatusFilter.Items.Add("All Statuses");
            cmbStatusFilter.Items.Add("Available");
            cmbStatusFilter.Items.Add("Borrowed");
            cmbStatusFilter.Items.Add("Reserved");
            cmbStatusFilter.SelectedIndex = 0;
        }

        // Execute search
        private void ExecuteSearch()
        {
            string keyword = txtSearch.Text.Trim();
            string selectedCat = cmbCategoryFilter.SelectedIndex > 0 ? cmbCategoryFilter.SelectedItem.ToString().Substring(0, 1) : "";
            string selectedStatus = cmbStatusFilter.SelectedIndex > 0 ? cmbStatusFilter.SelectedItem.ToString() : "";

            string query = @"SELECT 
                                c.CopyNumber AS [Copy ID], 
                                b.BookNumber AS [Book ID], 
                                b.Title AS [Book Title], 
                                b.Author AS [Author], 
                                b.Classification AS [Category], 
                                CASE WHEN c.IsReferenceOnly = 1 THEN 'Reference Only' ELSE 'Borrowable' END AS [Loan Policy], 
                                c.CopyStatus AS [Current Status] 
                             FROM BOOKCOPIES c
                             JOIN BOOKS b ON c.BookNumber = b.BookNumber 
                             WHERE 1=1";

            List<SqlParameter> parameters = new List<SqlParameter>();

            if (!string.IsNullOrEmpty(keyword))
            {
                query += " AND (b.Title LIKE @kw OR b.Author LIKE @kw OR b.BookNumber LIKE @kw OR c.CopyNumber LIKE @kw OR b.ISBN LIKE @kw)";
                parameters.Add(new SqlParameter("@kw", "%" + keyword + "%"));
            }

            if (!string.IsNullOrEmpty(selectedCat))
            {
                query += " AND b.Classification = @cat";
                parameters.Add(new SqlParameter("@cat", selectedCat));
            }

            if (!string.IsNullOrEmpty(selectedStatus))
            {
                query += " AND c.CopyStatus = @status";
                parameters.Add(new SqlParameter("@status", selectedStatus));
            }

            query += " ORDER BY b.Title ASC, c.CopyNumber ASC";

            DataTable dt = _db.ExecuteQuery(query, parameters.Count > 0 ? parameters.ToArray() : null);
            dgvResults.DataSource = dt;

            lblTotalResults.Text = $"Total Items Matching: {dt.Rows.Count}";

            ApplyDarkGridStyle();
        }

        // Style grid
        private void ApplyDarkGridStyle()
        {
            dgvResults.EnableHeadersVisualStyles = false;
            dgvResults.BorderStyle = BorderStyle.None;
            dgvResults.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvResults.GridColor = Color.FromArgb(51, 65, 85);
            dgvResults.BackgroundColor = Color.FromArgb(30, 41, 59);
            dgvResults.RowHeadersVisible = false;
            dgvResults.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvResults.MultiSelect = false;

            dgvResults.ColumnHeadersHeight = 38;
            dgvResults.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(51, 65, 85);
            dgvResults.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvResults.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);

            dgvResults.RowTemplate.Height = 32;
            dgvResults.DefaultCellStyle.BackColor = Color.FromArgb(15, 23, 42);
            dgvResults.DefaultCellStyle.ForeColor = Color.FromArgb(226, 232, 240);
            dgvResults.DefaultCellStyle.Font = new Font("Segoe UI", 9F);
            dgvResults.DefaultCellStyle.SelectionBackColor = Color.FromArgb(51, 65, 85);
            dgvResults.DefaultCellStyle.SelectionForeColor = Color.White;

            dgvResults.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(30, 41, 59);
            dgvResults.AlternatingRowsDefaultCellStyle.ForeColor = Color.FromArgb(226, 232, 240);
            dgvResults.AlternatingRowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(51, 65, 85);
            dgvResults.AlternatingRowsDefaultCellStyle.SelectionForeColor = Color.White;

            foreach (DataGridViewColumn col in dgvResults.Columns)
            {
                col.HeaderCell.Style.BackColor = Color.FromArgb(51, 65, 85);
                col.HeaderCell.Style.ForeColor = Color.White;
            }

            dgvResults.ClearSelection();
        }

        // Color badges
        private void dgvResults_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.Value == null) return;

            string colName = dgvResults.Columns[e.ColumnIndex].Name;

            // Status badge color
            if (colName == "Current Status")
            {
                string status = e.Value.ToString();
                if (status.Equals("Available", StringComparison.OrdinalIgnoreCase))
                {
                    e.CellStyle.ForeColor = Color.FromArgb(16, 185, 129);
                    e.CellStyle.Font = new Font(dgvResults.Font, FontStyle.Bold);
                }
                else if (status.Equals("Borrowed", StringComparison.OrdinalIgnoreCase))
                {
                    e.CellStyle.ForeColor = Color.FromArgb(245, 158, 11);
                    e.CellStyle.Font = new Font(dgvResults.Font, FontStyle.Bold);
                }
                else if (status.Equals("Reserved", StringComparison.OrdinalIgnoreCase))
                {
                    e.CellStyle.ForeColor = Color.FromArgb(239, 68, 68);
                    e.CellStyle.Font = new Font(dgvResults.Font, FontStyle.Bold);
                }
            }

            // Loan policy badge color
            if (colName == "Loan Policy")
            {
                string policy = e.Value.ToString();
                if (policy.Equals("Reference Only", StringComparison.OrdinalIgnoreCase))
                {
                    e.CellStyle.ForeColor = Color.FromArgb(6, 182, 212);
                    e.CellStyle.Font = new Font(dgvResults.Font, FontStyle.Bold);
                }
            }
        }

        // Search button
        private void btnSearch_Click(object sender, EventArgs e)
        {
            ExecuteSearch();
        }

        // Enter key search
        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                ExecuteSearch();
            }
        }

        // Filter changed
        private void cmbCategoryFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            ExecuteSearch();
        }

        private void cmbStatusFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            ExecuteSearch();
        }

        // Reset filters
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            cmbCategoryFilter.SelectedIndex = 0;
            cmbStatusFilter.SelectedIndex = 0;
            ExecuteSearch();
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