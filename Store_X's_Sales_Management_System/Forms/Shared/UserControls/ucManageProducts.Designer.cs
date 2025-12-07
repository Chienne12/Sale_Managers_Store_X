namespace Store_X_s_Sales_Management_System.Forms.Shared.UserControls
{
    partial class ucManageProducts
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
            this.tabProducts = new System.Windows.Forms.TabControl();
            this.tabAllProducts = new System.Windows.Forms.TabPage();
            this.pnlGridContainer = new System.Windows.Forms.Panel();
            this.dgvProducts = new System.Windows.Forms.DataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();

            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSupplier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colImportPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSellPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlRightButtons = new System.Windows.Forms.Panel();
            this.btnReactivate = new System.Windows.Forms.Button();

            this.btnExportStock = new System.Windows.Forms.Button();
            this.btnImportStock = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnInsert = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.pnlFilters = new System.Windows.Forms.Panel();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnLowStock = new System.Windows.Forms.Button();
            this.cboSupplier = new System.Windows.Forms.ComboBox();
            this.cboCategory = new System.Windows.Forms.ComboBox();
            this.pnlPagination = new System.Windows.Forms.Panel();
            this.lblPagination = new System.Windows.Forms.Label();
            this.tabCategories = new System.Windows.Forms.TabPage();
            this.tabSuppliers = new System.Windows.Forms.TabPage();
            this.pnlHeader.SuspendLayout();
            this.tabProducts.SuspendLayout();
            this.tabAllProducts.SuspendLayout();
            this.pnlGridContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            this.pnlRightButtons.SuspendLayout();
            this.pnlFilters.SuspendLayout();
            this.pnlPagination.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.White;
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1200, 60);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(251, 31);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Manager Products";
            // 
            // tabProducts
            // 
            this.tabProducts.Controls.Add(this.tabAllProducts);
            this.tabProducts.Controls.Add(this.tabCategories);
            this.tabProducts.Controls.Add(this.tabSuppliers);
            this.tabProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabProducts.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabProducts.Location = new System.Drawing.Point(0, 60);
            this.tabProducts.Name = "tabProducts";
            this.tabProducts.SelectedIndex = 0;
            this.tabProducts.Size = new System.Drawing.Size(1200, 740);
            this.tabProducts.TabIndex = 1;
            // 
            // tabAllProducts
            // 
            this.tabAllProducts.Controls.Add(this.pnlGridContainer);
            this.tabAllProducts.Controls.Add(this.pnlFilters);
            this.tabAllProducts.Controls.Add(this.pnlPagination);
            this.tabAllProducts.Location = new System.Drawing.Point(4, 29);
            this.tabAllProducts.Name = "tabAllProducts";
            this.tabAllProducts.Padding = new System.Windows.Forms.Padding(3);
            this.tabAllProducts.Size = new System.Drawing.Size(1192, 707);
            this.tabAllProducts.TabIndex = 0;
            this.tabAllProducts.Text = "All Products";
            this.tabAllProducts.UseVisualStyleBackColor = true;
            // 
            // pnlGridContainer
            // 
            this.pnlGridContainer.Controls.Add(this.dgvProducts);
            this.pnlGridContainer.Controls.Add(this.pnlRightButtons);
            this.pnlGridContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGridContainer.Location = new System.Drawing.Point(3, 63);
            this.pnlGridContainer.Name = "pnlGridContainer";
            this.pnlGridContainer.Size = new System.Drawing.Size(1186, 601);
            this.pnlGridContainer.TabIndex = 2;
            // 
            // dgvProducts
            // 
            this.dgvProducts.AllowUserToAddRows = false;
            this.dgvProducts.AllowUserToDeleteRows = false;
            this.dgvProducts.BackgroundColor = System.Drawing.Color.White;
            this.dgvProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProducts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,

            this.colName,
            this.colCategory,
            this.colSupplier,
            this.colImportPrice,
            this.colSellPrice,
            this.colStock});
            this.dgvProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProducts.Location = new System.Drawing.Point(0, 0);
            this.dgvProducts.Name = "dgvProducts";
            this.dgvProducts.ReadOnly = true;
            this.dgvProducts.RowHeadersWidth = 51;
            this.dgvProducts.RowTemplate.Height = 50;
            this.dgvProducts.Size = new System.Drawing.Size(1086, 601);
            this.dgvProducts.TabIndex = 1;
            this.dgvProducts.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProducts_CellContentClick);
            // 
            // colId
            // 
            this.colId.HeaderText = "ID";
            this.colId.MinimumWidth = 6;
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            this.colId.Width = 50;

            // 
            // colName
            // 
            this.colName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colName.HeaderText = "Product Name";
            this.colName.MinimumWidth = 6;
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            // 
            // colCategory
            // 
            this.colCategory.HeaderText = "Category";
            this.colCategory.MinimumWidth = 6;
            this.colCategory.Name = "colCategory";
            this.colCategory.ReadOnly = true;
            this.colCategory.Width = 120;
            // 
            // colSupplier
            // 
            this.colSupplier.HeaderText = "Supplier";
            this.colSupplier.MinimumWidth = 6;
            this.colSupplier.Name = "colSupplier";
            this.colSupplier.ReadOnly = true;
            this.colSupplier.Width = 120;
            // 
            // colImportPrice
            // 
            this.colImportPrice.HeaderText = "Import Price";
            this.colImportPrice.MinimumWidth = 6;
            this.colImportPrice.Name = "colImportPrice";
            this.colImportPrice.ReadOnly = true;
            // 
            // colSellPrice
            // 
            this.colSellPrice.HeaderText = "Sell Price";
            this.colSellPrice.MinimumWidth = 6;
            this.colSellPrice.Name = "colSellPrice";
            this.colSellPrice.ReadOnly = true;
            // 
            // colStock
            // 
            this.colStock.HeaderText = "Stock Qty";
            this.colStock.MinimumWidth = 6;
            this.colStock.Name = "colStock";
            this.colStock.ReadOnly = true;
            this.colStock.Width = 80;
            // 
            // pnlRightButtons
            // 
            this.pnlRightButtons.Controls.Add(this.btnReactivate);

            this.pnlRightButtons.Controls.Add(this.btnExportStock);
            this.pnlRightButtons.Controls.Add(this.btnImportStock);
            this.pnlRightButtons.Controls.Add(this.btnDelete);
            this.pnlRightButtons.Controls.Add(this.btnInsert);
            this.pnlRightButtons.Controls.Add(this.btnEdit);
            this.pnlRightButtons.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlRightButtons.Location = new System.Drawing.Point(1086, 0);
            this.pnlRightButtons.Name = "pnlRightButtons";
            this.pnlRightButtons.Size = new System.Drawing.Size(100, 601);
            this.pnlRightButtons.TabIndex = 0;
            // 
            // btnReactivate
            // 
            this.btnReactivate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnReactivate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReactivate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.btnReactivate.ForeColor = System.Drawing.Color.White;
            this.btnReactivate.Location = new System.Drawing.Point(10, 160);
            this.btnReactivate.Name = "btnReactivate";
            this.btnReactivate.Size = new System.Drawing.Size(80, 40);
            this.btnReactivate.TabIndex = 6;
            this.btnReactivate.Text = "Reactivate";
            this.btnReactivate.UseVisualStyleBackColor = false;

            // 
            // btnExportStock
            // 
            this.btnExportStock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnExportStock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.btnExportStock.ForeColor = System.Drawing.Color.White;
            this.btnExportStock.Location = new System.Drawing.Point(10, 274);
            this.btnExportStock.Name = "btnExportStock";
            this.btnExportStock.Size = new System.Drawing.Size(80, 40);
            this.btnExportStock.TabIndex = 4;
            this.btnExportStock.Text = "Export";
            this.btnExportStock.UseVisualStyleBackColor = false;
            this.btnExportStock.Click += new System.EventHandler(this.btnExportStock_Click);
            // 
            // btnImportStock
            // 
            this.btnImportStock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnImportStock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImportStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.btnImportStock.ForeColor = System.Drawing.Color.White;
            this.btnImportStock.Location = new System.Drawing.Point(10, 216);
            this.btnImportStock.Name = "btnImportStock";
            this.btnImportStock.Size = new System.Drawing.Size(80, 40);
            this.btnImportStock.TabIndex = 3;
            this.btnImportStock.Text = "Import";
            this.btnImportStock.UseVisualStyleBackColor = false;
            this.btnImportStock.Click += new System.EventHandler(this.btnImportStock_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(0, 106);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(97, 40);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Discontinue";
            this.btnDelete.UseVisualStyleBackColor = false;
            // 
            // btnInsert
            // 
            this.btnInsert.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnInsert.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInsert.Location = new System.Drawing.Point(10, 60);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(80, 40);
            this.btnInsert.TabIndex = 1;
            this.btnInsert.Text = "Insert";
            this.btnInsert.UseVisualStyleBackColor = false;
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Location = new System.Drawing.Point(10, 10);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(80, 40);
            this.btnEdit.TabIndex = 0;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = false;
            // 
            // pnlFilters
            // 
            this.pnlFilters.Controls.Add(this.btnAdd);
            this.pnlFilters.Controls.Add(this.txtSearch);
            this.pnlFilters.Controls.Add(this.btnLowStock);
            this.pnlFilters.Controls.Add(this.cboSupplier);
            this.pnlFilters.Controls.Add(this.cboCategory);
            this.pnlFilters.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilters.Location = new System.Drawing.Point(3, 3);
            this.pnlFilters.Name = "pnlFilters";
            this.pnlFilters.Size = new System.Drawing.Size(1186, 60);
            this.pnlFilters.TabIndex = 0;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(1000, 10);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(180, 35);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "Add New Product";
            this.btnAdd.UseVisualStyleBackColor = false;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(550, 15);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(200, 26);
            this.txtSearch.TabIndex = 3;
            this.txtSearch.Text = "Search...";
            // 
            // btnLowStock
            // 
            this.btnLowStock.BackColor = System.Drawing.Color.White;
            this.btnLowStock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLowStock.Location = new System.Drawing.Point(350, 12);
            this.btnLowStock.Name = "btnLowStock";
            this.btnLowStock.Size = new System.Drawing.Size(180, 30);
            this.btnLowStock.TabIndex = 2;
            this.btnLowStock.Text = "Show Low Stock Only";
            this.btnLowStock.UseVisualStyleBackColor = false;
            // 
            // cboSupplier
            // 
            this.cboSupplier.FormattingEnabled = true;
            this.cboSupplier.Location = new System.Drawing.Point(180, 14);
            this.cboSupplier.Name = "cboSupplier";
            this.cboSupplier.Size = new System.Drawing.Size(150, 28);
            this.cboSupplier.TabIndex = 1;
            this.cboSupplier.Text = "Select Supplier";
            // 
            // cboCategory
            // 
            this.cboCategory.FormattingEnabled = true;
            this.cboCategory.Location = new System.Drawing.Point(10, 14);
            this.cboCategory.Name = "cboCategory";
            this.cboCategory.Size = new System.Drawing.Size(150, 28);
            this.cboCategory.TabIndex = 0;
            this.cboCategory.Text = "Select Category";
            // 
            // pnlPagination
            // 
            this.pnlPagination.Controls.Add(this.lblPagination);
            this.pnlPagination.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlPagination.Location = new System.Drawing.Point(3, 664);
            this.pnlPagination.Name = "pnlPagination";
            this.pnlPagination.Size = new System.Drawing.Size(1186, 40);
            this.pnlPagination.TabIndex = 1;
            // 
            // lblPagination
            // 
            this.lblPagination.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPagination.Location = new System.Drawing.Point(0, 0);
            this.lblPagination.Name = "lblPagination";
            this.lblPagination.Size = new System.Drawing.Size(1186, 40);
            this.lblPagination.TabIndex = 0;
            this.lblPagination.Text = "< 1 2 3 ... 10 >";
            this.lblPagination.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabCategories
            // 
            this.tabCategories.Location = new System.Drawing.Point(4, 29);
            this.tabCategories.Name = "tabCategories";
            this.tabCategories.Padding = new System.Windows.Forms.Padding(3);
            this.tabCategories.Size = new System.Drawing.Size(1192, 707);
            this.tabCategories.TabIndex = 1;
            this.tabCategories.Text = "Categories";
            this.tabCategories.UseVisualStyleBackColor = true;
            // 
            // tabSuppliers
            // 
            this.tabSuppliers.Location = new System.Drawing.Point(4, 29);
            this.tabSuppliers.Name = "tabSuppliers";
            this.tabSuppliers.Size = new System.Drawing.Size(1192, 707);
            this.tabSuppliers.TabIndex = 2;
            this.tabSuppliers.Text = "Suppliers";
            this.tabSuppliers.UseVisualStyleBackColor = true;
            // 
            // ucManageProducts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabProducts);
            this.Controls.Add(this.pnlHeader);
            this.Name = "ucManageProducts";
            this.Size = new System.Drawing.Size(1200, 800);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.tabProducts.ResumeLayout(false);
            this.tabAllProducts.ResumeLayout(false);
            this.pnlGridContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            this.pnlRightButtons.ResumeLayout(false);
            this.pnlFilters.ResumeLayout(false);
            this.pnlFilters.PerformLayout();
            this.pnlPagination.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TabControl tabProducts;
        private System.Windows.Forms.TabPage tabAllProducts;
        private System.Windows.Forms.TabPage tabCategories;
        private System.Windows.Forms.TabPage tabSuppliers;
        private System.Windows.Forms.Panel pnlFilters;
        private System.Windows.Forms.ComboBox cboCategory;
        private System.Windows.Forms.ComboBox cboSupplier;
        private System.Windows.Forms.Button btnLowStock;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Panel pnlPagination;
        private System.Windows.Forms.Label lblPagination;
        private System.Windows.Forms.Panel pnlGridContainer;
        private System.Windows.Forms.DataGridView dgvProducts;
        private System.Windows.Forms.Panel pnlRightButtons;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnReactivate;
        private System.Windows.Forms.Button btnImportStock;
        private System.Windows.Forms.Button btnExportStock;

        private System.Windows.Forms.DataGridViewTextBoxColumn colId;

        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSupplier;
        private System.Windows.Forms.DataGridViewTextBoxColumn colImportPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSellPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStock;
    }
}
