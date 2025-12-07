using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Store_X_s_Sales_Management_System.Forms.Shared.UserControls
{
    public partial class ucManageProducts : UserControl
    {
        private DataTable productsDataTable;

        public ucManageProducts()
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
                dgvProducts.ReadOnly = true;
                dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvProducts.MultiSelect = false;

                // Wire up events
                dgvProducts.CellClick += dgvProducts_CellClick;
                btnAdd.Click += btnAdd_Click;
                btnEdit.Click += btnEdit_Click;
                btnInsert.Click += btnAdd_Click; // Same as Add
                btnDelete.Click += btnDelete_Click;
                btnReactivate.Click += btnReactivate_Click;
                btnLowStock.Click += btnLowStock_Click;
                txtSearch.TextChanged += txtSearch_TextChanged;
                txtSearch.Enter += txtSearch_Enter;
                txtSearch.Leave += txtSearch_Leave;
                cboCategory.SelectedIndexChanged += cboCategory_SelectedIndexChanged;
                cboSupplier.SelectedIndexChanged += cboSupplier_SelectedIndexChanged;

                // Load filters
                LoadCategories();
                LoadSuppliers();

                // Load products
                LoadProducts();
                
                // Initialize Tabs
                InitializeTabs();
                tabProducts.SelectedIndexChanged += tabProducts_SelectedIndexChanged;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error initializing: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private DataGridView dgvCategories;
        private TextBox txtCategoryName;
        private TextBox txtCategoryDesc;
        private Button btnAddCategory, btnEditCategory, btnDeleteCategory;
        
        private DataGridView dgvSuppliers;
        private TextBox txtSupplierName, txtSupplierPhone, txtSupplierAddress;
        private Button btnAddSupplier, btnEditSupplier, btnDeleteSupplier;

        private void InitializeTabs()
        {
            SetupCategoryTab();
            SetupSupplierTab();
        }

        private void SetupCategoryTab()
        {
            // Split Container
            SplitContainer split = new SplitContainer();
            split.Dock = DockStyle.Fill;
            split.Orientation = Orientation.Vertical;
            split.SplitterDistance = 600;
            tabCategories.Controls.Add(split);

            // Left: Grid
            dgvCategories = new DataGridView();
            dgvCategories.Dock = DockStyle.Fill;
            dgvCategories.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCategories.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCategories.MultiSelect = false;
            dgvCategories.ReadOnly = true; // Selection only
            dgvCategories.CellClick += (s, e) => {
                if (e.RowIndex >= 0) {
                    var row = dgvCategories.Rows[e.RowIndex];
                    txtCategoryName.Tag = row.Cells["CategoryId"].Value;
                    txtCategoryName.Text = row.Cells["CategoryName"].Value.ToString();
                    if(dgvCategories.Columns.Contains("Description") && row.Cells["Description"].Value != null)
                        txtCategoryDesc.Text = row.Cells["Description"].Value.ToString();
                }
            };
            split.Panel1.Controls.Add(dgvCategories);

            // Right: Inputs
            Panel pnlInputs = new Panel();
            pnlInputs.Dock = DockStyle.Fill;
            pnlInputs.Padding = new Padding(20);
            
            Label lblName = new Label { Text = "Category Name:", Top = 20, Left = 20, AutoSize = true };
            txtCategoryName = new TextBox { Top = 45, Left = 20, Width = 200 };
            
            Label lblDesc = new Label { Text = "Description:", Top = 80, Left = 20, AutoSize = true };
            txtCategoryDesc = new TextBox { Top = 105, Left = 20, Width = 200, Multiline = true, Height = 60 };

            btnAddCategory = CreateButton("Add", 180, Color.FromArgb(40, 167, 69));
            btnEditCategory = CreateButton("Update", 180 + 50, Color.FromArgb(255, 193, 7));
            btnDeleteCategory = CreateButton("Delete", 180 + 100, Color.FromArgb(220, 53, 69));

            btnAddCategory.Click += BtnAddCategory_Click;
            btnEditCategory.Click += BtnEditCategory_Click;
            btnDeleteCategory.Click += BtnDeleteCategory_Click;

            pnlInputs.Controls.AddRange(new Control[] { lblName, txtCategoryName, lblDesc, txtCategoryDesc, btnAddCategory, btnEditCategory, btnDeleteCategory });
            split.Panel2.Controls.Add(pnlInputs);
        }

        private void SetupSupplierTab()
        {
            // Split Container
            SplitContainer split = new SplitContainer();
            split.Dock = DockStyle.Fill;
            split.Orientation = Orientation.Vertical;
            split.SplitterDistance = 600;
            tabSuppliers.Controls.Add(split);

            // Left: Grid
            dgvSuppliers = new DataGridView();
            dgvSuppliers.Dock = DockStyle.Fill;
            dgvSuppliers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSuppliers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSuppliers.MultiSelect = false;
            dgvSuppliers.ReadOnly = true;
             dgvSuppliers.CellClick += (s, e) => {
                if (e.RowIndex >= 0) {
                    var row = dgvSuppliers.Rows[e.RowIndex];
                    txtSupplierName.Tag = row.Cells["SupplierId"].Value;
                    txtSupplierName.Text = row.Cells["SupplierName"].Value.ToString();
                    if(dgvSuppliers.Columns.Contains("SupplierPhone") && row.Cells["SupplierPhone"].Value != null)
                        txtSupplierPhone.Text = row.Cells["SupplierPhone"].Value.ToString();
                    if(dgvSuppliers.Columns.Contains("SupplierAddress") && row.Cells["SupplierAddress"].Value != null)
                        txtSupplierAddress.Text = row.Cells["SupplierAddress"].Value.ToString();
                }
            };
            split.Panel1.Controls.Add(dgvSuppliers);

            // Right: Inputs
            Panel pnlInputs = new Panel();
            pnlInputs.Dock = DockStyle.Fill;
            pnlInputs.Padding = new Padding(20);

            Label lblName = new Label { Text = "Supplier Name:", Top = 20, Left = 20, AutoSize = true };
            txtSupplierName = new TextBox { Top = 45, Left = 20, Width = 200 };

            Label lblPhone = new Label { Text = "Phone:", Top = 80, Left = 20, AutoSize = true };
            txtSupplierPhone = new TextBox { Top = 105, Left = 20, Width = 200 };

            Label lblAddr = new Label { Text = "Address:", Top = 140, Left = 20, AutoSize = true };
            txtSupplierAddress = new TextBox { Top = 165, Left = 20, Width = 200, Multiline=true, Height= 50 };

            btnAddSupplier = CreateButton("Add", 230, Color.FromArgb(40, 167, 69));
            btnEditSupplier = CreateButton("Update", 230 + 50, Color.FromArgb(255, 193, 7));
            btnDeleteSupplier = CreateButton("Delete", 230 + 100, Color.FromArgb(220, 53, 69));

            btnAddSupplier.Click += BtnAddSupplier_Click;
            btnEditSupplier.Click += BtnEditSupplier_Click;
            btnDeleteSupplier.Click += BtnDeleteSupplier_Click;

            pnlInputs.Controls.AddRange(new Control[] { lblName, txtSupplierName, lblPhone, txtSupplierPhone, lblAddr, txtSupplierAddress, btnAddSupplier, btnEditSupplier, btnDeleteSupplier });
            split.Panel2.Controls.Add(pnlInputs);
        }

        private Button CreateButton(string text, int top, Color bg)
        {
            return new Button {
                Text = text,
                Top = top,
                Left = 20,
                Width = 100,
                Height = 35,
                FlatStyle = FlatStyle.Flat,
                BackColor = bg,
                ForeColor = Color.White
            };
        }

        private void tabProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabProducts.SelectedTab == tabCategories)
            {
                LoadCategoriesList();
            }
            else if (tabProducts.SelectedTab == tabSuppliers)
            {
                LoadSuppliersList();
            }
        }
        
        // --- CATEGORY LOGIC ---
        private void LoadCategoriesList()
        {
            try {
                // Try selecting Description, fallback if error? No, just standard try-catch
                // We assume basic columns. If Description missing, we can adjust.
                // Assuming Categories: CategoryId, CategoryName, Description?
                string query = "SELECT * FROM Categories"; 
                DataTable dt = DatabaseConnection.ExecuteQuery(query);
                dgvCategories.DataSource = dt;
                if(dgvCategories.Columns.Contains("CategoryId")) dgvCategories.Columns["CategoryId"].Visible = false;
            } catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void BtnAddCategory_Click(object sender, EventArgs e) {
             try {
                if(string.IsNullOrWhiteSpace(txtCategoryName.Text)) return;
                string query = "INSERT INTO Categories (CategoryName, Description) VALUES (@Name, @Desc)";
                // Fallback query if Description invalid? 
                // Let's assume Description exists.
                SqlParameter[] p = {
                    new SqlParameter("@Name", txtCategoryName.Text),
                    new SqlParameter("@Desc", txtCategoryDesc.Text)
                };
                DatabaseConnection.ExecuteNonQuery(query, p);
                LoadCategoriesList();
                LoadCategories(); // Refresh combo
             } catch(Exception ex) { MessageBox.Show("Error: "+ex.Message); }
        }

        private void BtnEditCategory_Click(object sender, EventArgs e) {
             try {
                if(txtCategoryName.Tag == null) return;
                string query = "UPDATE Categories SET CategoryName=@Name, Description=@Desc WHERE CategoryId=@Id";
                SqlParameter[] p = {
                    new SqlParameter("@Name", txtCategoryName.Text),
                    new SqlParameter("@Desc", txtCategoryDesc.Text),
                    new SqlParameter("@Id", txtCategoryName.Tag)
                };
                DatabaseConnection.ExecuteNonQuery(query, p);
                LoadCategoriesList();
                LoadCategories(); // Refresh combo
             } catch(Exception ex) { MessageBox.Show("Error: "+ex.Message); }
        }

        private void BtnDeleteCategory_Click(object sender, EventArgs e) {
             try {
                if(txtCategoryName.Tag == null) return;
                if(MessageBox.Show("Delete this category?", "Confirm", MessageBoxButtons.YesNo)==DialogResult.Yes) {
                    string query = "DELETE FROM Categories WHERE CategoryId=@Id";
                    SqlParameter[] p = { new SqlParameter("@Id", txtCategoryName.Tag) };
                    DatabaseConnection.ExecuteNonQuery(query, p);
                    LoadCategoriesList();
                    LoadCategories(); // Refresh combo
                }
             } catch(Exception ex) { MessageBox.Show("Error (Constraint?): "+ex.Message); }
        }

        // --- SUPPLIER LOGIC ---
        private void LoadSuppliersList()
        {
            try {
                string query = "SELECT * FROM Suppliers";
                DataTable dt = DatabaseConnection.ExecuteQuery(query);
                dgvSuppliers.DataSource = dt;
                if(dgvSuppliers.Columns.Contains("SupplierId")) dgvSuppliers.Columns["SupplierId"].Visible = false;
            } catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void BtnAddSupplier_Click(object sender, EventArgs e) {
             try {
                if(string.IsNullOrWhiteSpace(txtSupplierName.Text)) return;
                // Assuming columns: SupplierName, SupplierPhone, SupplierAddress
                string query = "INSERT INTO Suppliers (SupplierName, SupplierPhone, SupplierAddress) VALUES (@Name, @Phone, @Addr)";
                SqlParameter[] p = {
                    new SqlParameter("@Name", txtSupplierName.Text),
                    new SqlParameter("@Phone", txtSupplierPhone.Text),
                    new SqlParameter("@Addr", txtSupplierAddress.Text),
                };
                DatabaseConnection.ExecuteNonQuery(query, p);
                LoadSuppliersList();
                LoadSuppliers(); // Refresh combo
             } catch(Exception ex) { MessageBox.Show("Error: "+ex.Message); }
        }

         private void BtnEditSupplier_Click(object sender, EventArgs e) {
             try {
                if(txtSupplierName.Tag == null) return;
                string query = "UPDATE Suppliers SET SupplierName=@Name, SupplierPhone=@Phone, SupplierAddress=@Addr WHERE SupplierId=@Id";
                SqlParameter[] p = {
                    new SqlParameter("@Name", txtSupplierName.Text),
                    new SqlParameter("@Phone", txtSupplierPhone.Text),
                    new SqlParameter("@Addr", txtSupplierAddress.Text),
                    new SqlParameter("@Id", txtSupplierName.Tag)
                };
                DatabaseConnection.ExecuteNonQuery(query, p);
                LoadSuppliersList();
                LoadSuppliers(); // Refresh combo
             } catch(Exception ex) { MessageBox.Show("Error: "+ex.Message); }
        }

        private void BtnDeleteSupplier_Click(object sender, EventArgs e) {
             try {
                if(txtSupplierName.Tag == null) return;
                if(MessageBox.Show("Delete this supplier?", "Confirm", MessageBoxButtons.YesNo)==DialogResult.Yes) {
                    string query = "DELETE FROM Suppliers WHERE SupplierId=@Id";
                    SqlParameter[] p = { new SqlParameter("@Id", txtSupplierName.Tag) };
                    DatabaseConnection.ExecuteNonQuery(query, p);
                    LoadSuppliersList();
                    LoadSuppliers(); // Refresh combo
                }
             } catch(Exception ex) { MessageBox.Show("Error: "+ex.Message); }
        }

        /// <summary>
        /// Load categories into filter
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
        /// Load suppliers into filter
        /// </summary>
        private void LoadSuppliers()
        {
            try
            {
                cboSupplier.Items.Clear();
                cboSupplier.Items.Add("All Suppliers");

                string query = "SELECT SupplierName FROM Suppliers ORDER BY SupplierName";
                DataTable dt = DatabaseConnection.ExecuteQuery(query, null);
                foreach (DataRow row in dt.Rows)
                {
                    cboSupplier.Items.Add(row["SupplierName"].ToString());
                }
                cboSupplier.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading suppliers: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Load product list from database
        /// </summary>
        private void LoadProducts(string categoryFilter = "", string supplierFilter = "", string searchKeyword = "", bool lowStockOnly = false)
        {
            try
            {
                string query = @"SELECT 
                    p.ProductId,
                    p.ProductName,
                    c.CategoryName,
                    s.SupplierName,
                    p.ProductPrice,
                    p.StockQuantity,
                    p.ProductDescription
                FROM Products p
                INNER JOIN Categories c ON p.CategoryId = c.CategoryId
                INNER JOIN Suppliers s ON p.SupplierId = s.SupplierId
                WHERE 1=1";

                var paramList = new System.Collections.Generic.List<SqlParameter>();

                if (!string.IsNullOrEmpty(categoryFilter) && categoryFilter != "All Categories")
                {
                    query += " AND c.CategoryName = @Category";
                    paramList.Add(new SqlParameter("@Category", categoryFilter));
                }

                if (!string.IsNullOrEmpty(supplierFilter) && supplierFilter != "All Suppliers")
                {
                    query += " AND s.SupplierName = @Supplier";
                    paramList.Add(new SqlParameter("@Supplier", supplierFilter));
                }

                if (!string.IsNullOrEmpty(searchKeyword) && searchKeyword != "Search...")
                {
                    query += " AND (p.ProductName LIKE @Keyword OR p.ProductDescription LIKE @Keyword)";
                    paramList.Add(new SqlParameter("@Keyword", "%" + searchKeyword + "%"));
                }

                if (lowStockOnly)
                {
                    query += " AND p.StockQuantity < 10";
                }

                query += " ORDER BY p.ProductName";

                productsDataTable = DatabaseConnection.ExecuteQuery(query, paramList.ToArray());

                // Display in grid
                dgvProducts.Rows.Clear();
                foreach (DataRow row in productsDataTable.Rows)
                {
                    string productName = row["ProductName"].ToString();
                    int stock = Convert.ToInt32(row["StockQuantity"]);
                    bool isDiscontinued = productName.StartsWith("[DISCONTINUED]");
                    
                    // Display name is just the product name (prefix already in DB)
                    string displayName = productName;
                    
                    string displayStock = isDiscontinued ? "N/A" : stock.ToString();
                    
                    int rowIndex = dgvProducts.Rows.Add(
                        row["ProductId"],
                        displayName,
                        row["CategoryName"],
                        row["SupplierName"],
                        "-", // Import price (not in schema)
                        Convert.ToDecimal(row["ProductPrice"]).ToString("N0"),
                        displayStock
                    );

                    // Style discontinued products with gray background
                    if (isDiscontinued)
                    {
                        dgvProducts.Rows[rowIndex].DefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);
                        dgvProducts.Rows[rowIndex].DefaultCellStyle.ForeColor = Color.Gray;
                    }
                    // Highlight low stock (but not discontinued)
                    else if (stock < 10)
                    {
                        dgvProducts.Rows[rowIndex].Cells["colStock"].Style.BackColor = Color.LightCoral;
                    }
                }

                // Update pagination
                lblPagination.Text = $"Showing {productsDataTable.Rows.Count} products";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading products: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Add new product
        /// </summary>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            ShowProductDialog(null);
        }

        /// <summary>
        /// Edit selected product
        /// </summary>
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvProducts.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a product to edit!", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int productId = Convert.ToInt32(dgvProducts.SelectedRows[0].Cells["colId"].Value);
            string productName = dgvProducts.SelectedRows[0].Cells["colName"].Value?.ToString();

            if (productName.StartsWith("[DISCONTINUED]"))
            {
                MessageBox.Show("Cannot edit a discontinued product! Please reactivate first.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ShowProductDialog(productId);
        }

        /// <summary>
        /// Show product add/edit dialog
        /// </summary>
        private void ShowProductDialog(int? productId)
        {
            using (Form dialog = new Form())
            {
                dialog.Text = productId.HasValue ? "Edit Product" : "Add New Product";
                dialog.Size = new Size(450, 400);
                dialog.StartPosition = FormStartPosition.CenterParent;
                dialog.FormBorderStyle = FormBorderStyle.FixedDialog;
                dialog.MaximizeBox = false;
                dialog.MinimizeBox = false;

                // Controls
                Label lblName = new Label() { Text = "Product Name:", Location = new Point(20, 30), AutoSize = true };
                TextBox txtName = new TextBox() { Location = new Point(150, 27), Width = 260 };

                Label lblCategory = new Label() { Text = "Category:", Location = new Point(20, 70), AutoSize = true };
                ComboBox cboDialogCategory = new ComboBox() { Location = new Point(150, 67), Width = 260, DropDownStyle = ComboBoxStyle.DropDownList };

                Label lblSupplier = new Label() { Text = "Supplier:", Location = new Point(20, 110), AutoSize = true };
                ComboBox cboDialogSupplier = new ComboBox() { Location = new Point(150, 107), Width = 260, DropDownStyle = ComboBoxStyle.DropDownList };

                Label lblPrice = new Label() { Text = "Price:", Location = new Point(20, 150), AutoSize = true };
                TextBox txtPrice = new TextBox() { Location = new Point(150, 147), Width = 260 };

                Label lblStock = new Label() { Text = "Stock Quantity:", Location = new Point(20, 190), AutoSize = true };
                NumericUpDown nudStock = new NumericUpDown() { Location = new Point(150, 187), Width = 260, Maximum = 100000, Minimum = 0 };

                Label lblDesc = new Label() { Text = "Description:", Location = new Point(20, 230), AutoSize = true };
                TextBox txtDesc = new TextBox() { Location = new Point(150, 227), Width = 260, Height = 60, Multiline = true };

                Button btnSave = new Button() { Text = "Save", Location = new Point(150, 310), Width = 100, DialogResult = DialogResult.OK };
                Button btnCancel = new Button() { Text = "Cancel", Location = new Point(260, 310), Width = 100, DialogResult = DialogResult.Cancel };

                dialog.Controls.AddRange(new Control[] { lblName, txtName, lblCategory, cboDialogCategory,
                    lblSupplier, cboDialogSupplier, lblPrice, txtPrice, lblStock, nudStock, lblDesc, txtDesc, btnSave, btnCancel });
                dialog.AcceptButton = btnSave;
                dialog.CancelButton = btnCancel;

                // Load categories and suppliers
                string catQuery = "SELECT CategoryId, CategoryName FROM Categories ORDER BY CategoryName";
                DataTable catDt = DatabaseConnection.ExecuteQuery(catQuery, null);
                cboDialogCategory.DisplayMember = "CategoryName";
                cboDialogCategory.ValueMember = "CategoryId";
                cboDialogCategory.DataSource = catDt;

                string supQuery = "SELECT SupplierId, SupplierName FROM Suppliers ORDER BY SupplierName";
                DataTable supDt = DatabaseConnection.ExecuteQuery(supQuery, null);
                cboDialogSupplier.DisplayMember = "SupplierName";
                cboDialogSupplier.ValueMember = "SupplierId";
                cboDialogSupplier.DataSource = supDt;

                // If editing, load existing data
                if (productId.HasValue)
                {
                    string prodQuery = @"SELECT ProductName, CategoryId, SupplierId, ProductPrice, StockQuantity, ProductDescription 
                                        FROM Products WHERE ProductId = @ProductId";
                    SqlParameter[] prodParams = { new SqlParameter("@ProductId", productId.Value) };
                    DataTable prodDt = DatabaseConnection.ExecuteQuery(prodQuery, prodParams);
                    if (prodDt.Rows.Count > 0)
                    {
                        DataRow row = prodDt.Rows[0];
                        txtName.Text = row["ProductName"].ToString();
                        cboDialogCategory.SelectedValue = row["CategoryId"];
                        cboDialogSupplier.SelectedValue = row["SupplierId"];
                        txtPrice.Text = row["ProductPrice"].ToString();
                        nudStock.Value = Convert.ToDecimal(row["StockQuantity"]);
                        txtDesc.Text = row["ProductDescription"]?.ToString() ?? "";
                    }
                }

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    // Validate
                    if (string.IsNullOrWhiteSpace(txtName.Text))
                    {
                        MessageBox.Show("Please enter product name!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (!decimal.TryParse(txtPrice.Text, out decimal price) || price <= 0)
                    {
                        MessageBox.Show("Please enter a valid price!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    try
                    {
                        if (productId.HasValue)
                        {
                            // Update
                            string updateQuery = @"UPDATE Products SET ProductName = @Name, CategoryId = @CategoryId, 
                                SupplierId = @SupplierId, ProductPrice = @Price, StockQuantity = @Stock, ProductDescription = @Desc
                                WHERE ProductId = @ProductId";
                            SqlParameter[] updateParams = {
                                new SqlParameter("@Name", txtName.Text.Trim()),
                                new SqlParameter("@CategoryId", cboDialogCategory.SelectedValue),
                                new SqlParameter("@SupplierId", cboDialogSupplier.SelectedValue),
                                new SqlParameter("@Price", price),
                                new SqlParameter("@Stock", (int)nudStock.Value),
                                new SqlParameter("@Desc", txtDesc.Text.Trim()),
                                new SqlParameter("@ProductId", productId.Value)
                            };
                            DatabaseConnection.ExecuteNonQuery(updateQuery, updateParams);
                            MessageBox.Show("Product updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            // Insert
                            string insertQuery = @"INSERT INTO Products (ProductName, CategoryId, SupplierId, ProductPrice, StockQuantity, ProductDescription)
                                VALUES (@Name, @CategoryId, @SupplierId, @Price, @Stock, @Desc)";
                            SqlParameter[] insertParams = {
                                new SqlParameter("@Name", txtName.Text.Trim()),
                                new SqlParameter("@CategoryId", cboDialogCategory.SelectedValue),
                                new SqlParameter("@SupplierId", cboDialogSupplier.SelectedValue),
                                new SqlParameter("@Price", price),
                                new SqlParameter("@Stock", (int)nudStock.Value),
                                new SqlParameter("@Desc", txtDesc.Text.Trim())
                            };
                            DatabaseConnection.ExecuteNonQuery(insertQuery, insertParams);
                            MessageBox.Show("Product added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        LoadProducts();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error saving product: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        /// <summary>
        /// Discontinue selected product (Soft Delete - set StockQuantity = -1)
        /// </summary>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvProducts.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a product!", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int productId = Convert.ToInt32(dgvProducts.SelectedRows[0].Cells["colId"].Value);
            string productName = dgvProducts.SelectedRows[0].Cells["colName"].Value?.ToString();
            
            // Check if already discontinued
            // Check if already discontinued
            if (productName.StartsWith("[DISCONTINUED]"))
            {
                MessageBox.Show("This product is already discontinued!", "Info",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult result = MessageBox.Show(
                $"Are you sure you want to discontinue product '{productName}'?\n\nThe product will not be available for new orders.",
                "Confirm Discontinue", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    // Soft delete: Add [NGỪNG KD] prefix and set StockQuantity = 0
                    string newName = "[DISCONTINUED] " + productName;
                    string updateQuery = "UPDATE Products SET ProductName = @NewName, StockQuantity = 0 WHERE ProductId = @ProductId";
                    SqlParameter[] updateParams = { 
                        new SqlParameter("@NewName", newName),
                        new SqlParameter("@ProductId", productId) 
                    };
                    DatabaseConnection.ExecuteNonQuery(updateQuery, updateParams);

                    MessageBox.Show("Product discontinued successfully!", "Success", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadProducts();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        
        /// <summary>
        /// Reactivate discontinued product
        /// </summary>
        private void btnReactivate_Click(object sender, EventArgs e)
        {
            if (dgvProducts.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a product!", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int productId = Convert.ToInt32(dgvProducts.SelectedRows[0].Cells["colId"].Value);
            string productName = dgvProducts.SelectedRows[0].Cells["colName"].Value?.ToString();
            
            // Check if actually discontinued
            // Check if product is discontinued
            if (!productName.StartsWith("[DISCONTINUED]"))
            {
                MessageBox.Show("This product is not discontinued!", "Info",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult result = MessageBox.Show(
                $"Do you want to reactivate product '{productName.Replace("[DISCONTINUED] ", "")}'?",
                "Confirm Reactivation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    string originalName = productName.Replace("[DISCONTINUED] ", "");
                    string updateQuery = "UPDATE Products SET ProductName = @NewName WHERE ProductId = @ProductId";
                    SqlParameter[] updateParams = { 
                        new SqlParameter("@NewName", originalName),
                        new SqlParameter("@ProductId", productId) 
                    };
                    DatabaseConnection.ExecuteNonQuery(updateQuery, updateParams);

                    MessageBox.Show("Product reactivated successfully!", "Success", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadProducts();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Show low stock products only
        /// </summary>
        private void btnLowStock_Click(object sender, EventArgs e)
        {
            LoadProducts("", "", "", true);
        }

        /// <summary>
        /// Import stock
        /// </summary>
        private void btnImportStock_Click(object sender, EventArgs e)
        {
            if (dgvProducts.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a product!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int productId = Convert.ToInt32(dgvProducts.SelectedRows[0].Cells["colId"].Value);
            string productName = dgvProducts.SelectedRows[0].Cells["colName"].Value?.ToString();

            using (Form dialog = new Form())
            {
                dialog.Text = "Import Stock - " + productName;
                dialog.Size = new Size(300, 150);
                dialog.StartPosition = FormStartPosition.CenterParent;
                dialog.FormBorderStyle = FormBorderStyle.FixedDialog;

                Label lblQty = new Label() { Text = "Quantity:", Location = new Point(20, 30), AutoSize = true };
                NumericUpDown nudQty = new NumericUpDown() { Location = new Point(100, 27), Width = 160, Minimum = 1, Maximum = 10000, Value = 10 };
                Button btnOK = new Button() { Text = "Import", Location = new Point(50, 70), Width = 80, DialogResult = DialogResult.OK };
                Button btnCancel = new Button() { Text = "Cancel", Location = new Point(150, 70), Width = 80, DialogResult = DialogResult.Cancel };

                dialog.Controls.AddRange(new Control[] { lblQty, nudQty, btnOK, btnCancel });

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    string query = "UPDATE Products SET StockQuantity = StockQuantity + @Quantity WHERE ProductId = @ProductId";
                    SqlParameter[] parameters = {
                        new SqlParameter("@Quantity", (int)nudQty.Value),
                        new SqlParameter("@ProductId", productId)
                    };
                    DatabaseConnection.ExecuteNonQuery(query, parameters);
                    MessageBox.Show($"Imported {nudQty.Value} units successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadProducts();
                }
            }
        }

        /// <summary>
        /// Export stock
        /// </summary>
        private void btnExportStock_Click(object sender, EventArgs e)
        {
            if (dgvProducts.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a product!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int productId = Convert.ToInt32(dgvProducts.SelectedRows[0].Cells["colId"].Value);
            string productName = dgvProducts.SelectedRows[0].Cells["colName"].Value?.ToString();
            int currentStock = Convert.ToInt32(dgvProducts.SelectedRows[0].Cells["colStock"].Value);

            using (Form dialog = new Form())
            {
                dialog.Text = "Export Stock - " + productName;
                dialog.Size = new Size(300, 150);
                dialog.StartPosition = FormStartPosition.CenterParent;

                Label lblQty = new Label() { Text = "Quantity:", Location = new Point(20, 30), AutoSize = true };
                NumericUpDown nudQty = new NumericUpDown() { Location = new Point(100, 27), Width = 160, Minimum = 1, Maximum = currentStock, Value = 1 };
                Button btnOK = new Button() { Text = "Export", Location = new Point(50, 70), Width = 80, DialogResult = DialogResult.OK };
                Button btnCancel = new Button() { Text = "Cancel", Location = new Point(150, 70), Width = 80, DialogResult = DialogResult.Cancel };

                dialog.Controls.AddRange(new Control[] { lblQty, nudQty, btnOK, btnCancel });

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    string query = "UPDATE Products SET StockQuantity = StockQuantity - @Quantity WHERE ProductId = @ProductId AND StockQuantity >= @Quantity";
                    SqlParameter[] parameters = {
                        new SqlParameter("@Quantity", (int)nudQty.Value),
                        new SqlParameter("@ProductId", productId)
                    };
                    int rows = DatabaseConnection.ExecuteNonQuery(query, parameters);
                    if (rows > 0)
                    {
                        MessageBox.Show($"Exported {nudQty.Value} units successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadProducts();
                    }
                    else
                    {
                        MessageBox.Show("Not enough stock!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }



        // Filter event handlers
        private void cboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void dgvProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cboSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void ApplyFilters()
        {
            string category = cboCategory.SelectedIndex > 0 ? cboCategory.SelectedItem.ToString() : "";
            string supplier = cboSupplier.SelectedIndex > 0 ? cboSupplier.SelectedItem.ToString() : "";
            string keyword = txtSearch.Text;
            LoadProducts(category, supplier, keyword, false);
        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Search...")
            {
                txtSearch.Text = "";
            }
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                txtSearch.Text = "Search...";
            }
        }

        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Optional: highlight selected row
        }
    }
}
