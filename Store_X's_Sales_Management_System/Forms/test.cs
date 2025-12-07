using System;

using System.Data;

using System.Data.SqlClient;

using System.Windows.Forms;

using Store_X_s_Sales_Management_System.Enums;

using Store_X_s_Sales_Management_System.Forms.Admin;

using Store_X_s_Sales_Management_System.Forms.Sales;

using Store_X_s_Sales_Management_System.Forms.Warehouse;



namespace Store_X_s_Sales_Management_System.Forms

{

    /// <summary>

    /// Login form for Store-X Sales Management System

    /// Handles user authentication and role-based navigation

    /// </summary>

    public partial class Login : Form

    {

        private string connectionString;



        public Login()

        {

            InitializeComponent();

            InitializeForm();

        }



        /// <summary>

        /// Initialize form settings and load roles

        /// </summary>

        private void InitializeForm()

        {

            // Get connection string from app.config

            connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Store_X's_Sales_Management_System.Properties.Settings.Store_XConnectionString"].ConnectionString;



            // Set password character

            txtPassword.PasswordChar = '●';



            // Load roles into ComboBox

            LoadRoles();



            // Set default selection

            if (cbRole.Items.Count > 0)

            {

                cbRole.SelectedIndex = 0;

            }



            // Set Enter key behavior

            this.AcceptButton = btnlogin;



            // Center form on screen

            this.StartPosition = FormStartPosition.CenterScreen;

        }



        /// <summary>

        /// Load user roles into ComboBox

        /// </summary>

        private void LoadRoles()

        {

            cbRole.Items.Clear();

            cbRole.Items.Add(UserRole.Admin.ToString());

            cbRole.Items.Add(UserRole.Sales.ToString());

            cbRole.Items.Add(UserRole.Warehouse.ToString());

        }



        /// <summary>

        /// Handle login button click event

        /// </summary>

        private void btnlogin_Click(object sender, EventArgs e)

        {

            // Validate input

            if (!ValidateInput())

            {

                return;

            }



            string username = txtUserName.Text.Trim();

            string password = txtPassword.Text;

            string selectedRole = cbRole.SelectedItem.ToString();



            // Authenticate user

            if (AuthenticateUser(username, password, selectedRole))

            {

                MessageBox.Show($"Welcome, {username}!", "Login Successful", 

                    MessageBoxButtons.OK, MessageBoxIcon.Information);



                // Navigate to appropriate dashboard based on role

                NavigateToDashboard(selectedRole, username);



                // Hide login form

                this.Hide();

            }

            else

            {

                MessageBox.Show("Invalid username, password, or role.\nPlease try again.", 

                    "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

                

                // Clear password field

                txtPassword.Clear();

                txtPassword.Focus();

            }

        }



        /// <summary>

        /// Validate user input before authentication

        /// </summary>

        private bool ValidateInput()

        {

            if (string.IsNullOrWhiteSpace(txtUserName.Text))

            {

                MessageBox.Show("Please enter your username.", "Validation Error", 

                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                txtUserName.Focus();

                return false;

            }



            if (string.IsNullOrWhiteSpace(txtPassword.Text))

            {

                MessageBox.Show("Please enter your password.", "Validation Error", 

                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                txtPassword.Focus();

                return false;

            }



            if (cbRole.SelectedIndex == -1)

            {

                MessageBox.Show("Please select your role.", "Validation Error", 

                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                cbRole.Focus();

                return false;

            }



            return true;

        }



        /// <summary>

        /// Authenticate user against database

        /// </summary>

        private bool AuthenticateUser(string username, string password, string role)

        {

            try

            {

                using (SqlConnection conn = new SqlConnection(connectionString))

                {

                    conn.Open();



                    string query = @"SELECT COUNT(*) FROM Employees 

                                   WHERE Username = @Username 

                                   AND Password = @Password 

                                   AND Role = @Role 

                                   AND IsActive = 1";



                    using (SqlCommand cmd = new SqlCommand(query, conn))

                    {

                        cmd.Parameters.AddWithValue("@Username", username);

                        cmd.Parameters.AddWithValue("@Password", password);

                        cmd.Parameters.AddWithValue("@Role", role);



                        int count = (int)cmd.ExecuteScalar();

                        return count > 0;

                    }

                }

            }

            catch (Exception ex)

            {

                MessageBox.Show($"Database connection error:\n{ex.Message}", 

                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;

            }

        }



        /// <summary>

        /// Navigate to appropriate dashboard based on user role

        /// </summary>

        private void NavigateToDashboard(string role, string username)

        {

            Form dashboard = null;



            switch (role)

            {

                case "Admin":

                    dashboard = new AdminDashboard(username);

                    break;

                case "Sales":

                    dashboard = new SalesDashboard(username);

                    break;

                case "Warehouse":

                    dashboard = new WarehouseDashboard(username);

                    break;

                default:

                    MessageBox.Show("Unknown role.", "Error", 

                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;

            }



            if (dashboard != null)

            {

                dashboard.FormClosed += (s, args) => this.Close();

                dashboard.Show();

            }

        }



        private void label1_Click(object sender, EventArgs e)

        {

            // Event handler for label click (can be used for easter eggs or animations)

        }



        private void lblNameEffect_Click(object sender, EventArgs e)

        {

            // Event handler for label click

        }

    }

}