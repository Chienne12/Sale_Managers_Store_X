using System;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.IO;
using System.Text;

namespace Store_X_s_Sales_Management_System.Forms.Admin.UserControls
{
    public partial class ucManageCustomers : UserControl
    {
        private DataTable customersDataTable;

        public ucManageCustomers()
        {
            InitializeComponent();
            InitializeUserControl();
        }

        /// <summary>
        /// Initialize user control settings
        /// </summary>
        private void InitializeUserControl()
        {
            try
            {
                // Setup DataGridView properties
                dgvCustomers.ReadOnly = true;
                dgvCustomers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvCustomers.MultiSelect = false;
                dgvCustomers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                dgvHistory.ReadOnly = true;
                dgvHistory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvHistory.MultiSelect = false;
                dgvHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                // Wire up events
                dgvCustomers.CellClick += dgvCustomers_CellClick;
                txtSearch.TextChanged += txtSearch_TextChanged;
                txtSearch.Enter += txtSearch_Enter;
                txtSearch.Leave += txtSearch_Leave;
                
                // Wire up button click events
                btnAdd.Click += btnAdd_Click;
                btnEdit.Click += btnEdit_Click;
                btnDelete.Click += btnDelete_Click;
                btnReactivate.Click += btnReactivate_Click;

                // Load initial data
                LoadCustomers();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error initializing: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Load customers list from database
        /// </summary>
        private void LoadCustomers()
        {
            try
            {
                // Query customers with order statistics
                string query = @"SELECT 
                    c.CustomerId,
                    c.CustomerName,
                    c.CustomerPhone,
                    c.CustomerEmail,
                    c.CustomerAddress,
                    COUNT(o.OrderId) AS TotalOrders,
                    ISNULL(SUM(o.TotalAmount), 0) AS TotalSpent
                FROM Customers c
                LEFT JOIN Orders o ON c.CustomerId = o.CustomerId AND o.OrderStatus = 'Completed'
                GROUP BY c.CustomerId, c.CustomerName, c.CustomerPhone, c.CustomerEmail, c.CustomerAddress
                ORDER BY c.CustomerName";

                customersDataTable = DatabaseConnection.ExecuteQuery(query, null);

                // Clear existing rows and bind data manually
                dgvCustomers.Rows.Clear();
                foreach (DataRow row in customersDataTable.Rows)
                {
                    string customerName = row["CustomerName"].ToString();
                    bool isInactive = customerName.StartsWith("[INACTIVE]");
                    
                    int rowIndex = dgvCustomers.Rows.Add(
                        row["CustomerId"],
                        customerName,
                        row["CustomerPhone"],
                        row["CustomerEmail"] ?? "",
                        row["CustomerAddress"],
                        row["TotalOrders"],
                        Convert.ToDecimal(row["TotalSpent"]).ToString("N0")
                    );
                    
                    // Style inactive customers with gray background
                    if (isInactive)
                    {
                        dgvCustomers.Rows[rowIndex].DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(245, 245, 245);
                        dgvCustomers.Rows[rowIndex].DefaultCellStyle.ForeColor = System.Drawing.Color.Gray;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading customers: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Search customers by name or phone
        /// </summary>
        private void SearchCustomers(string keyword)
        {
            try
            {
                string query = @"SELECT 
                    c.CustomerId,
                    c.CustomerName,
                    c.CustomerPhone,
                    c.CustomerEmail,
                    c.CustomerAddress,
                    COUNT(o.OrderId) AS TotalOrders,
                    ISNULL(SUM(o.TotalAmount), 0) AS TotalSpent
                FROM Customers c
                LEFT JOIN Orders o ON c.CustomerId = o.CustomerId AND o.OrderStatus = 'Completed'
                WHERE c.CustomerName LIKE @Keyword 
                   OR c.CustomerPhone LIKE @Keyword 
                   OR c.CustomerEmail LIKE @Keyword
                GROUP BY c.CustomerId, c.CustomerName, c.CustomerPhone, c.CustomerEmail, c.CustomerAddress
                ORDER BY c.CustomerName";

                SqlParameter[] parameters = { new SqlParameter("@Keyword", "%" + keyword + "%") };
                DataTable dt = DatabaseConnection.ExecuteQuery(query, parameters);

                dgvCustomers.Rows.Clear();
                foreach (DataRow row in dt.Rows)
                {
                    string customerName = row["CustomerName"].ToString();
                    bool isInactive = customerName.StartsWith("[INACTIVE]");

                    int rowIndex = dgvCustomers.Rows.Add(
                        row["CustomerId"],
                        customerName,
                        row["CustomerPhone"],
                        row["CustomerEmail"] ?? "",
                        row["CustomerAddress"],
                        row["TotalOrders"],
                        Convert.ToDecimal(row["TotalSpent"]).ToString("N0")
                    );

                    // Style inactive customers with gray background
                    if (isInactive)
                    {
                        dgvCustomers.Rows[rowIndex].DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(245, 245, 245);
                        dgvCustomers.Rows[rowIndex].DefaultCellStyle.ForeColor = System.Drawing.Color.Gray;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error searching: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Load purchase history for selected customer
        /// </summary>
        private void LoadCustomerHistory(int customerId)
        {
            try
            {
                string query = @"SELECT 
                    o.OrderId,
                    o.OrderDate,
                    COUNT(od.ProductId) AS ItemCount,
                    o.TotalAmount,
                    o.OrderStatus
                FROM Orders o
                LEFT JOIN OrderDetails od ON o.OrderId = od.OrderId
                WHERE o.CustomerId = @CustomerId
                GROUP BY o.OrderId, o.OrderDate, o.TotalAmount, o.OrderStatus
                ORDER BY o.OrderDate DESC";

                SqlParameter[] parameters = { new SqlParameter("@CustomerId", customerId) };
                DataTable dt = DatabaseConnection.ExecuteQuery(query, parameters);

                dgvHistory.Rows.Clear();
                foreach (DataRow row in dt.Rows)
                {
                    dgvHistory.Rows.Add(
                        row["OrderId"],
                        Convert.ToDateTime(row["OrderDate"]).ToString("dd/MM/yyyy HH:mm"),
                        row["ItemCount"].ToString() + " items",
                        Convert.ToDecimal(row["TotalAmount"]).ToString("N0"),
                        row["OrderStatus"]
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading history: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Handle customer row click - load purchase history
        /// </summary>
        private void dgvCustomers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && dgvCustomers.SelectedRows.Count > 0)
                {
                    int customerId = Convert.ToInt32(dgvCustomers.SelectedRows[0].Cells["colCustomerId"].Value);
                    LoadCustomerHistory(customerId);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Search when text changes
        /// </summary>
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();
            if (keyword == "Search by Phone/Name" || string.IsNullOrEmpty(keyword))
            {
                LoadCustomers();
            }
            else
            {
                SearchCustomers(keyword);
            }
        }

        /// <summary>
        /// Clear placeholder on focus
        /// </summary>
        private void txtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Search by Phone/Name")
            {
                txtSearch.Text = "";
            }
        }

        /// <summary>
        /// Restore placeholder on blur
        /// </summary>
        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                txtSearch.Text = "Search by Phone/Name";
            }
        }

        /// <summary>
        /// Handle Add button click - show input dialog
        /// </summary>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Show simple input dialog for adding customer
            using (Form dialog = CreateCustomerDialog("Add New Customer", "", "", "", ""))
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    LoadCustomers();
                }
            }
        }

        /// <summary>
        /// Handle Edit button click
        /// </summary>
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvCustomers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a customer to edit!", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var row = dgvCustomers.SelectedRows[0];
            string name = row.Cells["colName"].Value?.ToString() ?? "";

            if (name.StartsWith("[INACTIVE]"))
            {
                MessageBox.Show("Cannot edit an inactive customer! Please reactivate first.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string phone = row.Cells["colPhone"].Value?.ToString() ?? "";
            string email = row.Cells["colEmail"].Value?.ToString() ?? "";
            string address = row.Cells["colAddress"].Value?.ToString() ?? "";
            int customerId = Convert.ToInt32(row.Cells["colCustomerId"].Value);

            using (Form dialog = CreateCustomerDialog("Edit Customer", name, phone, email, address, customerId))
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    LoadCustomers();
                }
            }
        }

        /// <summary>
        /// Handle Delete button click - Soft delete (mark as inactive)
        /// </summary>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvCustomers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a customer!", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int customerId = Convert.ToInt32(dgvCustomers.SelectedRows[0].Cells["colCustomerId"].Value);
            string customerName = dgvCustomers.SelectedRows[0].Cells["colName"].Value?.ToString();
            
            // Check if already inactive
            if (customerName.StartsWith("[INACTIVE]"))
            {
                MessageBox.Show("This customer is already inactive!", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult result = MessageBox.Show(
                $"Are you sure you want to deactivate customer '{customerName}'?",
                "Confirm Deactivation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    // Soft delete: Add [Stop] prefix to CustomerName
                    string newName = "[INACTIVE] " + customerName;
                    string query = "UPDATE Customers SET CustomerName = @NewName WHERE CustomerId = @CustomerId";
                    SqlParameter[] parameters = { 
                        new SqlParameter("@NewName", newName),
                        new SqlParameter("@CustomerId", customerId) 
                    };
                    DatabaseConnection.ExecuteNonQuery(query, parameters);
                    MessageBox.Show("Customer deactivated successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadCustomers();
                    dgvHistory.Rows.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        
        /// <summary>
        /// Reactivate inactive customer
        /// </summary>
        private void btnReactivate_Click(object sender, EventArgs e)
        {
            if (dgvCustomers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a customer!", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int customerId = Convert.ToInt32(dgvCustomers.SelectedRows[0].Cells["colCustomerId"].Value);
            string customerName = dgvCustomers.SelectedRows[0].Cells["colName"].Value?.ToString();
            
            // Check if actually inactive
            if (!customerName.StartsWith("[INACTIVE]"))
            {
                MessageBox.Show("This customer is active!", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string originalName = customerName.Replace("[INACTIVE] ", "");
            DialogResult result = MessageBox.Show(
                $"Do you want to reactivate customer '{originalName}'?",
                "Confirm Reactivation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    // Reactivate: Remove [STOP] prefix
                    string query = "UPDATE Customers SET CustomerName = @NewName WHERE CustomerId = @CustomerId";
                    SqlParameter[] parameters = { 
                        new SqlParameter("@NewName", originalName),
                        new SqlParameter("@CustomerId", customerId) 
                    };
                    DatabaseConnection.ExecuteNonQuery(query, parameters);
                    MessageBox.Show("Customer reactivated successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadCustomers();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Create customer input dialog
        /// </summary>
        private Form CreateCustomerDialog(string title, string name, string phone, string email, string address, int customerId = 0)
        {
            Form dialog = new Form()
            {
                Text = title,
                Size = new System.Drawing.Size(400, 300),
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false
            };

            Label lblName = new Label() { Text = "Name:", Location = new System.Drawing.Point(20, 20), AutoSize = true };
            TextBox txtName = new TextBox() { Text = name, Location = new System.Drawing.Point(120, 17), Width = 240 };

            Label lblPhone = new Label() { Text = "Phone:", Location = new System.Drawing.Point(20, 55), AutoSize = true };
            TextBox txtPhone = new TextBox() { Text = phone, Location = new System.Drawing.Point(120, 52), Width = 240 };

            Label lblEmail = new Label() { Text = "Email:", Location = new System.Drawing.Point(20, 90), AutoSize = true };
            TextBox txtEmail = new TextBox() { Text = email, Location = new System.Drawing.Point(120, 87), Width = 240 };

            Label lblAddress = new Label() { Text = "Address:", Location = new System.Drawing.Point(20, 125), AutoSize = true };
            TextBox txtAddress = new TextBox() { Text = address, Location = new System.Drawing.Point(120, 122), Width = 240 };

            Button btnSave = new Button() { Text = "Save", Location = new System.Drawing.Point(120, 180), Width = 100, DialogResult = DialogResult.None };
            Button btnCancel = new Button() { Text = "Cancel", Location = new System.Drawing.Point(230, 180), Width = 100, DialogResult = DialogResult.Cancel };

            btnSave.Click += (s, ev) =>
            {
                // Validate
                if (string.IsNullOrWhiteSpace(txtName.Text))
                {
                    MessageBox.Show("Please enter customer name!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtName.Focus();
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtPhone.Text) || !Regex.IsMatch(txtPhone.Text, @"^[0-9]{10,11}$"))
                {
                    MessageBox.Show("Please enter valid phone number (10-11 digits)!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPhone.Focus();
                    return;
                }
                if (!string.IsNullOrWhiteSpace(txtEmail.Text) && !Regex.IsMatch(txtEmail.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                {
                    MessageBox.Show("Please enter valid email address!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEmail.Focus();
                    return;
                }

                try
                {
                    if (customerId == 0)
                    {
                        // Insert new customer
                        string query = @"INSERT INTO Customers (CustomerName, CustomerPhone, CustomerEmail, CustomerAddress) 
                                        VALUES (@Name, @Phone, @Email, @Address)";
                        SqlParameter[] parameters = {
                            new SqlParameter("@Name", txtName.Text.Trim()),
                            new SqlParameter("@Phone", txtPhone.Text.Trim()),
                            new SqlParameter("@Email", string.IsNullOrWhiteSpace(txtEmail.Text) ? (object)DBNull.Value : txtEmail.Text.Trim()),
                            new SqlParameter("@Address", txtAddress.Text.Trim())
                        };
                        DatabaseConnection.ExecuteNonQuery(query, parameters);
                        MessageBox.Show("Customer added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        // Update existing customer
                        string query = @"UPDATE Customers 
                                        SET CustomerName = @Name, CustomerPhone = @Phone, CustomerEmail = @Email, CustomerAddress = @Address 
                                        WHERE CustomerId = @CustomerId";
                        SqlParameter[] parameters = {
                            new SqlParameter("@Name", txtName.Text.Trim()),
                            new SqlParameter("@Phone", txtPhone.Text.Trim()),
                            new SqlParameter("@Email", string.IsNullOrWhiteSpace(txtEmail.Text) ? (object)DBNull.Value : txtEmail.Text.Trim()),
                            new SqlParameter("@Address", txtAddress.Text.Trim()),
                            new SqlParameter("@CustomerId", customerId)
                        };
                        DatabaseConnection.ExecuteNonQuery(query, parameters);
                        MessageBox.Show("Customer updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    dialog.DialogResult = DialogResult.OK;
                    dialog.Close();
                }
                catch (Exception ex)
                {
                    if (ex.Message.Contains("UNIQUE") || ex.Message.Contains("duplicate"))
                    {
                        MessageBox.Show("Phone number or email already exists!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("Error saving: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            };

            dialog.Controls.AddRange(new Control[] { lblName, txtName, lblPhone, txtPhone, lblEmail, txtEmail, lblAddress, txtAddress, btnSave, btnCancel });
            dialog.AcceptButton = btnSave;
            dialog.CancelButton = btnCancel;

            return dialog;
        }

        /// <summary>
        /// Validate phone number format
        /// </summary>
        private bool IsValidPhone(string phone)
        {
            return Regex.IsMatch(phone, @"^[0-9]{10,11}$");
        }

        /// <summary>
        /// Validate email format
        /// </summary>
        private bool IsValidEmail(string email)
        {
            return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvCustomers.Rows.Count == 0)
                {
                    MessageBox.Show("No data to export!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
                saveDialog.FileName = $"Customers_{DateTime.Now:yyyyMMdd_HHmmss}.csv";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    StringBuilder sb = new StringBuilder();

                    // Headers
                    string[] headers = new string[dgvCustomers.Columns.Count];
                    for (int i = 0; i < dgvCustomers.Columns.Count; i++)
                    {
                        headers[i] = dgvCustomers.Columns[i].HeaderText;
                    }
                    sb.AppendLine(string.Join(",", headers));

                    // Rows
                    foreach (DataGridViewRow row in dgvCustomers.Rows)
                    {
                        if (row.IsNewRow) continue;
                        string[] cells = new string[row.Cells.Count];
                        for (int i = 0; i < row.Cells.Count; i++)
                        {
                            cells[i] = row.Cells[i].Value?.ToString().Replace(",", ";") ?? "";
                        }
                        sb.AppendLine(string.Join(",", cells));
                    }

                    File.WriteAllText(saveDialog.FileName, sb.ToString(), Encoding.UTF8);
                    MessageBox.Show($"Export successful!\nSaved to: {saveDialog.FileName}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    // Open file
                    System.Diagnostics.Process.Start(saveDialog.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error exporting: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
