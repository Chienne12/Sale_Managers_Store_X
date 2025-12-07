using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Store_X_s_Sales_Management_System.Forms.Sales.UserControls
{
    public partial class ucSalesDashboardHome : UserControl
    {
        private string currentUsername;
        private int currentEmployeeId;
        private DataTable productsDataTable;
        private List<CartItem> cartItems = new List<CartItem>();
        private Panel[] productPanels;
        private Label[] productNameLabels;
        private Label[] priceLabels;
        private Label[] stockLabels;
        private Button[] addToCartButtons;

        public ucSalesDashboardHome()
        {
            InitializeComponent();
            InitializeUserControl();
        }

        /// <summary>
        /// Set current username for sales tracking
        /// </summary>
        public void SetUsername(string username)
        {
            currentUsername = username;
            GetEmployeeId();
        }

        /// <summary>
        /// Get employee ID from username
        /// </summary>
        private void GetEmployeeId()
        {
            try
            {
                if (string.IsNullOrEmpty(currentUsername)) return;

                string query = "SELECT EmployeeId FROM Employees WHERE Username = @Username";
                SqlParameter[] parameters = { new SqlParameter("@Username", currentUsername) };
                object result = DatabaseConnection.ExecuteScalar(query, parameters);
                if (result != null)
                {
                    currentEmployeeId = Convert.ToInt32(result);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getting employee: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Initialize user control settings
        /// </summary>
        private void InitializeUserControl()
        {
            try
            {
                // Initialize control arrays
                productPanels = new Panel[] { pnlProduct1, pnlProduct2, pnlProduct3, pnlProduct4, pnlProduct5, pnlProduct6 };
                productNameLabels = new Label[] { lblProductName1, lblProductName2, lblProductName3, lblProductName4, lblProductName5, lblProductName6 };
                priceLabels = new Label[] { lblPrice1, lblPrice2, lblPrice3, lblPrice4, lblPrice5, lblPrice6 };
                stockLabels = new Label[] { lblStockQty1, lblStockQty2, lblStockQty3, lblStockQty4, lblStockQty5, lblStockQty6 };
                addToCartButtons = new Button[] { btnAddToCart1, btnAddToCart2, btnAddToCart3, btnAddToCart4, btnAddToCart5, btnAddToCart6 };

                // Wire up events
                txtFindProducts.TextChanged += txtFindProducts_TextChanged;
                txtFindProducts.Enter += txtFindProducts_Enter;
                txtFindProducts.Leave += txtFindProducts_Leave;
                cboCategory.SelectedIndexChanged += cboCategory_SelectedIndexChanged;
                chkInStockOnly.CheckedChanged += chkInStockOnly_CheckedChanged;
                btnCheck.Click += btnCheck_Click;
                btnCancel.Click += btnCancel_Click;
                btnPrint.Click += btnPrint_Click;
                btnRemoveItem.Click += btnRemoveItem_Click;
                txtCustomer.Enter += txtCustomer_Enter;
                txtCustomer.Leave += txtCustomer_Leave;
                txtCustomerName.Enter += txtCustomerName_Enter;
                txtCustomerName.Leave += txtCustomerName_Leave;
                lstOrderItems.DoubleClick += lstOrderItems_DoubleClick;

                // Wire up add to cart buttons
                for (int i = 0; i < addToCartButtons.Length; i++)
                {
                    int index = i;
                    addToCartButtons[i].Click += (s, e) => AddToCart(index);
                }

                // Set default payment method
                cboPaymentMethod.SelectedIndex = 0;

                // Load categories
                LoadCategories();

                // Load products
                LoadProducts();

                // Load customers
                LoadCustomersForOrder();
                
                // Wire up Radio Events
                rdoExistingCustomer.CheckedChanged += RdoCustomerType_CheckedChanged;
                rdoNewCustomer.CheckedChanged += RdoCustomerType_CheckedChanged;
                
                // Set default mode
                rdoNewCustomer.Checked = true;

                // Clear cart
                ClearCart();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error initializing: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Load categories into combobox
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
        /// Load customers for selection
        /// </summary>
        private void LoadCustomersForOrder()
        {
            try
            {
                string query = "SELECT CustomerId, CustomerName, CustomerPhone FROM Customers WHERE CustomerName NOT LIKE '[INACTIVE]%' ORDER BY CustomerName";
                DataTable dt = DatabaseConnection.ExecuteQuery(query, null);

                // Add display column
                dt.Columns.Add("DisplayMember", typeof(string));
                foreach(DataRow row in dt.Rows)
                {
                    row["DisplayMember"] = $"{row["CustomerName"]} - {row["CustomerPhone"]}";
                }

                cboCustomerSelect.DataSource = dt;
                cboCustomerSelect.DisplayMember = "DisplayMember";
                cboCustomerSelect.ValueMember = "CustomerId";
            }
            catch (Exception ex)
            {
                 MessageBox.Show("Error loading customers: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Load products from database
        /// </summary>
        private void LoadProducts(string searchKeyword = "", string categoryFilter = "", bool inStockOnly = false)
        {
            try
            {
                string query = @"SELECT TOP 6
                    p.ProductId,
                    p.ProductName,
                    p.ProductPrice,
                    p.StockQuantity,
                    c.CategoryName
                FROM Products p
                INNER JOIN Categories c ON p.CategoryId = c.CategoryId
                WHERE p.ProductName NOT LIKE '[DISCONTINUED]%'";

                List<SqlParameter> paramList = new List<SqlParameter>();

                if (!string.IsNullOrEmpty(searchKeyword) && searchKeyword != "Find products...")
                {
                    query += " AND p.ProductName LIKE @Keyword";
                    paramList.Add(new SqlParameter("@Keyword", "%" + searchKeyword + "%"));
                }

                if (!string.IsNullOrEmpty(categoryFilter) && categoryFilter != "All Categories")
                {
                    query += " AND c.CategoryName = @Category";
                    paramList.Add(new SqlParameter("@Category", categoryFilter));
                }

                if (inStockOnly)
                {
                    query += " AND p.StockQuantity > 0";
                }

                query += " ORDER BY p.ProductName";

                productsDataTable = DatabaseConnection.ExecuteQuery(query, paramList.ToArray());

                // Display products
                DisplayProducts();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading products: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Display products on product panels
        /// </summary>
        private void DisplayProducts()
        {
            // Hide all panels first
            foreach (var panel in productPanels)
            {
                panel.Visible = false;
            }

            // Display products
            for (int i = 0; i < productsDataTable.Rows.Count && i < 6; i++)
            {
                DataRow row = productsDataTable.Rows[i];
                productPanels[i].Visible = true;
                productPanels[i].Tag = row["ProductId"];
                productNameLabels[i].Text = row["ProductName"].ToString();
                priceLabels[i].Text = Convert.ToDecimal(row["ProductPrice"]).ToString("N0") + " VND";
                stockLabels[i].Text = "Stock: " + row["StockQuantity"].ToString();

                // Disable if out of stock
                int stock = Convert.ToInt32(row["StockQuantity"]);
                addToCartButtons[i].Enabled = stock > 0;
                if (stock == 0)
                {
                    stockLabels[i].ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    stockLabels[i].ForeColor = System.Drawing.Color.Black;
                }
            }
        }

        /// <summary>
        /// Add product to cart
        /// </summary>
        private void AddToCart(int productIndex)
        {
            try
            {
                if (productIndex >= productsDataTable.Rows.Count) return;

                DataRow row = productsDataTable.Rows[productIndex];
                int productId = Convert.ToInt32(row["ProductId"]);
                string productName = row["ProductName"].ToString();
                decimal price = Convert.ToDecimal(row["ProductPrice"]);
                int stock = Convert.ToInt32(row["StockQuantity"]);

                // Check if already in cart
                var existingItem = cartItems.Find(x => x.ProductId == productId);
                if (existingItem != null)
                {
                    if (existingItem.Quantity >= stock)
                    {
                        MessageBox.Show("Cannot add more! Not enough stock.", "Warning",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    existingItem.Quantity++;
                }
                else
                {
                    cartItems.Add(new CartItem
                    {
                        ProductId = productId,
                        ProductName = productName,
                        Price = price,
                        Quantity = 1
                    });
                }

                UpdateCartDisplay();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding to cart: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Update cart display
        /// </summary>
        private void UpdateCartDisplay()
        {
            lstOrderItems.Items.Clear();
            decimal total = 0;

            foreach (var item in cartItems)
            {
                lstOrderItems.Items.Add($"{item.ProductName} x{item.Quantity} = {(item.Price * item.Quantity):N0}");
                total += item.Price * item.Quantity;
            }

            lblTotal.ForeColor = System.Drawing.Color.Red; // Ensure visibility
            lblTotal.Text = "TOTAL: " + total.ToString("N0") + " VND";
        }

        /// <summary>
        /// Clear shopping cart
        /// </summary>
        private void ClearCart()
        {
            cartItems.Clear();
            lstOrderItems.Items.Clear();
            lblTotal.Text = "TOTAL: 0 VND";
            txtCustomer.Text = "Phone";
            txtCustomerName.Text = "Name";
            if (cboPaymentMethod.Items.Count > 0)
                cboPaymentMethod.SelectedIndex = 0;
        }

        /// <summary>
        /// Handle checkout
        /// </summary>
        private void btnCheck_Click(object sender, EventArgs e)
        {
            if (cartItems.Count == 0)
            {
                MessageBox.Show("Cart is empty! Please add products before checkout.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Get or create customer (guest if no phone entered)
                int customerId = GetOrCreateCustomer();
                
                // Validate customerId
                if (customerId <= 0)
                {
                    MessageBox.Show("Error creating customer. Please try again.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Double check cart is not empty
                if (cartItems.Count == 0)
                {
                    MessageBox.Show("Cart is empty!", "Warning",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Calculate total
                decimal total = 0;
                foreach (var item in cartItems)
                {
                    total += item.Price * item.Quantity;
                }

                // Validate total
                if (total <= 0)
                {
                    MessageBox.Show("Invalid order total!", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Create order
                string paymentMethod = cboPaymentMethod.SelectedItem?.ToString() ?? "Cash";
                string orderQuery = @"INSERT INTO Orders (OrderDate, TotalAmount, CustomerId, EmployeeId, PaymentMethod, OrderStatus) 
                                     VALUES (GETDATE(), @TotalAmount, @CustomerId, @EmployeeId, @PaymentMethod, 'Completed');
                                     SELECT SCOPE_IDENTITY();";
                SqlParameter[] orderParams = {
                    new SqlParameter("@TotalAmount", total),
                    new SqlParameter("@CustomerId", customerId),
                    new SqlParameter("@EmployeeId", currentEmployeeId > 0 ? currentEmployeeId : 1),
                    new SqlParameter("@PaymentMethod", paymentMethod)
                };
                object orderIdObj = DatabaseConnection.ExecuteScalar(orderQuery, orderParams);
                int orderId = Convert.ToInt32(orderIdObj);

                // Create order details and update stock
                foreach (var item in cartItems)
                {
                    // Insert order detail
                    string detailQuery = @"INSERT INTO OrderDetails (OrderId, ProductId, Quantity, UnitPrice, SubTotal) 
                                          VALUES (@OrderId, @ProductId, @Quantity, @UnitPrice, @SubTotal)";
                    SqlParameter[] detailParams = {
                        new SqlParameter("@OrderId", orderId),
                        new SqlParameter("@ProductId", item.ProductId),
                        new SqlParameter("@Quantity", item.Quantity),
                        new SqlParameter("@UnitPrice", item.Price),
                        new SqlParameter("@SubTotal", item.Price * item.Quantity)
                    };
                    DatabaseConnection.ExecuteNonQuery(detailQuery, detailParams);

                    // Update stock
                    string stockQuery = "UPDATE Products SET StockQuantity = StockQuantity - @Quantity WHERE ProductId = @ProductId";
                    SqlParameter[] stockParams = {
                        new SqlParameter("@Quantity", item.Quantity),
                        new SqlParameter("@ProductId", item.ProductId)
                    };
                    DatabaseConnection.ExecuteNonQuery(stockQuery, stockParams);
                }

                MessageBox.Show($"Order #{orderId} completed successfully!\nTotal: {total:N0} VND", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                ClearCart();
                LoadProducts();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error processing order: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Get customer ID or create new customer based on selection
        /// </summary>
        private int GetOrCreateCustomer()
        {
            if (rdoExistingCustomer.Checked)
            {
                if (cboCustomerSelect.SelectedValue != null && int.TryParse(cboCustomerSelect.SelectedValue.ToString(), out int custId))
                {
                    return custId;
                }
                MessageBox.Show("Please select an existing customer!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return 0;
            }
            else
            {
                // New Customer Logic
                string phoneText = txtCustomer.Text.Trim();
                string nameText = txtCustomerName.Text.Trim();
                string addressText = txtAddress.Text.Trim();
                
                // Cleanup placeholders
                if (phoneText == "Phone") phoneText = "";
                if (nameText == "Name") nameText = "";
                
                // Validation
                if (string.IsNullOrEmpty(nameText) || string.IsNullOrEmpty(phoneText))
                {
                     MessageBox.Show("Name and Phone are required for new customers!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                     return 0;
                }

                try
                {
                    // Check if phone exists
                    string checkQuery = "SELECT CustomerId FROM Customers WHERE CustomerPhone = @Phone";
                    SqlParameter[] checkParams = { new SqlParameter("@Phone", phoneText) };
                    object result = DatabaseConnection.ExecuteScalar(checkQuery, checkParams);

                    if (result != null)
                    {
                        // Phone exists, reuse customer? Or warn? 
                        // User prompt implies specific "Existing" mode for searching.
                        // Here we can warn or just use it. Let's warn to be safe, or just use it if names match.
                        // Simplest: Use it.
                        return Convert.ToInt32(result);
                    }
                    else
                    {
                        // Create new
                        string insertQuery = @"INSERT INTO Customers (CustomerName, CustomerPhone, CustomerAddress, CustomerEmail) 
                                              VALUES (@Name, @Phone, @Address, '');
                                              SELECT SCOPE_IDENTITY();";
                        SqlParameter[] insertParams = { 
                            new SqlParameter("@Name", nameText),
                            new SqlParameter("@Phone", phoneText),
                            new SqlParameter("@Address", string.IsNullOrEmpty(addressText) ? "N/A" : addressText)
                        };
                        object newId = DatabaseConnection.ExecuteScalar(insertQuery, insertParams);
                        // Refresh combo logic if needed (optional)
                        LoadCustomersForOrder(); 
                        return Convert.ToInt32(newId);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error creating customer: " + ex.Message, "Error");
                    return 0;
                }
            }
        }

        private void RdoCustomerType_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoExistingCustomer.Checked)
            {
                cboCustomerSelect.Visible = true;
                txtCustomer.Visible = false;
                txtCustomerName.Visible = false;
                txtAddress.Visible = false;
                lblAddress.Visible = false;
                // Labels for Name/Phone handled by visibility of TextBoxes or just hide them too if labels are separate?
                // Designer showed labels. I should hide labels too.
                // Assuming I can access them via Controls or just leave them?
                // Step 1582 Designer showed separate labels: lblPhone, lblName. 
                // They are local variables in InitializeComponent: System.Windows.Forms.Label lblPhone = ...
                // So I cannot access them easily unless I change Designer to make them fields.
                // For now, I will just hide the *Inputs*. The labels might stay visible which is ugly.
                // I'll check Designer again. Yes, `lblPhone` is local.
                // I will ignore labels for now or try to hide `pnlOrderInfo` children by type?
                // Or I can use Controls.Find or loop through Controls.
                // Let's loop pnlOrderInfo.Controls to hide Labels.
                ToggleInputLabels(false);
            }
            else
            {
                cboCustomerSelect.Visible = false;
                txtCustomer.Visible = true;
                txtCustomerName.Visible = true;
                txtAddress.Visible = true;
                lblAddress.Visible = true;
                ToggleInputLabels(true);
            }
        }

        private void ToggleInputLabels(bool visible)
        {
            foreach(Control c in pnlOrderInfo.Controls)
            {
                if (c is Label && (c.Name == "lblPhone" || c.Name == "lblName"))
                {
                    c.Visible = visible;
                }
            }
        }

        /// <summary>
        /// Cancel order / clear cart
        /// </summary>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (cartItems.Count > 0)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to cancel this order?",
                    "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    ClearCart();
                }
            }
        }

        // Search and filter event handlers
        private void txtFindProducts_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtFindProducts.Text;
            string category = cboCategory.SelectedIndex > 0 ? cboCategory.SelectedItem.ToString() : "";
            LoadProducts(keyword, category, chkInStockOnly.Checked);
        }

        private void cboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            string keyword = txtFindProducts.Text == "Find products..." ? "" : txtFindProducts.Text;
            string category = cboCategory.SelectedIndex > 0 ? cboCategory.SelectedItem.ToString() : "";
            LoadProducts(keyword, category, chkInStockOnly.Checked);
        }

        private void chkInStockOnly_CheckedChanged(object sender, EventArgs e)
        {
            string keyword = txtFindProducts.Text == "Find products..." ? "" : txtFindProducts.Text;
            string category = cboCategory.SelectedIndex > 0 ? cboCategory.SelectedItem.ToString() : "";
            LoadProducts(keyword, category, chkInStockOnly.Checked);
        }

        private void txtFindProducts_Enter(object sender, EventArgs e)
        {
            if (txtFindProducts.Text == "Find products...")
            {
                txtFindProducts.Text = "";
            }
        }

        private void txtFindProducts_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFindProducts.Text))
            {
                txtFindProducts.Text = "Find products...";
            }
        }

        private void txtCustomer_Enter(object sender, EventArgs e)
        {
            if (txtCustomer.Text == "Phone")
            {
                txtCustomer.Text = "";
            }
        }

        private void txtCustomer_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCustomer.Text))
            {
                txtCustomer.Text = "Phone";
            }
        }

        private void txtCustomerName_Enter(object sender, EventArgs e)
        {
            if (txtCustomerName.Text == "Name")
            {
                txtCustomerName.Text = "";
            }
        }

        private void txtCustomerName_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCustomerName.Text))
            {
                txtCustomerName.Text = "Name";
            }
        }

        /// <summary>
        /// Remove selected item from cart
        /// </summary>
        private void btnRemoveItem_Click(object sender, EventArgs e)
        {
            if (lstOrderItems.SelectedIndex >= 0 && lstOrderItems.SelectedIndex < cartItems.Count)
            {
                cartItems.RemoveAt(lstOrderItems.SelectedIndex);
                UpdateCartDisplay();
            }
            else
            {
                MessageBox.Show("Please select an item to remove!", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Double-click on list item to remove
        /// </summary>
        private void lstOrderItems_DoubleClick(object sender, EventArgs e)
        {
            if (lstOrderItems.SelectedIndex >= 0 && lstOrderItems.SelectedIndex < cartItems.Count)
            {
                var item = cartItems[lstOrderItems.SelectedIndex];
                if (item.Quantity > 1)
                {
                    item.Quantity--;
                }
                else
                {
                    cartItems.RemoveAt(lstOrderItems.SelectedIndex);
                }
                UpdateCartDisplay();
            }
        }

        /// <summary>
        /// Print receipt
        /// </summary>
        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (cartItems.Count == 0)
            {
                MessageBox.Show("Cart is empty!", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Generate receipt HTML
            decimal total = 0;
            string receiptHtml = @"<!DOCTYPE html>
<html>
<head>
    <meta charset='utf-8'>
    <title>Receipt</title>
    <style>
        body { font-family: Arial; width: 300px; margin: 0 auto; padding: 20px; }
        h2 { text-align: center; }
        table { width: 100%; border-collapse: collapse; }
        td { padding: 5px; border-bottom: 1px dashed #ccc; }
        .total { font-weight: bold; font-size: 16px; border-top: 2px solid #000; }
        .center { text-align: center; }
    </style>
</head>
<body>
    <h2>STORE X</h2>
    <p class='center'>" + DateTime.Now.ToString("dd/MM/yyyy HH:mm") + @"</p>
    <table>";

            foreach (var item in cartItems)
            {
                receiptHtml += $"<tr><td>{item.ProductName} x{item.Quantity}</td><td style='text-align:right'>{(item.Price * item.Quantity):N0}</td></tr>";
                total += item.Price * item.Quantity;
            }

            receiptHtml += $@"</table>
    <table>
        <tr class='total'><td>TOTAL</td><td style='text-align:right'>{total:N0} VND</td></tr>
    </table>
    <p class='center'>Thank you for shopping!</p>
    <script>window.print();</script>
</body>
</html>";

            // Save and open
            string tempPath = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "receipt_" + DateTime.Now.Ticks + ".html");
            System.IO.File.WriteAllText(tempPath, receiptHtml);
            System.Diagnostics.Process.Start(tempPath);
        }

        private void txtFindProducts_TextChanged_1(object sender, EventArgs e)
        {

        }
    }

    /// <summary>
    /// Cart item class
    /// </summary>
    internal class CartItem
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
