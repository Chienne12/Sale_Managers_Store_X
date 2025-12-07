using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Store_X_s_Sales_Management_System.Forms.Sales
{
    public partial class SalesDashboard : Form
    {
        private string currentUsername;

        public SalesDashboard()
        {
            InitializeComponent();
            // Open full screen
            this.WindowState = FormWindowState.Maximized;
        }

        // Constructor receives username from Login
        public SalesDashboard(string username) : this()
        {
            currentUsername = username;
            lblWelcome.Text = "Welcome, " + username;
            
            // Load default dashboard view with username
            var dashboard = new UserControls.ucSalesDashboardHome();
            dashboard.SetUsername(username);
            LoadUserControl(dashboard);
            
            // Load sales statistics
            LoadSalesStatistics();
        }

        /// <summary>
        /// Load sales statistics for info bar
        /// </summary>
        private void LoadSalesStatistics()
        {
            try
            {
                // Get employee ID
                string empQuery = "SELECT EmployeeId FROM Employees WHERE Username = @Username";
                SqlParameter[] empParams = { new SqlParameter("@Username", currentUsername) };
                object empResult = DatabaseConnection.ExecuteScalar(empQuery, empParams);
                
                if (empResult != null)
                {
                    int employeeId = Convert.ToInt32(empResult);
                    
                    // Get today's sales for this employee
                    string salesQuery = @"SELECT ISNULL(SUM(TotalAmount), 0) FROM Orders 
                        WHERE EmployeeId = @EmployeeId 
                        AND CAST(OrderDate AS DATE) = CAST(GETDATE() AS DATE)
                        AND OrderStatus = 'Completed'";
                    SqlParameter[] salesParams = { new SqlParameter("@EmployeeId", employeeId) };
                    object salesResult = DatabaseConnection.ExecuteScalar(salesQuery, salesParams);
                    decimal todaySales = Convert.ToDecimal(salesResult);
                    lblTodaySales.Text = "Today: " + todaySales.ToString("N0") + " VND";
                    
                    // Get rank among employees today
                    string rankQuery = @"SELECT COUNT(*) + 1 FROM (
                        SELECT EmployeeId, SUM(TotalAmount) as TotalSales 
                        FROM Orders 
                        WHERE CAST(OrderDate AS DATE) = CAST(GETDATE() AS DATE) 
                        AND OrderStatus = 'Completed'
                        GROUP BY EmployeeId
                        HAVING SUM(TotalAmount) > (
                            SELECT ISNULL(SUM(TotalAmount), 0) FROM Orders 
                            WHERE EmployeeId = @EmployeeId 
                            AND CAST(OrderDate AS DATE) = CAST(GETDATE() AS DATE)
                            AND OrderStatus = 'Completed'
                        )
                    ) AS BetterEmployees";
                    SqlParameter[] rankParams = { new SqlParameter("@EmployeeId", employeeId) };
                    object rankResult = DatabaseConnection.ExecuteScalar(rankQuery, rankParams);
                    int rank = Convert.ToInt32(rankResult);
                    lblCurrentRank.Text = "Rank: #" + rank + " today";
                }
            }
            catch (Exception ex)
            {
                lblTodaySales.Text = "Today: 0 VND";
                lblCurrentRank.Text = "Rank: N/A";
            }
        }

        /// <summary>
        /// Loads a UserControl into the main panel
        /// </summary>
        private void LoadUserControl(UserControl control)
        {
            // Clear existing controls
            pnlMain.Controls.Clear();
            
            // Set dock to fill entire panel
            control.Dock = DockStyle.Fill;
            
            // Add new control
            pnlMain.Controls.Add(control);
            control.BringToFront();
        }

        /// <summary>
        /// Show Change Password dialog
        /// </summary>
        private void ShowChangePasswordDialog()
        {
            using (Form dialog = new Form())
            {
                dialog.Text = "Change Password";
                dialog.Size = new Size(400, 280);
                dialog.StartPosition = FormStartPosition.CenterParent;
                dialog.FormBorderStyle = FormBorderStyle.FixedDialog;
                dialog.MaximizeBox = false;
                dialog.MinimizeBox = false;
                dialog.BackColor = Color.White;

                Label lblTitle = new Label() 
                { 
                    Text = "🔐 Change Password", 
                    Location = new Point(20, 15), 
                    Font = new Font("Segoe UI", 14, FontStyle.Bold),
                    AutoSize = true 
                };

                Label lblCurrent = new Label() { Text = "Current Password:", Location = new Point(20, 60), AutoSize = true };
                TextBox txtCurrent = new TextBox() { Location = new Point(170, 57), Width = 180, PasswordChar = '•' };

                Label lblNew = new Label() { Text = "New Password:", Location = new Point(20, 100), AutoSize = true };
                TextBox txtNew = new TextBox() { Location = new Point(170, 97), Width = 180, PasswordChar = '•' };

                Label lblConfirm = new Label() { Text = "Confirm Password:", Location = new Point(20, 140), AutoSize = true };
                TextBox txtConfirm = new TextBox() { Location = new Point(170, 137), Width = 180, PasswordChar = '•' };

                Button btnSave = new Button() 
                { 
                    Text = "Save", 
                    Location = new Point(100, 190), 
                    Width = 100, 
                    Height = 35,
                    BackColor = Color.FromArgb(40, 167, 69),
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat
                };
                Button btnCancel = new Button() 
                { 
                    Text = "Cancel", 
                    Location = new Point(210, 190), 
                    Width = 100, 
                    Height = 35,
                    DialogResult = DialogResult.Cancel 
                };

                btnSave.Click += (s, args) =>
                {
                    if (string.IsNullOrEmpty(txtCurrent.Text) || string.IsNullOrEmpty(txtNew.Text) || string.IsNullOrEmpty(txtConfirm.Text))
                    {
                        MessageBox.Show("Please fill all fields!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (txtNew.Text.Length < 6)
                    {
                        MessageBox.Show("New password must be at least 6 characters!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (txtNew.Text != txtConfirm.Text)
                    {
                        MessageBox.Show("New passwords do not match!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Verify current password
                    string verifyQuery = "SELECT COUNT(*) FROM Employees WHERE Username = @Username AND Password = @Password";
                    SqlParameter[] verifyParams = { 
                        new SqlParameter("@Username", currentUsername),
                        new SqlParameter("@Password", txtCurrent.Text)
                    };
                    object result = DatabaseConnection.ExecuteScalar(verifyQuery, verifyParams);

                    if (Convert.ToInt32(result) == 0)
                    {
                        MessageBox.Show("Current password is incorrect!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Update password
                    string updateQuery = "UPDATE Employees SET Password = @NewPassword WHERE Username = @Username";
                    SqlParameter[] updateParams = {
                        new SqlParameter("@NewPassword", txtNew.Text),
                        new SqlParameter("@Username", currentUsername)
                    };
                    DatabaseConnection.ExecuteNonQuery(updateQuery, updateParams);

                    MessageBox.Show("Password changed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dialog.DialogResult = DialogResult.OK;
                    dialog.Close();
                };

                dialog.Controls.AddRange(new Control[] { lblTitle, lblCurrent, txtCurrent, lblNew, txtNew, lblConfirm, txtConfirm, btnSave, btnCancel });
                dialog.AcceptButton = btnSave;
                dialog.CancelButton = btnCancel;
                dialog.ShowDialog();
            }
        }

        private void SalesDashboard_Load(object sender, EventArgs e)
        {
            // Set up button events
            // Button events are now handled by explicit methods (btnDashboard_Click)
            // btnDashboard subscription moved to Designer

            btnManagerOder.Click += (s, args) => LoadUserControl(new Forms.Shared.UserControls.ucManageOrders());
            btnManagerProducts.Click += (s, args) => LoadUserControl(new Forms.Shared.UserControls.ucManageProducts());
            btnManagerCustomers.Click += (s, args) => LoadUserControl(new Forms.Admin.UserControls.ucManageCustomers());
            
            // Change Password - clicking on Welcome label
            lblWelcome.Cursor = Cursors.Hand;
            lblWelcome.Click += (s, args) => ShowChangePasswordDialog();
            
            // Add Change Password button to menu panel
            Button btnChangePass = new Button()
            {
                Text = "🔐 Change Password",
                Location = new Point(10, 310),
                Size = new Size(162, 40),
                BackColor = Color.FromArgb(255, 193, 7),
                ForeColor = Color.Black,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold)
            };
            btnChangePass.Click += (s, args) => ShowChangePasswordDialog();
            pnlMenu.Controls.Add(btnChangePass);
            
            btnLogout.Click += (s, args) => 
            {
                this.Hide();
                // Re-open Login form
                var loginForm = new Login();
                loginForm.Show();
            };
        }
/// <summary>
        /// Handle Dashboard button click
        /// </summary>
        private void btnDashboard_Click(object sender, EventArgs e)
        {
            var dashboard = new UserControls.ucSalesDashboardHome();
            dashboard.SetUsername(currentUsername);
            LoadUserControl(dashboard);
            LoadSalesStatistics(); // Refresh stats when going back to dashboard
        }
    }
}


