namespace Store_X_s_Sales_Management_System.Forms.Shared.UserControls
{
    partial class ucCreateOrder
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.pnlProductSelection = new System.Windows.Forms.Panel();
            this.dgvProducts = new System.Windows.Forms.DataGridView();
            this.colProductId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlAddToCart = new System.Windows.Forms.Panel();
            this.btnAddToCart = new System.Windows.Forms.Button();
            this.nudQuantity = new System.Windows.Forms.NumericUpDown();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.pnlProductFilters = new System.Windows.Forms.Panel();
            this.txtSearchProduct = new System.Windows.Forms.TextBox();
            this.cboCategory = new System.Windows.Forms.ComboBox();
            this.lblProductListTitle = new System.Windows.Forms.Label();
            this.pnlCart = new System.Windows.Forms.Panel();
            this.pnlCartItems = new System.Windows.Forms.Panel();
            this.dgvCart = new System.Windows.Forms.DataGridView();
            this.colCartProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCartQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCartUnitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCartSubtotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlCartControls = new System.Windows.Forms.Panel();
            this.btnRemoveItem = new System.Windows.Forms.Button();
            this.btnClearCart = new System.Windows.Forms.Button();
            this.lblCartTitle = new System.Windows.Forms.Label();
            this.pnlOrderSummary = new System.Windows.Forms.Panel();
            this.btnPlaceOrder = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.lblTotalLabel = new System.Windows.Forms.Label();
            this.lblDiscountAmount = new System.Windows.Forms.Label();
            this.lblDiscountLabel = new System.Windows.Forms.Label();
            this.lblSubtotalAmount = new System.Windows.Forms.Label();
            this.lblSubtotalLabel = new System.Windows.Forms.Label();
            this.pnlCustomerInfo = new System.Windows.Forms.Panel();
            this.cboPaymentMethod = new System.Windows.Forms.ComboBox();
            this.lblPaymentMethod = new System.Windows.Forms.Label();
            this.txtCustomerPhone = new System.Windows.Forms.TextBox();
            this.lblCustomerPhone = new System.Windows.Forms.Label();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.lblCustomerInfoTitle = new System.Windows.Forms.Label();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.pnlProductSelection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            this.pnlAddToCart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).BeginInit();
            this.pnlProductFilters.SuspendLayout();
            this.pnlCart.SuspendLayout();
            this.pnlCartItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).BeginInit();
            this.pnlCartControls.SuspendLayout();
            this.pnlOrderSummary.SuspendLayout();
            this.pnlCustomerInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1233, 60);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(269, 36);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Create New Order";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 60);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.pnlProductSelection);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.pnlCart);
            this.splitContainer1.Size = new System.Drawing.Size(1233, 740);
            this.splitContainer1.SplitterDistance = 667;
            this.splitContainer1.TabIndex = 1;
            // 
            // pnlProductSelection
            // 
            this.pnlProductSelection.BackColor = System.Drawing.Color.White;
            this.pnlProductSelection.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlProductSelection.Controls.Add(this.dgvProducts);
            this.pnlProductSelection.Controls.Add(this.pnlAddToCart);
            this.pnlProductSelection.Controls.Add(this.pnlProductFilters);
            this.pnlProductSelection.Controls.Add(this.lblProductListTitle);
            this.pnlProductSelection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlProductSelection.Location = new System.Drawing.Point(0, 0);
            this.pnlProductSelection.Name = "pnlProductSelection";
            this.pnlProductSelection.Size = new System.Drawing.Size(667, 740);
            this.pnlProductSelection.TabIndex = 0;
            // 
            // dgvProducts
            // 
            this.dgvProducts.AllowUserToAddRows = false;
            this.dgvProducts.AllowUserToDeleteRows = false;
            this.dgvProducts.BackgroundColor = System.Drawing.Color.White;
            this.dgvProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProducts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colProductId,
            this.colProductName,
            this.colCategory,
            this.colPrice,
            this.colStock});
            this.dgvProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProducts.Location = new System.Drawing.Point(0, 95);
            this.dgvProducts.MultiSelect = false;
            this.dgvProducts.Name = "dgvProducts";
            this.dgvProducts.ReadOnly = true;
            this.dgvProducts.RowHeadersWidth = 51;
            this.dgvProducts.RowTemplate.Height = 30;
            this.dgvProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProducts.Size = new System.Drawing.Size(665, 575);
            this.dgvProducts.TabIndex = 2;
            this.dgvProducts.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProducts_CellContentClick);
            // 
            // colProductId
            // 
            this.colProductId.HeaderText = "ID";
            this.colProductId.MinimumWidth = 6;
            this.colProductId.Name = "colProductId";
            this.colProductId.ReadOnly = true;
            this.colProductId.Width = 50;
            // 
            // colProductName
            // 
            this.colProductName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colProductName.HeaderText = "Product Name";
            this.colProductName.MinimumWidth = 6;
            this.colProductName.Name = "colProductName";
            this.colProductName.ReadOnly = true;
            // 
            // colCategory
            // 
            this.colCategory.HeaderText = "Category";
            this.colCategory.MinimumWidth = 6;
            this.colCategory.Name = "colCategory";
            this.colCategory.ReadOnly = true;
            this.colCategory.Width = 125;
            // 
            // colPrice
            // 
            this.colPrice.HeaderText = "Price";
            this.colPrice.MinimumWidth = 6;
            this.colPrice.Name = "colPrice";
            this.colPrice.ReadOnly = true;
            this.colPrice.Width = 125;
            // 
            // colStock
            // 
            this.colStock.HeaderText = "Stock";
            this.colStock.MinimumWidth = 6;
            this.colStock.Name = "colStock";
            this.colStock.ReadOnly = true;
            this.colStock.Width = 70;
            // 
            // pnlAddToCart
            // 
            this.pnlAddToCart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.pnlAddToCart.Controls.Add(this.btnAddToCart);
            this.pnlAddToCart.Controls.Add(this.nudQuantity);
            this.pnlAddToCart.Controls.Add(this.lblQuantity);
            this.pnlAddToCart.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlAddToCart.Location = new System.Drawing.Point(0, 670);
            this.pnlAddToCart.Name = "pnlAddToCart";
            this.pnlAddToCart.Size = new System.Drawing.Size(665, 68);
            this.pnlAddToCart.TabIndex = 3;
            // 
            // btnAddToCart
            // 
            this.btnAddToCart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnAddToCart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddToCart.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.btnAddToCart.ForeColor = System.Drawing.Color.White;
            this.btnAddToCart.Location = new System.Drawing.Point(220, 12);
            this.btnAddToCart.Name = "btnAddToCart";
            this.btnAddToCart.Size = new System.Drawing.Size(200, 45);
            this.btnAddToCart.TabIndex = 2;
            this.btnAddToCart.Text = "➕ Add to Cart";
            this.btnAddToCart.UseVisualStyleBackColor = false;
            // 
            // nudQuantity
            // 
            this.nudQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.nudQuantity.Location = new System.Drawing.Point(100, 18);
            this.nudQuantity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudQuantity.Name = "nudQuantity";
            this.nudQuantity.Size = new System.Drawing.Size(80, 30);
            this.nudQuantity.TabIndex = 1;
            this.nudQuantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblQuantity.Location = new System.Drawing.Point(20, 23);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(76, 20);
            this.lblQuantity.TabIndex = 0;
            this.lblQuantity.Text = "Quantity:";
            // 
            // pnlProductFilters
            // 
            this.pnlProductFilters.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlProductFilters.Controls.Add(this.txtSearchProduct);
            this.pnlProductFilters.Controls.Add(this.cboCategory);
            this.pnlProductFilters.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlProductFilters.Location = new System.Drawing.Point(0, 45);
            this.pnlProductFilters.Name = "pnlProductFilters";
            this.pnlProductFilters.Size = new System.Drawing.Size(665, 50);
            this.pnlProductFilters.TabIndex = 1;
            // 
            // txtSearchProduct
            // 
            this.txtSearchProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtSearchProduct.Location = new System.Drawing.Point(10, 12);
            this.txtSearchProduct.Name = "txtSearchProduct";
            this.txtSearchProduct.Size = new System.Drawing.Size(250, 26);
            this.txtSearchProduct.TabIndex = 0;
            this.txtSearchProduct.Text = "🔍 Search product...";
            // 
            // cboCategory
            // 
            this.cboCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cboCategory.FormattingEnabled = true;
            this.cboCategory.Location = new System.Drawing.Point(280, 11);
            this.cboCategory.Name = "cboCategory";
            this.cboCategory.Size = new System.Drawing.Size(180, 28);
            this.cboCategory.TabIndex = 1;
            this.cboCategory.Text = "All Categories";
            // 
            // lblProductListTitle
            // 
            this.lblProductListTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.lblProductListTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblProductListTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductListTitle.Location = new System.Drawing.Point(0, 0);
            this.lblProductListTitle.Name = "lblProductListTitle";
            this.lblProductListTitle.Padding = new System.Windows.Forms.Padding(10);
            this.lblProductListTitle.Size = new System.Drawing.Size(665, 45);
            this.lblProductListTitle.TabIndex = 0;
            this.lblProductListTitle.Text = "📦 Select Products";
            this.lblProductListTitle.Click += new System.EventHandler(this.lblProductListTitle_Click);
            // 
            // pnlCart
            // 
            this.pnlCart.BackColor = System.Drawing.Color.White;
            this.pnlCart.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCart.Controls.Add(this.pnlCartItems);
            this.pnlCart.Controls.Add(this.pnlOrderSummary);
            this.pnlCart.Controls.Add(this.pnlCustomerInfo);
            this.pnlCart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCart.Location = new System.Drawing.Point(0, 0);
            this.pnlCart.Name = "pnlCart";
            this.pnlCart.Size = new System.Drawing.Size(562, 740);
            this.pnlCart.TabIndex = 0;
            // 
            // pnlCartItems
            // 
            this.pnlCartItems.Controls.Add(this.dgvCart);
            this.pnlCartItems.Controls.Add(this.pnlCartControls);
            this.pnlCartItems.Controls.Add(this.lblCartTitle);
            this.pnlCartItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCartItems.Location = new System.Drawing.Point(0, 180);
            this.pnlCartItems.Name = "pnlCartItems";
            this.pnlCartItems.Size = new System.Drawing.Size(560, 360);
            this.pnlCartItems.TabIndex = 1;
            // 
            // dgvCart
            // 
            this.dgvCart.AllowUserToAddRows = false;
            this.dgvCart.AllowUserToDeleteRows = false;
            this.dgvCart.BackgroundColor = System.Drawing.Color.White;
            this.dgvCart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCart.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCartProductName,
            this.colCartQuantity,
            this.colCartUnitPrice,
            this.colCartSubtotal});
            this.dgvCart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCart.Location = new System.Drawing.Point(0, 40);
            this.dgvCart.MultiSelect = false;
            this.dgvCart.Name = "dgvCart";
            this.dgvCart.ReadOnly = true;
            this.dgvCart.RowHeadersWidth = 51;
            this.dgvCart.RowTemplate.Height = 28;
            this.dgvCart.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCart.Size = new System.Drawing.Size(460, 320);
            this.dgvCart.TabIndex = 1;
            // 
            // colCartProductName
            // 
            this.colCartProductName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colCartProductName.HeaderText = "Product";
            this.colCartProductName.MinimumWidth = 6;
            this.colCartProductName.Name = "colCartProductName";
            this.colCartProductName.ReadOnly = true;
            // 
            // colCartQuantity
            // 
            this.colCartQuantity.HeaderText = "Qty";
            this.colCartQuantity.MinimumWidth = 6;
            this.colCartQuantity.Name = "colCartQuantity";
            this.colCartQuantity.ReadOnly = true;
            this.colCartQuantity.Width = 50;
            // 
            // colCartUnitPrice
            // 
            this.colCartUnitPrice.HeaderText = "Price";
            this.colCartUnitPrice.MinimumWidth = 6;
            this.colCartUnitPrice.Name = "colCartUnitPrice";
            this.colCartUnitPrice.ReadOnly = true;
            this.colCartUnitPrice.Width = 80;
            // 
            // colCartSubtotal
            // 
            this.colCartSubtotal.HeaderText = "Subtotal";
            this.colCartSubtotal.MinimumWidth = 6;
            this.colCartSubtotal.Name = "colCartSubtotal";
            this.colCartSubtotal.ReadOnly = true;
            this.colCartSubtotal.Width = 90;
            // 
            // pnlCartControls
            // 
            this.pnlCartControls.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlCartControls.Controls.Add(this.btnRemoveItem);
            this.pnlCartControls.Controls.Add(this.btnClearCart);
            this.pnlCartControls.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlCartControls.Location = new System.Drawing.Point(460, 40);
            this.pnlCartControls.Name = "pnlCartControls";
            this.pnlCartControls.Size = new System.Drawing.Size(100, 320);
            this.pnlCartControls.TabIndex = 2;
            // 
            // btnRemoveItem
            // 
            this.btnRemoveItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnRemoveItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.btnRemoveItem.ForeColor = System.Drawing.Color.White;
            this.btnRemoveItem.Location = new System.Drawing.Point(10, 20);
            this.btnRemoveItem.Name = "btnRemoveItem";
            this.btnRemoveItem.Size = new System.Drawing.Size(80, 50);
            this.btnRemoveItem.TabIndex = 0;
            this.btnRemoveItem.Text = "Remove";
            this.btnRemoveItem.UseVisualStyleBackColor = false;
            // 
            // btnClearCart
            // 
            this.btnClearCart.BackColor = System.Drawing.Color.Gray;
            this.btnClearCart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearCart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.btnClearCart.ForeColor = System.Drawing.Color.White;
            this.btnClearCart.Location = new System.Drawing.Point(10, 80);
            this.btnClearCart.Name = "btnClearCart";
            this.btnClearCart.Size = new System.Drawing.Size(80, 50);
            this.btnClearCart.TabIndex = 1;
            this.btnClearCart.Text = "Clear All";
            this.btnClearCart.UseVisualStyleBackColor = false;
            // 
            // lblCartTitle
            // 
            this.lblCartTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.lblCartTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCartTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.lblCartTitle.ForeColor = System.Drawing.Color.White;
            this.lblCartTitle.Location = new System.Drawing.Point(0, 0);
            this.lblCartTitle.Name = "lblCartTitle";
            this.lblCartTitle.Padding = new System.Windows.Forms.Padding(10);
            this.lblCartTitle.Size = new System.Drawing.Size(560, 40);
            this.lblCartTitle.TabIndex = 0;
            this.lblCartTitle.Text = "🛒 Shopping Cart";
            // 
            // pnlOrderSummary
            // 
            this.pnlOrderSummary.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.pnlOrderSummary.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlOrderSummary.Controls.Add(this.btnPlaceOrder);
            this.pnlOrderSummary.Controls.Add(this.btnCancel);
            this.pnlOrderSummary.Controls.Add(this.lblTotalAmount);
            this.pnlOrderSummary.Controls.Add(this.lblTotalLabel);
            this.pnlOrderSummary.Controls.Add(this.lblDiscountAmount);
            this.pnlOrderSummary.Controls.Add(this.lblDiscountLabel);
            this.pnlOrderSummary.Controls.Add(this.lblSubtotalAmount);
            this.pnlOrderSummary.Controls.Add(this.lblSubtotalLabel);
            this.pnlOrderSummary.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlOrderSummary.Location = new System.Drawing.Point(0, 540);
            this.pnlOrderSummary.Name = "pnlOrderSummary";
            this.pnlOrderSummary.Size = new System.Drawing.Size(560, 198);
            this.pnlOrderSummary.TabIndex = 2;
            // 
            // btnPlaceOrder
            // 
            this.btnPlaceOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPlaceOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnPlaceOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlaceOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.btnPlaceOrder.ForeColor = System.Drawing.Color.White;
            this.btnPlaceOrder.Location = new System.Drawing.Point(216, 130);
            this.btnPlaceOrder.Name = "btnPlaceOrder";
            this.btnPlaceOrder.Size = new System.Drawing.Size(320, 55);
            this.btnPlaceOrder.TabIndex = 7;
            this.btnPlaceOrder.Text = "✅ Place Order";
            this.btnPlaceOrder.UseVisualStyleBackColor = false;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Gray;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(20, 130);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(150, 55);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "❌ Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.lblTotalAmount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.lblTotalAmount.Location = new System.Drawing.Point(316, 75);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(220, 35);
            this.lblTotalAmount.TabIndex = 5;
            this.lblTotalAmount.Text = "$0.00";
            this.lblTotalAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTotalLabel
            // 
            this.lblTotalLabel.AutoSize = true;
            this.lblTotalLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.lblTotalLabel.Location = new System.Drawing.Point(20, 80);
            this.lblTotalLabel.Name = "lblTotalLabel";
            this.lblTotalLabel.Size = new System.Drawing.Size(80, 29);
            this.lblTotalLabel.TabIndex = 4;
            this.lblTotalLabel.Text = "Total:";
            // 
            // lblDiscountAmount
            // 
            this.lblDiscountAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDiscountAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lblDiscountAmount.ForeColor = System.Drawing.Color.Green;
            this.lblDiscountAmount.Location = new System.Drawing.Point(366, 45);
            this.lblDiscountAmount.Name = "lblDiscountAmount";
            this.lblDiscountAmount.Size = new System.Drawing.Size(170, 24);
            this.lblDiscountAmount.TabIndex = 3;
            this.lblDiscountAmount.Text = "-$0.00";
            this.lblDiscountAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDiscountLabel
            // 
            this.lblDiscountLabel.AutoSize = true;
            this.lblDiscountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lblDiscountLabel.ForeColor = System.Drawing.Color.Green;
            this.lblDiscountLabel.Location = new System.Drawing.Point(20, 45);
            this.lblDiscountLabel.Name = "lblDiscountLabel";
            this.lblDiscountLabel.Size = new System.Drawing.Size(88, 24);
            this.lblDiscountLabel.TabIndex = 2;
            this.lblDiscountLabel.Text = "Discount:";
            // 
            // lblSubtotalAmount
            // 
            this.lblSubtotalAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSubtotalAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lblSubtotalAmount.Location = new System.Drawing.Point(366, 15);
            this.lblSubtotalAmount.Name = "lblSubtotalAmount";
            this.lblSubtotalAmount.Size = new System.Drawing.Size(170, 24);
            this.lblSubtotalAmount.TabIndex = 1;
            this.lblSubtotalAmount.Text = "$0.00";
            this.lblSubtotalAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSubtotalLabel
            // 
            this.lblSubtotalLabel.AutoSize = true;
            this.lblSubtotalLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lblSubtotalLabel.Location = new System.Drawing.Point(20, 15);
            this.lblSubtotalLabel.Name = "lblSubtotalLabel";
            this.lblSubtotalLabel.Size = new System.Drawing.Size(82, 24);
            this.lblSubtotalLabel.TabIndex = 0;
            this.lblSubtotalLabel.Text = "Subtotal:";
            // 
            // pnlCustomerInfo
            // 
            this.pnlCustomerInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(248)))), ((int)(((byte)(255)))));
            this.pnlCustomerInfo.Controls.Add(this.cboPaymentMethod);
            this.pnlCustomerInfo.Controls.Add(this.lblPaymentMethod);
            this.pnlCustomerInfo.Controls.Add(this.txtCustomerPhone);
            this.pnlCustomerInfo.Controls.Add(this.lblCustomerPhone);
            this.pnlCustomerInfo.Controls.Add(this.txtCustomerName);
            this.pnlCustomerInfo.Controls.Add(this.lblCustomerName);
            this.pnlCustomerInfo.Controls.Add(this.lblCustomerInfoTitle);
            this.pnlCustomerInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCustomerInfo.Location = new System.Drawing.Point(0, 0);
            this.pnlCustomerInfo.Name = "pnlCustomerInfo";
            this.pnlCustomerInfo.Size = new System.Drawing.Size(560, 180);
            this.pnlCustomerInfo.TabIndex = 0;
            // 
            // cboPaymentMethod
            // 
            this.cboPaymentMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPaymentMethod.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cboPaymentMethod.FormattingEnabled = true;
            this.cboPaymentMethod.Items.AddRange(new object[] {
            "Cash",
            "Credit Card",
            "Debit Card",
            "Bank Transfer",
            "E-Wallet"});
            this.cboPaymentMethod.Location = new System.Drawing.Point(120, 132);
            this.cboPaymentMethod.Name = "cboPaymentMethod";
            this.cboPaymentMethod.Size = new System.Drawing.Size(180, 28);
            this.cboPaymentMethod.TabIndex = 6;
            // 
            // lblPaymentMethod
            // 
            this.lblPaymentMethod.AutoSize = true;
            this.lblPaymentMethod.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblPaymentMethod.Location = new System.Drawing.Point(15, 135);
            this.lblPaymentMethod.Name = "lblPaymentMethod";
            this.lblPaymentMethod.Size = new System.Drawing.Size(79, 20);
            this.lblPaymentMethod.TabIndex = 5;
            this.lblPaymentMethod.Text = "Payment:";
            // 
            // txtCustomerPhone
            // 
            this.txtCustomerPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtCustomerPhone.Location = new System.Drawing.Point(120, 92);
            this.txtCustomerPhone.Name = "txtCustomerPhone";
            this.txtCustomerPhone.Size = new System.Drawing.Size(280, 26);
            this.txtCustomerPhone.TabIndex = 4;
            // 
            // lblCustomerPhone
            // 
            this.lblCustomerPhone.AutoSize = true;
            this.lblCustomerPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblCustomerPhone.Location = new System.Drawing.Point(15, 95);
            this.lblCustomerPhone.Name = "lblCustomerPhone";
            this.lblCustomerPhone.Size = new System.Drawing.Size(61, 20);
            this.lblCustomerPhone.TabIndex = 3;
            this.lblCustomerPhone.Text = "Phone:";
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtCustomerName.Location = new System.Drawing.Point(120, 52);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(280, 26);
            this.txtCustomerName.TabIndex = 2;
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblCustomerName.Location = new System.Drawing.Point(15, 55);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(58, 20);
            this.lblCustomerName.TabIndex = 1;
            this.lblCustomerName.Text = "Name:";
            // 
            // lblCustomerInfoTitle
            // 
            this.lblCustomerInfoTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.lblCustomerInfoTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCustomerInfoTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.lblCustomerInfoTitle.ForeColor = System.Drawing.Color.White;
            this.lblCustomerInfoTitle.Location = new System.Drawing.Point(0, 0);
            this.lblCustomerInfoTitle.Name = "lblCustomerInfoTitle";
            this.lblCustomerInfoTitle.Padding = new System.Windows.Forms.Padding(10);
            this.lblCustomerInfoTitle.Size = new System.Drawing.Size(560, 40);
            this.lblCustomerInfoTitle.TabIndex = 0;
            this.lblCustomerInfoTitle.Text = "👤 Customer Information";
            // 
            // ucCreateOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.pnlHeader);
            this.Name = "ucCreateOrder";
            this.Size = new System.Drawing.Size(1233, 800);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.pnlProductSelection.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            this.pnlAddToCart.ResumeLayout(false);
            this.pnlAddToCart.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).EndInit();
            this.pnlProductFilters.ResumeLayout(false);
            this.pnlProductFilters.PerformLayout();
            this.pnlCart.ResumeLayout(false);
            this.pnlCartItems.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).EndInit();
            this.pnlCartControls.ResumeLayout(false);
            this.pnlOrderSummary.ResumeLayout(false);
            this.pnlOrderSummary.PerformLayout();
            this.pnlCustomerInfo.ResumeLayout(false);
            this.pnlCustomerInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.SplitContainer splitContainer1;
        
        // Left Panel - Product Selection
        private System.Windows.Forms.Panel pnlProductSelection;
        private System.Windows.Forms.Label lblProductListTitle;
        private System.Windows.Forms.Panel pnlProductFilters;
        private System.Windows.Forms.TextBox txtSearchProduct;
        private System.Windows.Forms.ComboBox cboCategory;
        private System.Windows.Forms.DataGridView dgvProducts;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStock;
        private System.Windows.Forms.Panel pnlAddToCart;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.NumericUpDown nudQuantity;
        private System.Windows.Forms.Button btnAddToCart;
        
        // Right Panel - Cart
        private System.Windows.Forms.Panel pnlCart;
        private System.Windows.Forms.Panel pnlCustomerInfo;
        private System.Windows.Forms.Label lblCustomerInfoTitle;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.Label lblCustomerPhone;
        private System.Windows.Forms.TextBox txtCustomerPhone;
        private System.Windows.Forms.Label lblPaymentMethod;
        private System.Windows.Forms.ComboBox cboPaymentMethod;
        
        private System.Windows.Forms.Panel pnlCartItems;
        private System.Windows.Forms.Label lblCartTitle;
        private System.Windows.Forms.DataGridView dgvCart;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCartProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCartQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCartUnitPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCartSubtotal;
        private System.Windows.Forms.Panel pnlCartControls;
        private System.Windows.Forms.Button btnRemoveItem;
        private System.Windows.Forms.Button btnClearCart;
        
        private System.Windows.Forms.Panel pnlOrderSummary;
        private System.Windows.Forms.Label lblSubtotalLabel;
        private System.Windows.Forms.Label lblSubtotalAmount;
        private System.Windows.Forms.Label lblDiscountLabel;
        private System.Windows.Forms.Label lblDiscountAmount;
        private System.Windows.Forms.Label lblTotalLabel;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnPlaceOrder;
    }
}
