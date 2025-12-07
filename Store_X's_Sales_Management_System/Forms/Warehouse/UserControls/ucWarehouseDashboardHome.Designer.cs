namespace Store_X_s_Sales_Management_System.Forms.Warehouse.UserControls
{
    partial class ucWarehouseDashboardHome
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
            this.dgvInventoryMovements = new System.Windows.Forms.DataGridView();
            this.colDateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTransactionType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProduct = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPerformedBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblInventoryMovements = new System.Windows.Forms.Label();
            this.dgvReplenishment = new System.Windows.Forms.DataGridView();
            this.colProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSupplier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCurrentStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReorderLevel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAction = new System.Windows.Forms.DataGridViewButtonColumn();
            this.lblReplenishment = new System.Windows.Forms.Label();
            this.pnlCardTotalValue = new System.Windows.Forms.Panel();
            this.lblTotalValueAmount = new System.Windows.Forms.Label();
            this.lblTotalValueTitle = new System.Windows.Forms.Label();
            this.pnlCardLowStock = new System.Windows.Forms.Panel();
            this.lblLowStockCount = new System.Windows.Forms.Label();
            this.lblLowStockTitle = new System.Windows.Forms.Label();
            this.pnlCardTotalItems = new System.Windows.Forms.Panel();
            this.lblTotalItemsCount = new System.Windows.Forms.Label();
            this.lblTotalItemsTitle = new System.Windows.Forms.Label();
            this.lblMainTitle = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventoryMovements)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReplenishment)).BeginInit();
            this.pnlCardTotalValue.SuspendLayout();
            this.pnlCardLowStock.SuspendLayout();
            this.pnlCardTotalItems.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvInventoryMovements
            // 
            this.dgvInventoryMovements.AllowUserToAddRows = false;
            this.dgvInventoryMovements.AllowUserToDeleteRows = false;
            this.dgvInventoryMovements.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dgvInventoryMovements.BackgroundColor = System.Drawing.Color.White;
            this.dgvInventoryMovements.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInventoryMovements.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDateTime,
            this.colTransactionType,
            this.colProduct,
            this.colQuantity,
            this.colPerformedBy});
            this.dgvInventoryMovements.Location = new System.Drawing.Point(27, 550);
            this.dgvInventoryMovements.Margin = new System.Windows.Forms.Padding(4);
            this.dgvInventoryMovements.Name = "dgvInventoryMovements";
            this.dgvInventoryMovements.ReadOnly = true;
            this.dgvInventoryMovements.RowHeadersWidth = 51;
            this.dgvInventoryMovements.Size = new System.Drawing.Size(1333, 228);
            this.dgvInventoryMovements.TabIndex = 7;
            // 
            // colDateTime
            // 
            this.colDateTime.HeaderText = "Date/Time";
            this.colDateTime.MinimumWidth = 6;
            this.colDateTime.Name = "colDateTime";
            this.colDateTime.ReadOnly = true;
            this.colDateTime.Width = 150;
            // 
            // colTransactionType
            // 
            this.colTransactionType.HeaderText = "Transaction Type";
            this.colTransactionType.MinimumWidth = 6;
            this.colTransactionType.Name = "colTransactionType";
            this.colTransactionType.ReadOnly = true;
            this.colTransactionType.Width = 200;
            // 
            // colProduct
            // 
            this.colProduct.HeaderText = "Product";
            this.colProduct.MinimumWidth = 6;
            this.colProduct.Name = "colProduct";
            this.colProduct.ReadOnly = true;
            this.colProduct.Width = 300;
            // 
            // colQuantity
            // 
            this.colQuantity.HeaderText = "Quantity";
            this.colQuantity.MinimumWidth = 6;
            this.colQuantity.Name = "colQuantity";
            this.colQuantity.ReadOnly = true;
            this.colQuantity.Width = 150;
            // 
            // colPerformedBy
            // 
            this.colPerformedBy.HeaderText = "Performed By";
            this.colPerformedBy.MinimumWidth = 6;
            this.colPerformedBy.Name = "colPerformedBy";
            this.colPerformedBy.ReadOnly = true;
            this.colPerformedBy.Width = 200;
            // 
            // lblInventoryMovements
            // 
            this.lblInventoryMovements.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblInventoryMovements.AutoSize = true;
            this.lblInventoryMovements.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInventoryMovements.Location = new System.Drawing.Point(27, 518);
            this.lblInventoryMovements.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblInventoryMovements.Name = "lblInventoryMovements";
            this.lblInventoryMovements.Size = new System.Drawing.Size(495, 24);
            this.lblInventoryMovements.TabIndex = 6;
            this.lblInventoryMovements.Text = "Recent Inventory Movements (Import/Export History)";
            // 
            // dgvReplenishment
            // 
            this.dgvReplenishment.AllowUserToAddRows = false;
            this.dgvReplenishment.AllowUserToDeleteRows = false;
            this.dgvReplenishment.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dgvReplenishment.BackgroundColor = System.Drawing.Color.White;
            this.dgvReplenishment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReplenishment.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colProductName,
            this.colSupplier,
            this.colCurrentStock,
            this.colReorderLevel,
            this.colAction});
            this.dgvReplenishment.Location = new System.Drawing.Point(27, 268);
            this.dgvReplenishment.Margin = new System.Windows.Forms.Padding(4);
            this.dgvReplenishment.Name = "dgvReplenishment";
            this.dgvReplenishment.RowHeadersWidth = 51;
            this.dgvReplenishment.Size = new System.Drawing.Size(1333, 228);
            this.dgvReplenishment.TabIndex = 5;
            // 
            // colProductName
            // 
            this.colProductName.HeaderText = "Product Name";
            this.colProductName.MinimumWidth = 6;
            this.colProductName.Name = "colProductName";
            this.colProductName.ReadOnly = true;
            this.colProductName.Width = 300;
            // 
            // colSupplier
            // 
            this.colSupplier.HeaderText = "Supplier";
            this.colSupplier.MinimumWidth = 6;
            this.colSupplier.Name = "colSupplier";
            this.colSupplier.ReadOnly = true;
            this.colSupplier.Width = 250;
            // 
            // colCurrentStock
            // 
            this.colCurrentStock.HeaderText = "Current Stock";
            this.colCurrentStock.MinimumWidth = 6;
            this.colCurrentStock.Name = "colCurrentStock";
            this.colCurrentStock.ReadOnly = true;
            this.colCurrentStock.Width = 150;
            // 
            // colReorderLevel
            // 
            this.colReorderLevel.HeaderText = "Reorder Level";
            this.colReorderLevel.MinimumWidth = 6;
            this.colReorderLevel.Name = "colReorderLevel";
            this.colReorderLevel.ReadOnly = true;
            this.colReorderLevel.Width = 150;
            // 
            // colAction
            // 
            this.colAction.HeaderText = "Action";
            this.colAction.MinimumWidth = 6;
            this.colAction.Name = "colAction";
            this.colAction.Text = "Import Stock";
            this.colAction.UseColumnTextForButtonValue = true;
            this.colAction.Width = 180;
            // 
            // lblReplenishment
            // 
            this.lblReplenishment.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblReplenishment.AutoSize = true;
            this.lblReplenishment.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReplenishment.Location = new System.Drawing.Point(27, 236);
            this.lblReplenishment.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblReplenishment.Name = "lblReplenishment";
            this.lblReplenishment.Size = new System.Drawing.Size(346, 24);
            this.lblReplenishment.TabIndex = 4;
            this.lblReplenishment.Text = "Replenishment Needed (Low Stock)";
            // 
            // pnlCardTotalValue
            // 
            this.pnlCardTotalValue.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlCardTotalValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCardTotalValue.Controls.Add(this.lblTotalValueAmount);
            this.pnlCardTotalValue.Controls.Add(this.lblTotalValueTitle);
            this.pnlCardTotalValue.Location = new System.Drawing.Point(947, 68);
            this.pnlCardTotalValue.Margin = new System.Windows.Forms.Padding(4);
            this.pnlCardTotalValue.Name = "pnlCardTotalValue";
            this.pnlCardTotalValue.Size = new System.Drawing.Size(320, 135);
            this.pnlCardTotalValue.TabIndex = 3;
            // 
            // lblTotalValueAmount
            // 
            this.lblTotalValueAmount.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTotalValueAmount.AutoSize = true;
            this.lblTotalValueAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalValueAmount.Location = new System.Drawing.Point(50, 62);
            this.lblTotalValueAmount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalValueAmount.Name = "lblTotalValueAmount";
            this.lblTotalValueAmount.Size = new System.Drawing.Size(170, 46);
            this.lblTotalValueAmount.TabIndex = 1;
            this.lblTotalValueAmount.Text = "$50,000";
            // 
            // lblTotalValueTitle
            // 
            this.lblTotalValueTitle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTotalValueTitle.AutoSize = true;
            this.lblTotalValueTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalValueTitle.Location = new System.Drawing.Point(80, 25);
            this.lblTotalValueTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalValueTitle.Name = "lblTotalValueTitle";
            this.lblTotalValueTitle.Size = new System.Drawing.Size(93, 20);
            this.lblTotalValueTitle.TabIndex = 0;
            this.lblTotalValueTitle.Text = "Total Value";
            // 
            // pnlCardLowStock
            // 
            this.pnlCardLowStock.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlCardLowStock.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCardLowStock.Controls.Add(this.lblLowStockCount);
            this.pnlCardLowStock.Controls.Add(this.lblLowStockTitle);
            this.pnlCardLowStock.Location = new System.Drawing.Point(573, 68);
            this.pnlCardLowStock.Margin = new System.Windows.Forms.Padding(4);
            this.pnlCardLowStock.Name = "pnlCardLowStock";
            this.pnlCardLowStock.Size = new System.Drawing.Size(320, 135);
            this.pnlCardLowStock.TabIndex = 2;
            // 
            // lblLowStockCount
            // 
            this.lblLowStockCount.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblLowStockCount.AutoSize = true;
            this.lblLowStockCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLowStockCount.ForeColor = System.Drawing.Color.Red;
            this.lblLowStockCount.Location = new System.Drawing.Point(86, 62);
            this.lblLowStockCount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLowStockCount.Name = "lblLowStockCount";
            this.lblLowStockCount.Size = new System.Drawing.Size(156, 46);
            this.lblLowStockCount.TabIndex = 1;
            this.lblLowStockCount.Text = "5 Items";
            // 
            // lblLowStockTitle
            // 
            this.lblLowStockTitle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblLowStockTitle.AutoSize = true;
            this.lblLowStockTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLowStockTitle.Location = new System.Drawing.Point(90, 25);
            this.lblLowStockTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLowStockTitle.Name = "lblLowStockTitle";
            this.lblLowStockTitle.Size = new System.Drawing.Size(136, 20);
            this.lblLowStockTitle.TabIndex = 0;
            this.lblLowStockTitle.Text = "Low Stock Alerts";
            // 
            // pnlCardTotalItems
            // 
            this.pnlCardTotalItems.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlCardTotalItems.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCardTotalItems.Controls.Add(this.lblTotalItemsCount);
            this.pnlCardTotalItems.Controls.Add(this.lblTotalItemsTitle);
            this.pnlCardTotalItems.Location = new System.Drawing.Point(200, 68);
            this.pnlCardTotalItems.Margin = new System.Windows.Forms.Padding(4);
            this.pnlCardTotalItems.Name = "pnlCardTotalItems";
            this.pnlCardTotalItems.Size = new System.Drawing.Size(320, 135);
            this.pnlCardTotalItems.TabIndex = 1;
            // 
            // lblTotalItemsCount
            // 
            this.lblTotalItemsCount.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTotalItemsCount.AutoSize = true;
            this.lblTotalItemsCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalItemsCount.Location = new System.Drawing.Point(95, 62);
            this.lblTotalItemsCount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalItemsCount.Name = "lblTotalItemsCount";
            this.lblTotalItemsCount.Size = new System.Drawing.Size(89, 46);
            this.lblTotalItemsCount.TabIndex = 1;
            this.lblTotalItemsCount.Text = "150";
            // 
            // lblTotalItemsTitle
            // 
            this.lblTotalItemsTitle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTotalItemsTitle.AutoSize = true;
            this.lblTotalItemsTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalItemsTitle.Location = new System.Drawing.Point(85, 25);
            this.lblTotalItemsTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalItemsTitle.Name = "lblTotalItemsTitle";
            this.lblTotalItemsTitle.Size = new System.Drawing.Size(92, 20);
            this.lblTotalItemsTitle.TabIndex = 0;
            this.lblTotalItemsTitle.Text = "Total Items";
            // 
            // lblMainTitle
            // 
            this.lblMainTitle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblMainTitle.AutoSize = true;
            this.lblMainTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMainTitle.Location = new System.Drawing.Point(27, 18);
            this.lblMainTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMainTitle.Name = "lblMainTitle";
            this.lblMainTitle.Size = new System.Drawing.Size(366, 29);
            this.lblMainTitle.TabIndex = 0;
            this.lblMainTitle.Text = "Warehouse Operations Center";
            // 
            // ucWarehouseDashboardHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.dgvInventoryMovements);
            this.Controls.Add(this.lblInventoryMovements);
            this.Controls.Add(this.dgvReplenishment);
            this.Controls.Add(this.lblReplenishment);
            this.Controls.Add(this.pnlCardTotalValue);
            this.Controls.Add(this.pnlCardLowStock);
            this.Controls.Add(this.pnlCardTotalItems);
            this.Controls.Add(this.lblMainTitle);
            this.Name = "ucWarehouseDashboardHome";
            this.Size = new System.Drawing.Size(1393, 800);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventoryMovements)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReplenishment)).EndInit();
            this.pnlCardTotalValue.ResumeLayout(false);
            this.pnlCardTotalValue.PerformLayout();
            this.pnlCardLowStock.ResumeLayout(false);
            this.pnlCardLowStock.PerformLayout();
            this.pnlCardTotalItems.ResumeLayout(false);
            this.pnlCardTotalItems.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvInventoryMovements;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTransactionType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProduct;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPerformedBy;
        private System.Windows.Forms.Label lblInventoryMovements;
        private System.Windows.Forms.DataGridView dgvReplenishment;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSupplier;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCurrentStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReorderLevel;
        private System.Windows.Forms.DataGridViewButtonColumn colAction;
        private System.Windows.Forms.Label lblReplenishment;
        private System.Windows.Forms.Panel pnlCardTotalValue;
        private System.Windows.Forms.Label lblTotalValueAmount;
        private System.Windows.Forms.Label lblTotalValueTitle;
        private System.Windows.Forms.Panel pnlCardLowStock;
        private System.Windows.Forms.Label lblLowStockCount;
        private System.Windows.Forms.Label lblLowStockTitle;
        private System.Windows.Forms.Panel pnlCardTotalItems;
        private System.Windows.Forms.Label lblTotalItemsCount;
        private System.Windows.Forms.Label lblTotalItemsTitle;
        private System.Windows.Forms.Label lblMainTitle;
    }
}
