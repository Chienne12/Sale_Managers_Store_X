using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Store_X_s_Sales_Management_System.Forms.Shared.UserControls
{
    public partial class ucManageOrders : UserControl
    {
        private DataTable ordersDataTable;

        public ucManageOrders()
        {
            InitializeComponent();
            InitializeUserControl();
        }

        /// <summary>
        /// Initialize UserControl
        /// </summary>
        private void InitializeUserControl()
        {
            try
            {
                // Setup DataGridView
                dgvOrders.ReadOnly = true;
                dgvOrders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvOrders.MultiSelect = false;

                dgvOrderDetails.ReadOnly = true;
                dgvOrderDetails.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                // Load Status filter
                cboStatus.Items.Clear();
                cboStatus.Items.Add("All");
                cboStatus.Items.Add("Pending");
                cboStatus.Items.Add("Completed");
                cboStatus.Items.Add("Cancelled");
                cboStatus.SelectedIndex = 0;

                // Load Employee filter
                LoadEmployeeFilter();

                // Wire up events
                dgvOrders.CellClick += dgvOrders_CellClick;
                dgvOrders.CellFormatting += dgvOrders_CellFormatting;
                cboStatus.SelectedIndexChanged += cboStatus_SelectedIndexChanged;
                cboEmployee.SelectedIndexChanged += cboEmployee_SelectedIndexChanged;
                dtpDate.ValueChanged += dtpDate_ValueChanged;
                txtSearch.TextChanged += txtSearch_TextChanged;
                txtSearch.Enter += txtSearch_Enter;
                txtSearch.Leave += txtSearch_Leave;
                btnAdd.Click += btnAdd_Click;
                btnEdit.Click += btnEdit_Click;
                btnDelete.Click += btnDelete_Click;
                btnPrint.Click += btnPrint_Click;

                // Load orders
                LoadOrders();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error initializing: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Load employee list for filter
        /// </summary>
        private void LoadEmployeeFilter()
        {
            try
            {
                cboEmployee.Items.Clear();
                cboEmployee.Items.Add("All Employees");

                string query = "SELECT EmployeeName FROM Employees ORDER BY EmployeeName";
                DataTable dt = DatabaseConnection.ExecuteQuery(query, null);
                foreach (DataRow row in dt.Rows)
                {
                    cboEmployee.Items.Add(row["EmployeeName"].ToString());
                }
                cboEmployee.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading employees: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Load orders list
        /// </summary>
        private void LoadOrders(string statusFilter = "", string employeeFilter = "", string searchKeyword = "")
        {
            try
            {
                string query = @"SELECT 
                    o.OrderId,
                    o.OrderDate,
                    c.CustomerName,
                    e.EmployeeName,
                    o.TotalAmount,
                    o.OrderStatus
                FROM Orders o
                INNER JOIN Customers c ON o.CustomerId = c.CustomerId
                INNER JOIN Employees e ON o.EmployeeId = e.EmployeeId
                WHERE 1=1";

                var paramList = new System.Collections.Generic.List<SqlParameter>();

                if (!string.IsNullOrEmpty(statusFilter) && statusFilter != "All")
                {
                    query += " AND o.OrderStatus = @Status";
                    paramList.Add(new SqlParameter("@Status", statusFilter));
                }

                if (!string.IsNullOrEmpty(employeeFilter) && employeeFilter != "All Employees")
                {
                    query += " AND e.EmployeeName = @Employee";
                    paramList.Add(new SqlParameter("@Employee", employeeFilter));
                }

                if (!string.IsNullOrEmpty(searchKeyword) && searchKeyword != "Search Order ID")
                {
                    query += " AND (CAST(o.OrderId AS VARCHAR) LIKE @Keyword OR c.CustomerName LIKE @Keyword)";
                    paramList.Add(new SqlParameter("@Keyword", "%" + searchKeyword + "%"));
                }

                query += " ORDER BY o.OrderDate DESC";

                ordersDataTable = DatabaseConnection.ExecuteQuery(query, paramList.ToArray());

                // Display in grid
                dgvOrders.Rows.Clear();
                foreach (DataRow row in ordersDataTable.Rows)
                {
                    dgvOrders.Rows.Add(
                        row["OrderId"],
                        Convert.ToDateTime(row["OrderDate"]).ToString("dd/MM/yyyy HH:mm"),
                        row["CustomerName"],
                        row["EmployeeName"],
                        Convert.ToDecimal(row["TotalAmount"]).ToString("N0"),
                        row["OrderStatus"]
                    );
                }

                // Clear details panel
                ClearOrderDetails();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading orders: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Load order details for selected order
        /// </summary>
        private void LoadOrderDetails(int orderId)
        {
            try
            {
                // Get order info
                string orderQuery = @"SELECT 
                    o.OrderId, c.CustomerName, c.CustomerPhone, o.PaymentMethod, o.TotalAmount, o.OrderStatus
                FROM Orders o
                INNER JOIN Customers c ON o.CustomerId = c.CustomerId
                WHERE o.OrderId = @OrderId";
                SqlParameter[] orderParams = { new SqlParameter("@OrderId", orderId) };
                DataTable orderDt = DatabaseConnection.ExecuteQuery(orderQuery, orderParams);

                if (orderDt.Rows.Count > 0)
                {
                    DataRow orderRow = orderDt.Rows[0];
                    lblDetailTitle.Text = "Order Details #" + orderId;
                    lblCustomerNameDetail.Text = "Customer: " + orderRow["CustomerName"].ToString();
                    lblPhone.Text = "Phone: " + (orderRow["CustomerPhone"]?.ToString() ?? "N/A");
                    lblPaymentMethod.Text = "Payment: " + (orderRow["PaymentMethod"]?.ToString() ?? "Cash");
                    lblSubtotalAmount.Text = Convert.ToDecimal(orderRow["TotalAmount"]).ToString("N0") + " VND";
                }

                // Get order items
                string detailQuery = @"SELECT 
                    p.ProductName,
                    od.Quantity,
                    od.UnitPrice,
                    od.SubTotal
                FROM OrderDetails od
                INNER JOIN Products p ON od.ProductId = p.ProductId
                WHERE od.OrderId = @OrderId";
                SqlParameter[] detailParams = { new SqlParameter("@OrderId", orderId) };
                DataTable detailDt = DatabaseConnection.ExecuteQuery(detailQuery, detailParams);

                dgvOrderDetails.Rows.Clear();
                foreach (DataRow row in detailDt.Rows)
                {
                    dgvOrderDetails.Rows.Add(
                        row["ProductName"],
                        row["Quantity"],
                        Convert.ToDecimal(row["UnitPrice"]).ToString("N0"),
                        Convert.ToDecimal(row["SubTotal"]).ToString("N0")
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading details: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Clear order details panel
        /// </summary>
        private void ClearOrderDetails()
        {
            lblDetailTitle.Text = "Order Details";
            lblCustomerNameDetail.Text = "Customer: --";
            lblPhone.Text = "Phone: --";
            lblPaymentMethod.Text = "Payment: --";
            lblSubtotalAmount.Text = "0 VND";
            dgvOrderDetails.Rows.Clear();
        }

        /// <summary>
        /// Handle order row click
        /// </summary>
        private void dgvOrders_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvOrders.SelectedRows.Count > 0)
            {
                int orderId = Convert.ToInt32(dgvOrders.SelectedRows[0].Cells["colOrderId"].Value);
                LoadOrderDetails(orderId);
            }
        }

        /// <summary>
        /// Format cells based on status
        /// </summary>
        private void dgvOrders_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvOrders.Columns[e.ColumnIndex].Name == "colStatus" && e.Value != null)
            {
                string status = e.Value.ToString();
                switch (status)
                {
                    case "Pending":
                        e.CellStyle.BackColor = Color.Yellow;
                        break;
                    case "Completed":
                        e.CellStyle.BackColor = Color.LightGreen;
                        break;
                    case "Cancelled":
                        e.CellStyle.BackColor = Color.LightCoral;
                        break;
                }
            }
        }

        /// <summary>
        /// Handle Add button - Open Create Order popup
        /// </summary>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Create a new form to host ucCreateOrder
            using (Form createOrderForm = new Form())
            {
                createOrderForm.Text = "Create New Order";
                createOrderForm.Size = new Size(1100, 750);
                createOrderForm.StartPosition = FormStartPosition.CenterScreen;
                createOrderForm.FormBorderStyle = FormBorderStyle.FixedDialog;
                createOrderForm.MaximizeBox = false;
                createOrderForm.MinimizeBox = false;

                // Create and add ucCreateOrder to the form
                ucCreateOrder createOrderControl = new ucCreateOrder();
                createOrderControl.Dock = DockStyle.Fill;
                createOrderForm.Controls.Add(createOrderControl);

                // Show the form as dialog
                createOrderForm.ShowDialog();

                // Refresh orders list after dialog closes
                LoadOrders();
            }
        }

        /// <summary>
        /// Handle Edit button - Update status
        /// </summary>
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvOrders.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an order to edit!", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int orderId = Convert.ToInt32(dgvOrders.SelectedRows[0].Cells["colOrderId"].Value);
            string currentStatus = dgvOrders.SelectedRows[0].Cells["colStatus"].Value?.ToString();

            // Show status change dialog
            using (Form dialog = new Form())
            {
                dialog.Text = "Update Order Status";
                dialog.Size = new Size(300, 180);
                dialog.StartPosition = FormStartPosition.CenterParent;
                dialog.FormBorderStyle = FormBorderStyle.FixedDialog;
                dialog.MaximizeBox = false;
                dialog.MinimizeBox = false;

                Label lblStatus = new Label() { Text = "New Status:", Location = new Point(20, 30), AutoSize = true };
                ComboBox cboNewStatus = new ComboBox() { Location = new Point(100, 27), Width = 160, DropDownStyle = ComboBoxStyle.DropDownList };
                cboNewStatus.Items.AddRange(new string[] { "Pending", "Completed", "Cancelled" });
                cboNewStatus.SelectedItem = currentStatus;

                Button btnSave = new Button() { Text = "Save", Location = new Point(50, 80), Width = 80, DialogResult = DialogResult.OK };
                Button btnCancel = new Button() { Text = "Cancel", Location = new Point(150, 80), Width = 80, DialogResult = DialogResult.Cancel };

                dialog.Controls.AddRange(new Control[] { lblStatus, cboNewStatus, btnSave, btnCancel });
                dialog.AcceptButton = btnSave;
                dialog.CancelButton = btnCancel;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    string newStatus = cboNewStatus.SelectedItem?.ToString();
                    if (!string.IsNullOrEmpty(newStatus) && newStatus != currentStatus)
                    {
                        UpdateOrderStatus(orderId, newStatus, currentStatus);
                    }
                }
            }
        }

        /// <summary>
        /// Update order status in database
        /// </summary>
        private void UpdateOrderStatus(int orderId, string newStatus, string currentStatus)
        {
            try
            {
                // If cancelling, restore stock
                if (newStatus == "Cancelled" && currentStatus != "Cancelled")
                {
                    // Get order details
                    string detailQuery = "SELECT ProductId, Quantity FROM OrderDetails WHERE OrderId = @OrderId";
                    SqlParameter[] detailParams = { new SqlParameter("@OrderId", orderId) };
                    DataTable dt = DatabaseConnection.ExecuteQuery(detailQuery, detailParams);

                    // Restore stock for each product
                    foreach (DataRow row in dt.Rows)
                    {
                        string stockQuery = "UPDATE Products SET StockQuantity = StockQuantity + @Quantity WHERE ProductId = @ProductId";
                        SqlParameter[] stockParams = {
                            new SqlParameter("@Quantity", row["Quantity"]),
                            new SqlParameter("@ProductId", row["ProductId"])
                        };
                        DatabaseConnection.ExecuteNonQuery(stockQuery, stockParams);
                    }
                }

                // Update status
                string updateQuery = "UPDATE Orders SET OrderStatus = @Status WHERE OrderId = @OrderId";
                SqlParameter[] updateParams = {
                    new SqlParameter("@Status", newStatus),
                    new SqlParameter("@OrderId", orderId)
                };
                DatabaseConnection.ExecuteNonQuery(updateQuery, updateParams);

                MessageBox.Show("Order status updated successfully!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadOrders();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating status: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Handle Delete button - Cancel order
        /// </summary>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvOrders.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an order to cancel!", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int orderId = Convert.ToInt32(dgvOrders.SelectedRows[0].Cells["colOrderId"].Value);
            string currentStatus = dgvOrders.SelectedRows[0].Cells["colStatus"].Value?.ToString();

            if (currentStatus == "Cancelled")
            {
                MessageBox.Show("This order is already cancelled!", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (currentStatus == "Completed")
            {
                MessageBox.Show("Cannot cancel completed orders!", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
                $"Are you sure you want to cancel order #{orderId}?\nStock will be restored.",
                "Confirm Cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                UpdateOrderStatus(orderId, "Cancelled", currentStatus);
            }
        }

        /// <summary>
        /// Handle Print button
        /// </summary>
        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (dgvOrders.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an order to print!", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show("Print functionality will be available in a future update.", "Information",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Filter event handlers
        private void cboStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void cboEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            // Could add date filtering here
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void ApplyFilters()
        {
            string status = cboStatus.SelectedIndex > 0 ? cboStatus.SelectedItem.ToString() : "";
            string employee = cboEmployee.SelectedIndex > 0 ? cboEmployee.SelectedItem.ToString() : "";
            string keyword = txtSearch.Text;
            LoadOrders(status, employee, keyword);
        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Search Order ID")
            {
                txtSearch.Text = "";
            }
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                txtSearch.Text = "Search Order ID";
            }
        }

        private void btnPrint_Click_1(object sender, EventArgs e)
        {

        }
    }
}
