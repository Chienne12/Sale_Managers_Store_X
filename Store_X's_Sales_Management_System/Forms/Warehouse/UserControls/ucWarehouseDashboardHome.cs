using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Store_X_s_Sales_Management_System.Forms.Warehouse.UserControls
{
    public partial class ucWarehouseDashboardHome : UserControl
    {
        public ucWarehouseDashboardHome()
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
                // Wire up events
                dgvReplenishment.CellClick += dgvReplenishment_CellClick;

                // Load initial data
                LoadWarehouseStatistics();
                LoadLowStockProducts();
                LoadRecentMovements();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error initializing: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Load warehouse statistics
        /// </summary>
        private void LoadWarehouseStatistics()
        {
            try
            {
                // Total products
                string countQuery = "SELECT COUNT(*) FROM Products";
                object countResult = DatabaseConnection.ExecuteScalar(countQuery, null);
                lblTotalItemsCount.Text = countResult.ToString();

                // Low stock count (stock < 10)
                string lowStockQuery = "SELECT COUNT(*) FROM Products WHERE StockQuantity < 10";
                object lowStockResult = DatabaseConnection.ExecuteScalar(lowStockQuery, null);
                int lowStockCount = Convert.ToInt32(lowStockResult);
                lblLowStockCount.Text = lowStockCount.ToString() + " Items";

                // Change color based on low stock
                if (lowStockCount > 0)
                {
                    lblLowStockCount.ForeColor = Color.Red;
                }
                else
                {
                    lblLowStockCount.ForeColor = Color.Green;
                }

                // Total inventory value
                string valueQuery = "SELECT ISNULL(SUM(StockQuantity * ProductPrice), 0) FROM Products";
                object valueResult = DatabaseConnection.ExecuteScalar(valueQuery, null);
                decimal totalValue = Convert.ToDecimal(valueResult);
                lblTotalValueAmount.Text = totalValue.ToString("N0") + " VND";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading statistics: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Load low stock products for replenishment
        /// </summary>
        private void LoadLowStockProducts()
        {
            try
            {
                string query = @"SELECT 
                    p.ProductId,
                    p.ProductName,
                    s.SupplierName,
                    p.StockQuantity,
                    10 AS ReorderLevel
                FROM Products p
                INNER JOIN Suppliers s ON p.SupplierId = s.SupplierId
                WHERE p.StockQuantity < 10
                ORDER BY p.StockQuantity ASC";

                DataTable dt = DatabaseConnection.ExecuteQuery(query, null);

                dgvReplenishment.Rows.Clear();
                foreach (DataRow row in dt.Rows)
                {
                    int rowIndex = dgvReplenishment.Rows.Add(
                        row["ProductName"],
                        row["SupplierName"],
                        row["StockQuantity"],
                        row["ReorderLevel"],
                        "Import Stock"
                    );
                    dgvReplenishment.Rows[rowIndex].Tag = row["ProductId"];

                    // Highlight critical stock (< 5)
                    if (Convert.ToInt32(row["StockQuantity"]) < 5)
                    {
                        dgvReplenishment.Rows[rowIndex].DefaultCellStyle.BackColor = Color.LightCoral;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading low stock: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Load recent inventory movements (from Orders/OrderDetails since no InventoryHistory table)
        /// </summary>
        private void LoadRecentMovements()
        {
            try
            {
                // Since there's no InventoryHistory table, show recent completed orders as "Export" movements
                string query = @"SELECT TOP 20
                    o.OrderDate,
                    'Export (Sale)' AS TransactionType,
                    p.ProductName,
                    od.Quantity,
                    e.EmployeeName
                FROM Orders o
                INNER JOIN OrderDetails od ON o.OrderId = od.OrderId
                INNER JOIN Products p ON od.ProductId = p.ProductId
                INNER JOIN Employees e ON o.EmployeeId = e.EmployeeId
                WHERE o.OrderStatus = 'Completed'
                ORDER BY o.OrderDate DESC";

                DataTable dt = DatabaseConnection.ExecuteQuery(query, null);

                dgvInventoryMovements.Rows.Clear();
                foreach (DataRow row in dt.Rows)
                {
                    dgvInventoryMovements.Rows.Add(
                        Convert.ToDateTime(row["OrderDate"]).ToString("dd/MM/yyyy HH:mm"),
                        row["TransactionType"],
                        row["ProductName"],
                        "-" + row["Quantity"].ToString(),
                        row["EmployeeName"]
                    );
                }

                // Update label to reflect actual data source
                lblInventoryMovements.Text = "Recent Stock Movements (From Sales)";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading movements: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Handle Import Stock button click
        /// </summary>
        private void dgvReplenishment_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // Check if Action column clicked
            if (e.ColumnIndex == dgvReplenishment.Columns["colAction"].Index)
            {
                int productId = Convert.ToInt32(dgvReplenishment.Rows[e.RowIndex].Tag);
                string productName = dgvReplenishment.Rows[e.RowIndex].Cells["colProductName"].Value?.ToString();

                // Show import dialog
                ShowImportDialog(productId, productName);
            }
        }

        /// <summary>
        /// Show stock import dialog
        /// </summary>
        private void ShowImportDialog(int productId, string productName)
        {
            using (Form dialog = new Form())
            {
                dialog.Text = "Import Stock - " + productName;
                dialog.Size = new Size(350, 180);
                dialog.StartPosition = FormStartPosition.CenterParent;
                dialog.FormBorderStyle = FormBorderStyle.FixedDialog;
                dialog.MaximizeBox = false;
                dialog.MinimizeBox = false;

                Label lblQuantity = new Label() { Text = "Quantity to Import:", Location = new Point(20, 30), AutoSize = true };
                NumericUpDown nudQuantity = new NumericUpDown() { Location = new Point(150, 27), Width = 150, Minimum = 1, Maximum = 10000, Value = 10 };

                Button btnImport = new Button() { Text = "Import", Location = new Point(70, 80), Width = 100, DialogResult = DialogResult.OK };
                Button btnCancel = new Button() { Text = "Cancel", Location = new Point(180, 80), Width = 100, DialogResult = DialogResult.Cancel };

                dialog.Controls.AddRange(new Control[] { lblQuantity, nudQuantity, btnImport, btnCancel });
                dialog.AcceptButton = btnImport;
                dialog.CancelButton = btnCancel;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        int quantity = (int)nudQuantity.Value;
                        string updateQuery = "UPDATE Products SET StockQuantity = StockQuantity + @Quantity WHERE ProductId = @ProductId";
                        SqlParameter[] parameters = {
                            new SqlParameter("@Quantity", quantity),
                            new SqlParameter("@ProductId", productId)
                        };
                        DatabaseConnection.ExecuteNonQuery(updateQuery, parameters);

                        MessageBox.Show($"Successfully imported {quantity} units of {productName}!", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Refresh data
                        LoadWarehouseStatistics();
                        LoadLowStockProducts();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error importing stock: " + ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        /// <summary>
        /// Refresh all data
        /// </summary>
        public void RefreshData()
        {
            LoadWarehouseStatistics();
            LoadLowStockProducts();
            LoadRecentMovements();
        }
    }
}
