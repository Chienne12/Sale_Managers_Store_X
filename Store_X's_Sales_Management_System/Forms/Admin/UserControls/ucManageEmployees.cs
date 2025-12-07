using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Text;
using System.Drawing;
using Store_X_s_Sales_Management_System.Forms.Shared;

namespace Store_X_s_Sales_Management_System.Forms.Admin.UserControls
{
    public partial class ucManageEmployees : UserControl
    {
        
        private Timer errorTimer;
        private Color originalBackColor;
        public string CurrentUsername { get; set; } // Property to store current logged-in admin

        public ucManageEmployees()
        {
            InitializeComponent();
            InitializeUserControl();
        }

        /// <summary>
        /// Initialize initial settings
        /// </summary>
        private void InitializeUserControl()
        {
            try
            {
                dgvEmployees.ReadOnly = true;
                dgvEmployees.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvEmployees.MultiSelect = false;
                dgvEmployees.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                
                // Initialize error timer
                errorTimer = new Timer();
                errorTimer.Interval = 2000; // 2 seconds
                errorTimer.Tick += ErrorTimer_Tick;
                originalBackColor = lblFormTitle.BackColor;
                
                LoadEmployees();
                LoadData();

                LoadRolesComboBox();

                // Wire up Reactivate button (btnReactivate defined in Designer or added here)
                // Since we are modifying Designer for button, we just wire up event here later if needed
                // But let's add it programmatically or via Designer.
                // Checking previous code, btnReactivate is usually in Designer.
                // I will add it via Designer modification tool, so here I just ensure logic exists.


            }
            catch (Exception ex)
            {
                Console.WriteLine("Error initializing user control: " + ex.Message);
            }

        }

        /// <summary>
        /// Show error message with red background
        /// </summary>
        private void ShowError(string message)
        {
            lblFormTitle.Text = message;
            lblFormTitle.ForeColor = Color.White;
            lblFormTitle.BackColor = Color.FromArgb(220, 53, 69); // Bootstrap danger red
            errorTimer.Start();
        }

        /// <summary>
        /// Show success message with green background
        /// </summary>
        private void ShowSuccess(string message)
        {
            lblFormTitle.Text = message;
            lblFormTitle.ForeColor = Color.White;
            lblFormTitle.BackColor = Color.FromArgb(40, 167, 69); // Bootstrap success green
            errorTimer.Start();
        }

        /// <summary>
        /// Reset label after timer
        /// </summary>
        private void ErrorTimer_Tick(object sender, EventArgs e)
        {
            errorTimer.Stop();
            lblFormTitle.Text = "Add Employee Form";
            lblFormTitle.ForeColor = Color.Black;
            lblFormTitle.BackColor = originalBackColor;
        }

        /// <summary>
        /// Load employee list from Database to DataGridView
        /// </summary>
        private void LoadData()
        {   cbAuthorityLevel.Items.Clear();
            cbRoleSelection.Items.Clear();
            cbRoleSelection.Items.Add("Admin");
            cbRoleSelection.Items.Add("SalePerson");
            cbRoleSelection.Items.Add("WareHouse");
            cbAuthorityLevel.Items.Add("1");
            cbAuthorityLevel.Items.Add("2");
            cbAuthorityLevel.Items.Add("3");

        }
        private void LoadEmployees()
        {
            try
            {
                // SELECT without Password for security
                string query = "SELECT EmployeeID, EmployeeName, Position, AuthorityLevel, Username FROM Employees";

                DataTable employeesDataTable = DatabaseConnection.ExecuteQuery(query, null);
                dgvEmployees.DataSource = employeesDataTable;
                
                // Set column headers
                dgvEmployees.Columns["EmployeeID"].HeaderText = "ID";
                dgvEmployees.Columns["EmployeeName"].HeaderText = "Name";
                dgvEmployees.Columns["Position"].HeaderText = "Position";
                dgvEmployees.Columns["AuthorityLevel"].HeaderText = "Level";
                dgvEmployees.Columns["Username"].HeaderText = "Username";
                
                // Style resigned employees
                foreach (DataGridViewRow row in dgvEmployees.Rows)
                {
                    if (row.Cells["EmployeeName"].Value != null && 
                        row.Cells["EmployeeName"].Value.ToString().StartsWith("[RESIGNED]"))
                    {
                        row.DefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);
                        row.DefaultCellStyle.ForeColor = Color.Gray;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading employees: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Load Role list into ComboBox
        /// </summary>
        private void LoadRolesComboBox()
        {
            cboRoleFilter.Items.Clear();
            cboRoleFilter.Items.Add("All");
            cboRoleFilter.Items.Add("Admin");
            cboRoleFilter.Items.Add("SalePerson");
            cboRoleFilter.Items.Add("Warehouse");
            cboRoleFilter.SelectedIndex = 0;
        }

        
        private bool AddEmployeeToDatabase(string employeeName, string username, string position, int authorityLevel, string password)
        {
            // TODO 1: Write SQL INSERT statement
            // string query = @"INSERT INTO Employees (FullName, Username, Password, Role, Status, CreatedDate) 
            //                  VALUES (@FullName, @Username, @Password, @Role, 'Active', GETDATE())";
            string query = "INSERT INTO Employees (EmployeeName,Position,AuthorityLevel,Username,Password)" +
                            "VALUES (@fullname,@position,@authorityLevel,@username,@password)";
            SqlParameter[] parameters =
            {
                new SqlParameter ("@fullname", employeeName),
                new SqlParameter ("@position", position),
                new SqlParameter ("@authorityLevel", authorityLevel),
                new SqlParameter ("@username", username),
                new SqlParameter ("@password", password)
            };
            int rowsAffected = DatabaseConnection.ExecuteNonQuery(query, parameters);

            return true; // Placeholder
        }

        /// <summary>
        /// Handle Edit Employee button click event
        /// </summary>
        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvEmployees.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select an employee to edit!");
                    return;
                }
                int employeeId = Convert.ToInt32(dgvEmployees.SelectedRows[0].Cells["EmployeeID"].Value);
                if (!ValidateInput())
                    return;
                string employeeName = txtFullName.Text.Trim();
                string username = txtUsername.Text.Trim();
                string position = cbRoleSelection.Text.Trim();
                int authorityLevel = int.Parse(cbAuthorityLevel.Text);
                string password = string.Empty;
                if (txtConfirmPassword.Text != txtPassword.Text)
                {
                    MessageBox.Show("Password no correct!");
                    txtConfirmPassword.Focus();
                    return;
                }
                else
                {
                    password = txtPassword.Text;
                }
                if (UpdateEmployeeInDatabase(employeeId, employeeName, username, position, authorityLevel, password))
                {
                    MessageBox.Show("Employee updated successfully!");
                    LoadEmployees();
                    ClearInputFields();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error edit employees: " + ex.Message);

            }
        }

        /// <summary>
        /// Update employee information in Database
        /// </summary>
        private bool UpdateEmployeeInDatabase(int employeeId, string employeeName, string username, string position, int authorityLevel, string password)
        {
            try
            {
                string query = "UPDATE Employees " +
                               "SET EmployeeName = @fullname, " +
                               "Position = @position, " +
                               "AuthorityLevel = @authorityLevel, " +
                               "Username = @username, " +
                               "Password = @password " +
                               "WHERE EmployeeId = @employeeId";
                SqlParameter[] parameter =
                {
                new SqlParameter("@fullname", employeeName),
                new SqlParameter("@position", position),
                new SqlParameter("@authorityLevel", authorityLevel),
                new SqlParameter("@username", username),
                new SqlParameter("@password", password),
                new SqlParameter("@employeeId", employeeId)
                };
                DatabaseConnection.ExecuteNonQuery(query, parameter);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Update Employee: " + ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Handle Delete (Resign) Employee button click event - SOFT DELETE
        /// </summary>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvEmployees.SelectedRows.Count == 0)
            {
                ShowError("Please select an employee!");
                return;
            }

            int employeeId = Convert.ToInt32(dgvEmployees.SelectedRows[0].Cells["EmployeeID"].Value);
            string fullName = dgvEmployees.SelectedRows[0].Cells["EmployeeName"].Value.ToString();
            string username = dgvEmployees.SelectedRows[0].Cells["Username"].Value.ToString();

            // Check if already resigned
            if (fullName.StartsWith("[RESIGNED]"))
            {
                ShowError("Employee is already resigned!");
                return;
            }

            // 1. Initial Confirmation
            DialogResult result = MessageBox.Show($"Are you sure to mark employee '{fullName}' as Resigned?\nThis will BLOCK their login access immediately.",
                "Confirm Resign", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                // 2. Security Check: Require Admin Password
                using (var passForm = new FormConfirmPassword($"To RESIGN '{username}', enter Admin Password:"))
                {
                    if (passForm.ShowDialog() == DialogResult.OK)
                    {
                        string inputPass = passForm.Password;
                        
                        // Verify Admin Password
                        if (VerifyAdminPassword(inputPass)) // Helper method to check DB
                        {
                            // Soft Delete: Add [RESIGNED] prefix to Name and Username
                            string newName = "[RESIGNED] " + fullName;
                            string newUsername = "[RESIGNED] " + username;

                            if (UpdateEmployeeStatus(employeeId, newName, newUsername))
                            {
                                ShowSuccess("Employee resigned successfully!");
                                LoadEmployees();
                                ClearInputFields();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Incorrect Admin Password! Action cancelled.", "Security Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private bool VerifyAdminPassword(string password)
        {
            try
            {
                if (string.IsNullOrEmpty(CurrentUsername)) return false; // Should not happen if passed correctly

                string query = "SELECT COUNT(*) FROM Employees WHERE Username = @User AND Password = @Pass";
                SqlParameter[] p = {
                    new SqlParameter("@User", CurrentUsername),
                    new SqlParameter("@Pass", password)
                };
                return Convert.ToInt32(DatabaseConnection.ExecuteScalar(query, p)) > 0;
            }
            catch
            {
                return false;
            }
        }

        private void btnResetPassword_Click(object sender, EventArgs e)
        {
            ShowResetPasswordDialog();
        }



        private bool UpdateEmployeeStatus(int id, string name, string username)
        {
            try
            {
                string query = "UPDATE Employees SET EmployeeName = @Name, Username = @User WHERE EmployeeId = @Id";
                SqlParameter[] p = {
                    new SqlParameter("@Name", name),
                    new SqlParameter("@User", username),
                    new SqlParameter("@Id", id)
                };
                DatabaseConnection.ExecuteNonQuery(query, p);
                return true;
            }
            catch (Exception ex)
            {
                ShowError("Error updating status: " + ex.Message);
                return false;
            }
        }



        /// <summary>
        /// Handle Search button click event
        /// </summary>
        private void btnSearch_Click(object sender, EventArgs e)
        {

            string keyword = txtSearch.Text.Trim();
            if (string.IsNullOrEmpty(keyword))
            {
                LoadEmployees();
            }
            else
            {
                SearchEmployees(keyword);
            }
        }

        /// <summary>
        /// Search employees by keyword
        /// </summary>
        private void SearchEmployees(string keyword)
        {
            string query = @"SELECT EmployeeID, EmployeeName, Position, AuthorityLevel, Username, Password 
                             FROM Employees 
                             WHERE EmployeeName LIKE @Keyword OR Username LIKE @Keyword";
            SqlParameter[] parameter =
            {
                new SqlParameter("@Keyword", "%" + keyword + "%")

            };
            DataTable employeesDataTable = DatabaseConnection.ExecuteQuery(query, parameter);
            dgvEmployees.DataSource = employeesDataTable;

        }

        /// <summary>
        /// Validate input data
        /// </summary>
        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                MessageBox.Show("Enter employee name!");
                txtFullName.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show("Enter username!");
                txtUsername.Focus();
                return false;
            }
            if (txtUsername.Text.Length < 4)
            {
                MessageBox.Show("Username must be at least 4 characters!");
                txtUsername.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Enter password!");
                txtPassword.Focus();
                return false;
            }
            if (txtPassword.Text.Length < 6)
            {
                MessageBox.Show("Password must be at least 6 characters!");
                txtPassword.Focus();
                return false;
            }
            if (cbRoleSelection.SelectedIndex == -1)
            {
                MessageBox.Show("Select a role!");
                cbRoleSelection.Focus();
                return false;
            }
            return true;
        }

        /// <summary>
        /// Clear input fields
        /// </summary>
        private void ClearInputFields()
        {
            txtConfirmPassword.Clear();
            txtPassword.Clear();
            txtUsername.Clear();
            txtFullName.Clear();
            cbRoleSelection.SelectedIndex = -1;
            
        }

        /// <summary>
        /// Hash password (simple using SHA256)
        /// </summary>
        private string HashPassword(string password)
        {

            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(bytes);
            }
        }

        /// <summary>
        /// Handle row click in DataGridView
        /// </summary>
        private void dgvEmployees_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && dgvEmployees.SelectedRows.Count > 0)
                {
                    DataGridViewRow row = dgvEmployees.SelectedRows[0];
                    txtFullName.Text = row.Cells["EmployeeName"].Value?.ToString();
                    txtUsername.Text = row.Cells["Username"].Value?.ToString();
                    
                    // Clear password fields - user must enter new password for security
                    txtPassword.Text = "";
                    txtConfirmPassword.Text = "";
                    
                    // Set Position in ComboBox
                    string position = row.Cells["Position"].Value?.ToString();
                    cbRoleSelection.SelectedItem = position;
                    
                    // Set AuthorityLevel in ComboBox
                    string authorityLevel = row.Cells["AuthorityLevel"].Value?.ToString();
                    cbAuthorityLevel.SelectedItem = authorityLevel;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateInput())
                {
                    return;
                }
                string fullName = txtFullName.Text.Trim();
                string username = txtUsername.Text.Trim();
                string position = cbRoleSelection.Text.Trim();
                int authorityLevel = int.Parse(cbAuthorityLevel.Text);
                
                if (txtConfirmPassword.Text != txtPassword.Text)
                {
                    ShowError("Passwords do not match!");
                    txtConfirmPassword.Focus();
                    return;
                }
                string password = txtPassword.Text;
                
                if (AddEmployeeToDatabase(fullName, username, position, authorityLevel, password))
                {
                    ShowSuccess("Employee added successfully!");
                    LoadEmployees();
                    ClearInputFields();
                }
            }
            catch (Exception ex)
            {
                // Check for duplicate username error
                if (ex.Message.Contains("UNIQUE KEY") || ex.Message.Contains("duplicate"))
                {
                    ShowError("Username already exists! Please try another.");
                    txtUsername.Focus();
                    txtUsername.SelectAll();
                }
                else
                {
                    ShowError("Add failed! Please try again.");
                }
            }
        }

        /// <summary>
        /// Reset form and reload data
        /// </summary>
        private void btnReset_Click(object sender, EventArgs e)
        {
            ClearInputFields();
            LoadEmployees();
            txtSearch.Text = "Search...";
        }

        /// <summary>
        /// Search when text changes
        /// </summary>
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();
            if (keyword == "Search..." || string.IsNullOrEmpty(keyword))
            {
                LoadEmployees();
            }
            else
            {
                SearchEmployees(keyword);
            }
        }

        /// <summary>
        /// Clear placeholder when textbox gets focus
        /// </summary>
        private void txtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Search...")
            {
                txtSearch.Text = "";
            }
        }

        /// <summary>
        /// Restore placeholder when textbox loses focus
        /// </summary>
        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                txtSearch.Text = "Search...";
            }
        }

        /// <summary>
        /// Filter by role when ComboBox selection changes
        /// </summary>
        private void cboRoleFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedRole = cboRoleFilter.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(selectedRole) || selectedRole == "All")
            {
                LoadEmployees();
            }
            else
            {
                FilterByRole(selectedRole);
            }
        }

        /// <summary>
        /// Filter employees by role/position
        /// </summary>
        private void FilterByRole(string role)
        {
            try
            {
                string query = @"SELECT EmployeeID, EmployeeName, Position, AuthorityLevel, Username 
                                 FROM Employees 
                                 WHERE Position = @Role";
                SqlParameter[] parameters = { new SqlParameter("@Role", role) };
                DataTable dt = DatabaseConnection.ExecuteQuery(query, parameters);
                dgvEmployees.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error filtering: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Show Reset Password dialog for selected employee
        /// </summary>
        public void ShowResetPasswordDialog()
        {
            if (dgvEmployees.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an employee!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int employeeId = Convert.ToInt32(dgvEmployees.SelectedRows[0].Cells["EmployeeID"].Value);
            string employeeName = dgvEmployees.SelectedRows[0].Cells["EmployeeName"].Value?.ToString();

            using (Form dialog = new Form())
            {
                dialog.Text = "Reset Password - " + employeeName;
                dialog.Size = new Size(400, 220);
                dialog.StartPosition = FormStartPosition.CenterParent;
                dialog.FormBorderStyle = FormBorderStyle.FixedDialog;
                dialog.MaximizeBox = false;
                dialog.MinimizeBox = false;
                dialog.BackColor = Color.White;

                Label lblTitle = new Label() 
                { 
                    Text = "🔐 Reset Password for " + employeeName, 
                    Location = new Point(20, 15), 
                    Font = new Font("Segoe UI", 11, FontStyle.Bold),
                    AutoSize = true 
                };

                Label lblNew = new Label() { Text = "New Password:", Location = new Point(20, 60), AutoSize = true };
                TextBox txtNew = new TextBox() { Location = new Point(150, 57), Width = 200, PasswordChar = '•' };

                Label lblConfirm = new Label() { Text = "Confirm Password:", Location = new Point(20, 100), AutoSize = true };
                TextBox txtConfirm = new TextBox() { Location = new Point(150, 97), Width = 200, PasswordChar = '•' };

                Button btnSave = new Button() 
                { 
                    Text = "Reset Password", 
                    Location = new Point(100, 140), 
                    Width = 120, 
                    Height = 35,
                    BackColor = Color.FromArgb(220, 53, 69),
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat
                };
                Button btnCancel = new Button() 
                { 
                    Text = "Cancel", 
                    Location = new Point(230, 140), 
                    Width = 100, 
                    Height = 35,
                    DialogResult = DialogResult.Cancel 
                };

                btnSave.Click += (s, args) =>
                {
                    if (string.IsNullOrEmpty(txtNew.Text) || string.IsNullOrEmpty(txtConfirm.Text))
                    {
                        MessageBox.Show("Please fill all fields!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (txtNew.Text.Length < 6)
                    {
                        MessageBox.Show("Password must be at least 6 characters!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (txtNew.Text != txtConfirm.Text)
                    {
                        MessageBox.Show("Passwords do not match!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Update password
                    string updateQuery = "UPDATE Employees SET Password = @NewPassword WHERE EmployeeId = @EmployeeId";
                    SqlParameter[] updateParams = {
                        new SqlParameter("@NewPassword", txtNew.Text),
                        new SqlParameter("@EmployeeId", employeeId)
                    };
                    DatabaseConnection.ExecuteNonQuery(updateQuery, updateParams);

                    MessageBox.Show("Password reset successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dialog.DialogResult = DialogResult.OK;
                    dialog.Close();
                };

                dialog.Controls.AddRange(new Control[] { lblTitle, lblNew, txtNew, lblConfirm, txtConfirm, btnSave, btnCancel });
                dialog.AcceptButton = btnSave;
                dialog.CancelButton = btnCancel;
                dialog.ShowDialog();
            }
        }
    }
}

