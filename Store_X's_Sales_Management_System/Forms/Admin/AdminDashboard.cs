using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Store_X_s_Sales_Management_System.Forms.Admin
{
    public partial class AdminDashboard : Form
    {
        private string currentUsername;

        public AdminDashboard()
        {
            InitializeComponent();
            // Open full screen
            this.WindowState = FormWindowState.Maximized;
            // Load default dashboard view
            LoadUserControl(new UserControls.ucDashboardHome());
        }

        // Constructor receiving username from Login
        public AdminDashboard(string username) : this()
        {
            currentUsername = username;
            
            lblWelcome.Text = "Welcome, " + username;
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

        private void AdminDashboard_Load(object sender, EventArgs e)
        {
            // Set up button events - already registered in Designer so re-registering btnDashboard is not needed
            btnManagerEmployees.Click += (s, args) => LoadUserControl(new Forms.Admin.UserControls.ucManageEmployees() { CurrentUsername = this.currentUsername });
            btnManagerOrder.Click += (s, args) => LoadUserControl(new Forms.Shared.UserControls.ucManageOrders());
            btnManagerCustomers.Click += (s, args) => LoadUserControl(new Forms.Admin.UserControls.ucManageCustomers());
            btnManagerProducts.Click += (s, args) => LoadUserControl(new Forms.Shared.UserControls.ucManageProducts());
            btnReports.Click += (s, args) => LoadUserControl(new Forms.Admin.UserControls.ucReports());
            
            btnLogout.Click += (s, args) => 
            {
                this.Hide();
                // Re-open Login form
                var loginForm = new Login();
                loginForm.Show();
            };
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            LoadUserControl(new UserControls.ucDashboardHome());
        }
    }
}
