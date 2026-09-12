using System;
using System.Data;
using System.Drawing;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;

namespace SarasaviLibrarySystem
{
    public partial class MemberManagementForm : Form
    {
        private readonly DbConnection _db = new DbConnection();

        public MemberManagementForm()
        {
            InitializeComponent();
        }

        // Form load
        private void MemberManagementForm_Load(object sender, EventArgs e)
        {
            LoadRoles();
            LoadSexOptions();
            GenerateNextUserID();
            LoadMembersGrid();
        }

        // Load roles
        private void LoadRoles()
        {
            string query = "SELECT RoleID, RoleName FROM Role";
            DataTable dt = _db.ExecuteQuery(query);
            cmbRole.DataSource = dt;
            cmbRole.DisplayMember = "RoleName";
            cmbRole.ValueMember = "RoleID";
        }

        // Load sex options
        private void LoadSexOptions()
        {
            cmbSex.Items.Clear();
            cmbSex.Items.Add("M - Male");
            cmbSex.Items.Add("F - Female");
            cmbSex.SelectedIndex = 0;
        }

        // Auto generate UserID
        private void GenerateNextUserID()
        {
            string query = "SELECT COUNT(*) FROM USERS";
            DataTable dt = _db.ExecuteQuery(query);
            int count = Convert.ToInt32(dt.Rows[0][0]) + 1;
            txtUserID.Text = $"U{count:D4}";
        }

        // Save member
        private void btnSave_Click(object sender, EventArgs e)
        {
            string userId = txtUserID.Text.Trim();
            string name = txtName.Text.Trim();
            string nic = txtNIC.Text.Trim();
            string sex = cmbSex.SelectedItem.ToString().Substring(0, 1);
            string tel = txtTelephone.Text.Trim();
            string address = txtAddress.Text.Trim();
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(nic) || string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please fill all required fields (Name, NIC, Username, Password).", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int roleId = Convert.ToInt32(cmbRole.SelectedValue);

            // Insert into USERS
            string insertUserQuery = @"INSERT INTO USERS (UserID, RoleID, Name, Sex, Address, Telephone, NIC) 
                                       VALUES (@UserID, @RoleID, @Name, @Sex, @Address, @Telephone, @NIC)";

            SqlParameter[] userParams = {
                new SqlParameter("@UserID", userId),
                new SqlParameter("@RoleID", roleId),
                new SqlParameter("@Name", name),
                new SqlParameter("@Sex", sex),
                new SqlParameter("@Address", string.IsNullOrEmpty(address) ? (object)DBNull.Value : address),
                new SqlParameter("@Telephone", string.IsNullOrEmpty(tel) ? (object)DBNull.Value : tel),
                new SqlParameter("@NIC", nic)
            };

            _db.ExecuteNonQuery(insertUserQuery, userParams);

            // Insert into userLogin
            string insertLoginQuery = @"INSERT INTO userLogin (UserID, username, password) 
                                        VALUES (@UserID, @Username, @Password)";

            SqlParameter[] loginParams = {
                new SqlParameter("@UserID", userId),
                new SqlParameter("@Username", username),
                new SqlParameter("@Password", password)
            };

            _db.ExecuteNonQuery(insertLoginQuery, loginParams);

            MessageBox.Show($"Member {name} registered successfully with User ID {userId}!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            ClearInputs();
            GenerateNextUserID();
            LoadMembersGrid();
        }

        // Load grid
        private void LoadMembersGrid(string searchKeyword = "")
        {
            string query = @"SELECT 
                                u.UserID AS [User ID], 
                                u.Name AS [Full Name], 
                                r.RoleName AS [Role], 
                                u.NIC AS [NIC], 
                                u.Sex AS [Sex], 
                                u.Telephone AS [Contact], 
                                u.Address AS [Address] 
                             FROM USERS u
                             JOIN Role r ON u.RoleID = r.RoleID";

            if (!string.IsNullOrEmpty(searchKeyword))
            {
                query += " WHERE u.Name LIKE @kw OR u.NIC LIKE @kw OR u.UserID LIKE @kw";
            }

            query += " ORDER BY u.UserID ASC";

            SqlParameter[] parameters = string.IsNullOrEmpty(searchKeyword) ? null : new SqlParameter[] {
                new SqlParameter("@kw", "%" + searchKeyword + "%")
            };

            DataTable dt = _db.ExecuteQuery(query, parameters);
            dgvMembers.DataSource = dt;

            ApplyDarkGridStyle();
        }

        // Style grid
        private void ApplyDarkGridStyle()
        {
            dgvMembers.EnableHeadersVisualStyles = false;
            dgvMembers.BorderStyle = BorderStyle.None;
            dgvMembers.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvMembers.GridColor = Color.FromArgb(51, 65, 85);
            dgvMembers.BackgroundColor = Color.FromArgb(30, 41, 59);
            dgvMembers.RowHeadersVisible = false;
            dgvMembers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMembers.MultiSelect = false;

            dgvMembers.ColumnHeadersHeight = 38;
            dgvMembers.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(51, 65, 85);
            dgvMembers.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvMembers.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);

            dgvMembers.RowTemplate.Height = 32;
            dgvMembers.DefaultCellStyle.BackColor = Color.FromArgb(15, 23, 42);
            dgvMembers.DefaultCellStyle.ForeColor = Color.FromArgb(226, 232, 240);
            dgvMembers.DefaultCellStyle.Font = new Font("Segoe UI", 9F);
            dgvMembers.DefaultCellStyle.SelectionBackColor = Color.FromArgb(6, 182, 212);
            dgvMembers.DefaultCellStyle.SelectionForeColor = Color.FromArgb(15, 23, 42);

            dgvMembers.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(30, 41, 59);
            dgvMembers.AlternatingRowsDefaultCellStyle.ForeColor = Color.FromArgb(226, 232, 240);
            dgvMembers.AlternatingRowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(6, 182, 212);
            dgvMembers.AlternatingRowsDefaultCellStyle.SelectionForeColor = Color.FromArgb(15, 23, 42);

            foreach (DataGridViewColumn col in dgvMembers.Columns)
            {
                col.HeaderCell.Style.BackColor = Color.FromArgb(51, 65, 85);
                col.HeaderCell.Style.ForeColor = Color.White;
            }

            dgvMembers.ClearSelection();
        }

        // Search event
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadMembersGrid(txtSearch.Text.Trim());
        }

        // Clear fields
        private void ClearInputs()
        {
            txtName.Clear();
            txtNIC.Clear();
            txtTelephone.Clear();
            txtAddress.Clear();
            txtUsername.Clear();
            txtPassword.Clear();
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