using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;

namespace SarasaviLibrarySystem
{
    public partial class LoginForm : Form
    {
        private readonly DbConnection _db = new DbConnection();

        public LoginForm()
        {
            InitializeComponent();
        }

        // Form load
        private void LoginForm_Load(object sender, EventArgs e)
        {
            LoadRoles();
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

        // Authenticate user
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || cmbRole.SelectedValue == null)
            {
                MessageBox.Show("Please fill all fields.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int selectedRoleId = Convert.ToInt32(cmbRole.SelectedValue);

            string query = @"SELECT u.UserID, u.Name, r.RoleName 
                             FROM userLogin l
                             JOIN USERS u ON l.UserID = u.UserID
                             JOIN Role r ON u.RoleID = r.RoleID
                             WHERE l.username = @Username AND l.password = @Password AND u.RoleID = @RoleID";

            SqlParameter[] parameters = {
                new SqlParameter("@Username", username),
                new SqlParameter("@Password", password),
                new SqlParameter("@RoleID", selectedRoleId)
            };

            DataTable dt = _db.ExecuteQuery(query, parameters);

            if (dt.Rows.Count > 0)
            {
                UserSession.UserID = dt.Rows[0]["UserID"].ToString();
                UserSession.FullName = dt.Rows[0]["Name"].ToString();
                UserSession.RoleName = dt.Rows[0]["RoleName"].ToString();

                MessageBox.Show($"Welcome, {UserSession.FullName}!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Hide();
                DashboardForm dashboard = new DashboardForm();
                dashboard.Show();
            }
            else
            {
                MessageBox.Show("Invalid credentials or role.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Close app
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}