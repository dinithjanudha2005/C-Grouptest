using System;
using System.Data;
using System.Drawing;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;

namespace SarasaviLibrarySystem
{
    public partial class BookManagementForm : Form
    {
        private readonly DbConnection _db = new DbConnection();

        public BookManagementForm()
        {
            InitializeComponent();
        }

        // Form load
        private void BookManagementForm_Load(object sender, EventArgs e)
        {
            LoadClassifications();
            LoadBooksInventory();
        }

        // Load classifications
        private void LoadClassifications()
        {
            cmbClassification.Items.Clear();
            cmbClassification.Items.Add("S - Science");
            cmbClassification.Items.Add("N - Novels");
            cmbClassification.Items.Add("T - Technology");
            cmbClassification.Items.Add("F - Fiction");
            cmbClassification.Items.Add("H - History");
            cmbClassification.SelectedIndex = 0;
        }

        // Auto generate BookNumber
        private void cmbClassification_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbClassification.SelectedItem == null) return;

            string prefix = cmbClassification.SelectedItem.ToString().Substring(0, 1);
            string query = "SELECT MAX(BookNumber) FROM BOOKS WHERE Classification = @Classification";
            SqlParameter[] parameters = { new SqlParameter("@Classification", prefix) };

            DataTable dt = _db.ExecuteQuery(query, parameters);
            int nextNumber = 1;

            if (dt.Rows.Count > 0 && dt.Rows[0][0] != DBNull.Value)
            {
                string maxBookNumber = dt.Rows[0][0].ToString();
                if (maxBookNumber.Length > 1 && int.TryParse(maxBookNumber.Substring(1), out int currentNum))
                {
                    nextNumber = currentNum + 1;
                }
            }

            txtBookNumber.Text = $"{prefix}{nextNumber:D4}";
        }

        // Save book & copies
        private void btnSave_Click(object sender, EventArgs e)
        {
            string bookNumber = txtBookNumber.Text.Trim();
            string classification = cmbClassification.SelectedItem.ToString().Substring(0, 1);
            string title = txtBookTitle.Text.Trim();
            string author = txtAuthor.Text.Trim();
            string isbn = txtISBN.Text.Trim();
            int copiesCount = (int)numCopies.Value;
            bool isRefOnly = chkReferenceOnly.Checked;

            if (string.IsNullOrEmpty(title))
            {
                MessageBox.Show("Please enter the book title.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Insert book
            string insertBookQuery = @"INSERT INTO BOOKS (BookNumber, Classification, Title, Author, ISBN) 
                                      VALUES (@BookNumber, @Classification, @Title, @Author, @ISBN)";

            SqlParameter[] bookParams = {
                new SqlParameter("@BookNumber", bookNumber),
                new SqlParameter("@Classification", classification),
                new SqlParameter("@Title", title),
                new SqlParameter("@Author", string.IsNullOrEmpty(author) ? (object)DBNull.Value : author),
                new SqlParameter("@ISBN", string.IsNullOrEmpty(isbn) ? (object)DBNull.Value : isbn)
            };

            _db.ExecuteNonQuery(insertBookQuery, bookParams);

            // Insert copies
            for (int i = 1; i <= copiesCount; i++)
            {
                string copyNumber = $"{bookNumber}-{i:D2}";
                string insertCopyQuery = @"INSERT INTO BOOKCOPIES (CopyNumber, BookNumber, IsReferenceOnly, CopyStatus) 
                                           VALUES (@CopyNumber, @BookNumber, @IsRef, 'Available')";

                SqlParameter[] copyParams = {
                    new SqlParameter("@CopyNumber", copyNumber),
                    new SqlParameter("@BookNumber", bookNumber),
                    new SqlParameter("@IsRef", isRefOnly)
                };

                _db.ExecuteNonQuery(insertCopyQuery, copyParams);
            }

            MessageBox.Show($"Book and {copiesCount} copies registered successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            ClearInputs();
            cmbClassification_SelectedIndexChanged(null, null);
            LoadBooksInventory();
        }

        // Load grid
        private void LoadBooksInventory(string searchKeyword = "")
        {
            string query = @"SELECT 
                                c.CopyNumber AS [Copy ID], 
                                b.Title AS [Book Title], 
                                b.Author AS [Author], 
                                b.Classification AS [Cat], 
                                CASE WHEN c.IsReferenceOnly = 1 THEN 'Reference Only' ELSE 'Borrowable' END AS [Loan Type], 
                                c.CopyStatus AS [Status]
                             FROM BOOKCOPIES c
                             JOIN BOOKS b ON c.BookNumber = b.BookNumber";

            if (!string.IsNullOrEmpty(searchKeyword))
            {
                query += " WHERE b.Title LIKE @kw OR b.Author LIKE @kw OR c.CopyNumber LIKE @kw";
            }

            query += " ORDER BY c.CopyNumber ASC";

            SqlParameter[] parameters = string.IsNullOrEmpty(searchKeyword) ? null : new SqlParameter[] {
                new SqlParameter("@kw", "%" + searchKeyword + "%")
            };

            DataTable dt = _db.ExecuteQuery(query, parameters);
            dgvBooks.DataSource = dt;

            ApplyDarkGridStyle();
        }

        // Style grid
        private void ApplyDarkGridStyle()
        {
            dgvBooks.EnableHeadersVisualStyles = false;
            dgvBooks.BorderStyle = BorderStyle.None;
            dgvBooks.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvBooks.GridColor = Color.FromArgb(51, 65, 85);
            dgvBooks.BackgroundColor = Color.FromArgb(30, 41, 59);
            dgvBooks.RowHeadersVisible = false;
            dgvBooks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBooks.MultiSelect = false;

            dgvBooks.ColumnHeadersHeight = 38;
            dgvBooks.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(51, 65, 85);
            dgvBooks.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvBooks.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);

            dgvBooks.RowTemplate.Height = 32;
            dgvBooks.DefaultCellStyle.BackColor = Color.FromArgb(15, 23, 42);
            dgvBooks.DefaultCellStyle.ForeColor = Color.FromArgb(226, 232, 240);
            dgvBooks.DefaultCellStyle.Font = new Font("Segoe UI", 9F);
            dgvBooks.DefaultCellStyle.SelectionBackColor = Color.FromArgb(6, 182, 212);
            dgvBooks.DefaultCellStyle.SelectionForeColor = Color.FromArgb(15, 23, 42);

            dgvBooks.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(30, 41, 59);
            dgvBooks.AlternatingRowsDefaultCellStyle.ForeColor = Color.FromArgb(226, 232, 240);
            dgvBooks.AlternatingRowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(6, 182, 212);
            dgvBooks.AlternatingRowsDefaultCellStyle.SelectionForeColor = Color.FromArgb(15, 23, 42);

            foreach (DataGridViewColumn col in dgvBooks.Columns)
            {
                col.HeaderCell.Style.BackColor = Color.FromArgb(51, 65, 85);
                col.HeaderCell.Style.ForeColor = Color.White;
            }

            dgvBooks.ClearSelection();
        }

        // Search event
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadBooksInventory(txtSearch.Text.Trim());
        }

        // Clear fields
        private void ClearInputs()
        {
            txtBookTitle.Clear();
            txtAuthor.Clear();
            txtISBN.Clear();
            numCopies.Value = 1;
            chkReferenceOnly.Checked = false;
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