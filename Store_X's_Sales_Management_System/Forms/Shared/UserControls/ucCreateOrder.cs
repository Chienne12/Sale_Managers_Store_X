using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Store_X_s_Sales_Management_System.Forms.Shared.UserControls
{
    public partial class ucCreateOrder : UserControl
    {
        private List<CartItem> cartItems = new List<CartItem>();
        private decimal subtotalAmount = 0;
        private decimal discountAmount = 0;
        private decimal totalAmount = 0;
        private int currentEmployeeId = 1; // Default, should be set from login

        private class CartItem
        {
            public int ProductId { get; set; }
            public string ProductName { get; set; }
            public decimal UnitPrice { get; set; }
            public int Quantity { get; set; }
            public decimal Subtotal => UnitPrice * Quantity;
        }

        public ucCreateOrder()
        {
            InitializeComponent();
            InitializeUserControl();
        }

        /// <summary>
        /// Set employee ID from login
        /// </summary>
        public void SetEmployeeId(int employeeId)
        {
            currentEmployeeId = employeeId;
        }

        /// <summary>
        /// Initialize UserControl
        /// </summary>
        private void InitializeUserControl()
        {
            try
            {
                // Set default payment method
                cboPaymentMethod.SelectedIndex = 0;

                // Wire up events - click on product row to add to cart
                dgvProducts.CellDoubleClick += DgvProducts_CellDoubleClick;
                dgvProducts.CellClick += DgvProducts_CellClick;
                btnRemoveItem.Click += BtnRemoveItem_Click;
                btnClearCart.Click += BtnClearCart_Click;
                btnPlaceOrder.Click += BtnPlaceOrder_Click;
                btnCancel.Click += BtnCancel_Click;

                // Search and filter events
                txtSearchProduct.TextChanged += TxtSearchProduct_TextChanged;
                txtSearchProduct.GotFocus += TxtSearchProduct_GotFocus;
                txtSearchProduct.LostFocus += TxtSearchProduct_LostFocus;
                cboCategory.SelectedIndexChanged += CboCategory_SelectedIndexChanged;

                // Hide the Add to Cart button
                btnAddToCart.Visible = false;

                // Load data
                LoadCategories();
                LoadProducts();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error initializing: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Load products into DataGridView
        /// </summary>
        private void LoadProducts(string searchText = "", string category = "")
        {
            try
            {
                string query = @"SELECT 
                    p.ProductId, 
                    p.ProductName, 
                    ISNULL(c.CategoryName, 'N/A') as CategoryName, 
                    p.ProductPrice, 
                    p.StockQuantity 
                FROM Products p
                LEFT JOIN Categories c ON p.CategoryId = c.CategoryId
                WHERE p.StockQuantity > 0";

                var paramList = new List<SqlParameter>();

                if (!string.IsNullOrEmpty(searchText) && searchText != "🔍 Search product...")
                {
                    query += " AND p.ProductName LIKE @Search";
                    paramList.Add(new SqlParameter("@Search", "%" + searchText + "%"));
                }

                if (!string.IsNullOrEmpty(category) && category != "All Categories")
                {
                    query += " AND c.CategoryName = @Category";
                    paramList.Add(new SqlParameter("@Category", category));
                }

                query += " ORDER BY p.ProductName";

                DataTable dt = DatabaseConnection.ExecuteQuery(query, paramList.ToArray());

                dgvProducts.Rows.Clear();
                foreach (DataRow row in dt.Rows)
                {
                    dgvProducts.Rows.Add(
                        row["ProductId"],
                        row["ProductName"],
                        row["CategoryName"],
                        Convert.ToDecimal(row["ProductPrice"]).ToString("N0"),
                        row["StockQuantity"]
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading products: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Load categories into ComboBox
        /// </summary>
        private void LoadCategories()
        {
            try
            {
                cboCategory.Items.Clear();
                cboCategory.Items.Add("All Categories");

                string query = "SELECT CategoryName FROM Categories ORDER BY CategoryName";
                DataTable dt = DatabaseConnection.ExecuteQuery(query, null);

                foreach (DataRow row in dt.Rows)
                {
                    cboCategory.Items.Add(row["CategoryName"].ToString());
                }

                cboCategory.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading categories: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Add product to cart when clicking on product row
        /// </summary>
        private void DgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Single click - add 1 item
            if (e.RowIndex >= 0)
            {
                AddProductToCart(1);
            }
        }

        /// <summary>
        /// Add product to cart when double-clicking on product row
        /// </summary>
        private void DgvProducts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Double click - add quantity from nudQuantity
            if (e.RowIndex >= 0)
            {
                AddProductToCart((int)nudQuantity.Value);
            }
        }

        /// <summary>
        /// Add product to cart with specified quantity
        /// </summary>
        private void AddProductToCart(int quantity)
        {
            if (dgvProducts.SelectedRows.Count == 0) return;

            DataGridViewRow selectedRow = dgvProducts.SelectedRows[0];
            int productId = Convert.ToInt32(selectedRow.Cells["colProductId"].Value);
            string productName = selectedRow.Cells["colProductName"].Value.ToString();
            decimal unitPrice = decimal.Parse(selectedRow.Cells["colPrice"].Value.ToString().Replace(",", ""));
            int stock = Convert.ToInt32(selectedRow.Cells["colStock"].Value);

            // Check stock
            if (quantity > stock)
            {
                MessageBox.Show("Not enough stock! Available: " + stock, "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Check if product already in cart
            CartItem existingItem = cartItems.Find(x => x.ProductId == productId);
            if (existingItem != null)
            {
                if (existingItem.Quantity + quantity > stock)
                {
                    MessageBox.Show($"Cannot add more. Already {existingItem.Quantity} in cart, available stock: {stock}", 
                        "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                existingItem.Quantity += quantity;
            }
            else
            {
                cartItems.Add(new CartItem
                {
                    ProductId = productId,
                    ProductName = productName,
                    UnitPrice = unitPrice,
                    Quantity = quantity
                });
            }

            RefreshCart();
        }

        /// <summary>
        /// Add product to cart (legacy method - hidden button)
        /// </summary>
        private void BtnAddToCart_Click(object sender, EventArgs e)
        {
            AddProductToCart((int)nudQuantity.Value);
        }

        /// <summary>
        /// Remove item from cart
        /// </summary>
        private void BtnRemoveItem_Click(object sender, EventArgs e)
        {
            if (dgvCart.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an item to remove!", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int rowIndex = dgvCart.SelectedRows[0].Index;
            if (rowIndex >= 0 && rowIndex < cartItems.Count)
            {
                cartItems.RemoveAt(rowIndex);
                RefreshCart();
            }
        }

        /// <summary>
        /// Clear all items from cart
        /// </summary>
        private void BtnClearCart_Click(object sender, EventArgs e)
        {
            if (cartItems.Count == 0) return;

            DialogResult result = MessageBox.Show("Clear all items from cart?", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                cartItems.Clear();
                RefreshCart();
            }
        }

        /// <summary>
        /// Refresh cart display
        /// </summary>
        private void RefreshCart()
        {
            dgvCart.Rows.Clear();
            subtotalAmount = 0;

            foreach (CartItem item in cartItems)
            {
                dgvCart.Rows.Add(
                    item.ProductName,
                    item.Quantity,
                    item.UnitPrice.ToString("N0"),
                    item.Subtotal.ToString("N0")
                );
                subtotalAmount += item.Subtotal;
            }

            CalculateTotal();
        }

        /// <summary>
        /// Calculate total amount
        /// </summary>
        private void CalculateTotal()
        {
            discountAmount = 0; // No discount logic
            totalAmount = subtotalAmount - discountAmount;

            lblSubtotalAmount.Text = subtotalAmount.ToString("N0") + " VND";
            lblDiscountAmount.Text = "-" + discountAmount.ToString("N0") + " VND";
            lblTotalAmount.Text = totalAmount.ToString("N0") + " VND";
        }

        /// <summary>
        /// Place order
        /// </summary>
        private void BtnPlaceOrder_Click(object sender, EventArgs e)
        {
            if (!ValidateOrder()) return;

            DialogResult result = MessageBox.Show(
                $"Confirm order total: {totalAmount:N0} VND?",
                "Confirm Order", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                if (SaveOrderToDatabase())
                {
                    MessageBox.Show("Order placed successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    // Close parent form if exists
                    Form parentForm = this.FindForm();
                    if (parentForm != null)
                    {
                        parentForm.DialogResult = DialogResult.OK;
                        parentForm.Close();
                    }
                    else
                    {
                        ResetForm();
                    }
                }
            }
        }

        /// <summary>
        /// Cancel order
        /// </summary>
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            if (cartItems.Count > 0)
            {
                DialogResult result = MessageBox.Show("Cancel this order?", "Confirm",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No) return;
            }

            // Close parent form if exists
            Form parentForm = this.FindForm();
            if (parentForm != null)
            {
                parentForm.DialogResult = DialogResult.Cancel;
                parentForm.Close();
            }
            else
            {
                ResetForm();
            }
        }

        /// <summary>
        /// Save order to database
        /// </summary>
        private bool SaveOrderToDatabase()
        {
            try
            {
                // Get or create customer
                int customerId = GetOrCreateCustomer();

                // Insert order
                string insertOrderQuery = @"INSERT INTO Orders (CustomerId, OrderDate, TotalAmount, EmployeeId, PaymentMethod, OrderStatus)
                    VALUES (@CustomerId, @OrderDate, @TotalAmount, @EmployeeId, @PaymentMethod, @OrderStatus);
                    SELECT SCOPE_IDENTITY();";

                SqlParameter[] orderParams = {
                    new SqlParameter("@CustomerId", customerId),
                    new SqlParameter("@OrderDate", DateTime.Now),
                    new SqlParameter("@TotalAmount", totalAmount),
                    new SqlParameter("@EmployeeId", currentEmployeeId),
                    new SqlParameter("@PaymentMethod", cboPaymentMethod.SelectedItem?.ToString() ?? "Cash"),
                    new SqlParameter("@OrderStatus", "Completed")
                };

                object orderIdObj = DatabaseConnection.ExecuteScalar(insertOrderQuery, orderParams);
                int orderId = Convert.ToInt32(orderIdObj);

                // Insert order details and update stock
                foreach (CartItem item in cartItems)
                {
                    // Insert order detail
                    string insertDetailQuery = @"INSERT INTO OrderDetails (OrderId, ProductId, Quantity, UnitPrice, SubTotal)
                        VALUES (@OrderId, @ProductId, @Quantity, @UnitPrice, @SubTotal)";
                    SqlParameter[] detailParams = {
                        new SqlParameter("@OrderId", orderId),
                        new SqlParameter("@ProductId", item.ProductId),
                        new SqlParameter("@Quantity", item.Quantity),
                        new SqlParameter("@UnitPrice", item.UnitPrice),
                        new SqlParameter("@SubTotal", item.Subtotal)
                    };
                    DatabaseConnection.ExecuteNonQuery(insertDetailQuery, detailParams);

                    // Update stock
                    string updateStockQuery = "UPDATE Products SET StockQuantity = StockQuantity - @Quantity WHERE ProductId = @ProductId";
                    SqlParameter[] stockParams = {
                        new SqlParameter("@Quantity", item.Quantity),
                        new SqlParameter("@ProductId", item.ProductId)
                    };
                    DatabaseConnection.ExecuteNonQuery(updateStockQuery, stockParams);
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving order: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Get or create customer
        /// </summary>
        private int GetOrCreateCustomer()
        {
            string customerName = txtCustomerName.Text.Trim();
            string customerPhone = txtCustomerPhone.Text.Trim();

            if (string.IsNullOrEmpty(customerPhone))
            {
                customerPhone = "0000000000"; // Default phone for guest
            }

            if (string.IsNullOrEmpty(customerName))
            {
                customerName = "Guest Customer";
            }

            // Check if customer exists by phone
            string checkQuery = "SELECT CustomerId FROM Customers WHERE CustomerPhone = @Phone";
            SqlParameter[] checkParams = { new SqlParameter("@Phone", customerPhone) };
            object result = DatabaseConnection.ExecuteScalar(checkQuery, checkParams);

            if (result != null && result != DBNull.Value)
            {
                // Check if customer is inactive
                string nameQuery = "SELECT CustomerName FROM Customers WHERE CustomerId = @Id";
                SqlParameter[] nameParams = { new SqlParameter("@Id", result) };
                object nameObj = DatabaseConnection.ExecuteScalar(nameQuery, nameParams);
                string existingName = nameObj?.ToString() ?? "";

                if (existingName.StartsWith("[INACTIVE]"))
                {
                    throw new Exception("This customer is inactive! Please reactivate before creating an order.");
                }

                return Convert.ToInt32(result);
            }

            // Create new customer
            string insertQuery = @"INSERT INTO Customers (CustomerName, CustomerPhone, CustomerAddress, CustomerEmail)
                VALUES (@Name, @Phone, '', '');
                SELECT SCOPE_IDENTITY();";
            SqlParameter[] insertParams = {
                new SqlParameter("@Name", customerName),
                new SqlParameter("@Phone", customerPhone)
            };
            object newId = DatabaseConnection.ExecuteScalar(insertQuery, insertParams);
            return Convert.ToInt32(newId);
        }

        /// <summary>
        /// Validate order before saving
        /// </summary>
        private bool ValidateOrder()
        {
            if (cartItems.Count == 0)
            {
                MessageBox.Show("Please add at least one product!", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cboPaymentMethod.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a payment method!", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Reset form to initial state
        /// </summary>
        private void ResetForm()
        {
            cartItems.Clear();
            txtCustomerName.Clear();
            txtCustomerPhone.Clear();
            cboPaymentMethod.SelectedIndex = 0;
            nudQuantity.Value = 1;
            RefreshCart();
            LoadProducts();
        }

        #region Search & Filter Events

        private void TxtSearchProduct_TextChanged(object sender, EventArgs e)
        {
            string search = txtSearchProduct.Text;
            string category = cboCategory.SelectedItem?.ToString() ?? "";
            LoadProducts(search, category);
        }

        private void TxtSearchProduct_GotFocus(object sender, EventArgs e)
        {
            if (txtSearchProduct.Text == "🔍 Search product...")
            {
                txtSearchProduct.Text = "";
                txtSearchProduct.ForeColor = Color.Black;
            }
        }

        private void TxtSearchProduct_LostFocus(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearchProduct.Text))
            {
                txtSearchProduct.Text = "🔍 Search product...";
                txtSearchProduct.ForeColor = Color.Gray;
            }
        }

        private void CboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            string search = txtSearchProduct.Text;
            string category = cboCategory.SelectedItem?.ToString() ?? "";
            LoadProducts(search, category);
        }

        #endregion

        private void dgvProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void lblProductListTitle_Click(object sender, EventArgs e)
        {

        }
    }
}
