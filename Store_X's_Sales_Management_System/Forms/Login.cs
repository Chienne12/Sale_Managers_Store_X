using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Windows.Forms;
using Store_X_s_Sales_Management_System.Forms.Admin;
using Store_X_s_Sales_Management_System.Forms.Sales;
using Store_X_s_Sales_Management_System.Forms.Warehouse;

// Other namespaces remain unchanged...

namespace Store_X_s_Sales_Management_System.Forms
{
    public partial class Login : Form
    {
        

        public Login()
        {
            InitializeComponent();
            // TODO: Call initialization function for form settings
            InitializeForm();
        }

        /// <summary>
        /// Initialize initial parameters when Form runs
        /// </summary>
        private void InitializeForm()
        {   
            // TODO 2: Set password character masking (e.g., bullet or asterisk *)
            txtPassword.PasswordChar = '•';
            txtPassword.MaxLength = 20; // Limit maximum password length to 20 characters

            // TODO 3: Call LoadRoles() to populate ComboBox
            LoadRoles();
            // TODO 4: Select default value for ComboBox (if items exist) to save user effort
            if (cbRole.Items.Count > 0 )
            {
                cbRole.SelectedIndex = 0; // Select first item as default
            }
            // TODO 5: Assign "Enter" key on keyboard equivalent to btnLogin button
            this.AcceptButton = btnlogin;
            // TODO 6: Center Form on screen
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        /// <summary>
        /// Populate role list into ComboBox
        /// </summary>
        private void LoadRoles()
        {
            
            // TODO 1: Clear old items in cbRole (avoid double data)
            cbRole.Items.Clear();
            // TODO 2: Add roles (Admin, Sales, Warehouse) to cbRole.
            cbRole.Items.Add("Admin");
            cbRole.Items.Add("SalePerson");
            cbRole.Items.Add("Warehouse");
            // Hint: Use Enum or add hardcoded strings "Admin", "Sales"...
        }

        /// <summary>
        /// Handle Login button click event
        /// </summary>
        private void btnlogin_Click(object sender, EventArgs e)
        {
            // STEP 1: Call ValidateInput(). If data is invalid, stop (return).
            // Code here...
            if (!ValidateInput())
            {
                return;
            }

            // STEP 2: Get data from input fields (UserName, Password, Role) into variables.
            // Code here...
            string username = txtUserName.Text.Trim();
            string password = txtPassword.Text;
            string role = cbRole.SelectedItem.ToString();

            // STEP 3: Call AuthenticateUser function.
            if (AuthenticateUser(username, password, role))
            {
                MessageBox.Show("Welcome", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                NavigateToDashboard(role, username);
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid username or password. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Clear();
                txtPassword.Focus();
            }
        }

        /// <summary>
        /// Check if input data is valid
        /// </summary>
        /// <returns>True if valid, False if error</returns>
        private bool ValidateInput()
        {
            try
            {
                // TODO 1: Check if txtUserName is empty/whitespace?
                // If empty -> Show warning MessageBox -> Focus on User box -> return false.
                if (string.IsNullOrWhiteSpace(txtUserName.Text))
                {
                    MessageBox.Show("Please enter your username again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUserName.Focus();
                    return false;


                }
                // TODO 2: Check if txtPassword is empty?
                // Similar to above.
                if (string.IsNullOrWhiteSpace(txtPassword.Text))
                {
                    MessageBox.Show("Please enter your password again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                // TODO 3: Check if cbRole is selected (SelectedIndex == -1 means not selected)?
                // Similar to above.
                if (cbRole.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select your role again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                // If all checks pass -> return true.
                return true; // Modify this line after writing logic

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;

            }
        }

        /// <summary>
        /// Check username/password with Database
        /// </summary>
        private bool AuthenticateUser(string username, string password, string role)
        {
            // Important hint: Use try-catch to catch DB connection errors
            try
            {  
                string query = "SELECT COUNT(*) FROM Employees " +
                                "WHERE Username=@user " +
                                "AND Password=@pass " +
                                "AND Position=@position";
                SqlParameter[] parameter =
                {
                    new SqlParameter(@"user", username),
                    new SqlParameter(@"pass", password),
                    new SqlParameter(@"position", role)

                };
                object result = DatabaseConnection.ExecuteScalar(query, parameter);
                int count = Convert.ToInt32(result);
                return count > 0;  
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Navigate to corresponding dashboard
        /// </summary>
        private void NavigateToDashboard(string role, string username)
        {
            Form dashboard = null;
            switch (role) { 
                case "Admin":
                    dashboard = new AdminDashboard(username);
                    break;
                case "SalePerson":
                    dashboard = new SalesDashboard(username);
                    break;
                case "Warehouse":
                    dashboard = new WarehouseDashboard(username);
                    break;
                default:
                    MessageBox.Show("Role not recognized.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
            }
            if(dashboard != null)
            {
                dashboard.FormClosed += (s, args) => this.Close();
                dashboard.Show();
            }
        }
    }
}