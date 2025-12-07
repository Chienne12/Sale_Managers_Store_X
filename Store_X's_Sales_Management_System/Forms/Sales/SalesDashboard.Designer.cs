namespace Store_X_s_Sales_Management_System.Forms.Sales
{
    partial class SalesDashboard
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblStoreName = new System.Windows.Forms.Label();
            this.pnlInfoBar = new System.Windows.Forms.Panel();
            this.btnLogout = new System.Windows.Forms.Button();
            this.lblCurrentRank = new System.Windows.Forms.Label();
            this.lblTodaySales = new System.Windows.Forms.Label();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.btnManagerCustomers = new System.Windows.Forms.Button();
            this.btnManagerProducts = new System.Windows.Forms.Button();
            this.btnManagerOder = new System.Windows.Forms.Button();
            this.btnDashboard = new System.Windows.Forms.Button();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlHeader.SuspendLayout();
            this.pnlInfoBar.SuspendLayout();
            this.pnlMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.White;
            this.pnlHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlHeader.Controls.Add(this.lblStoreName);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(4);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1600, 61);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblStoreName
            // 
            this.lblStoreName.AutoSize = true;
            this.lblStoreName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStoreName.Location = new System.Drawing.Point(20, 18);
            this.lblStoreName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStoreName.Name = "lblStoreName";
            this.lblStoreName.Size = new System.Drawing.Size(107, 25);
            this.lblStoreName.TabIndex = 0;
            this.lblStoreName.Text = "STORE X";
            // 
            // pnlInfoBar
            // 
            this.pnlInfoBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pnlInfoBar.Controls.Add(this.btnLogout);
            this.pnlInfoBar.Controls.Add(this.lblCurrentRank);
            this.pnlInfoBar.Controls.Add(this.lblTodaySales);
            this.pnlInfoBar.Controls.Add(this.lblWelcome);
            this.pnlInfoBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlInfoBar.Location = new System.Drawing.Point(0, 61);
            this.pnlInfoBar.Margin = new System.Windows.Forms.Padding(4);
            this.pnlInfoBar.Name = "pnlInfoBar";
            this.pnlInfoBar.Size = new System.Drawing.Size(1600, 55);
            this.pnlInfoBar.TabIndex = 1;
            // 
            // btnLogout
            // 
            this.btnLogout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogout.BackColor = System.Drawing.Color.Gray;
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Location = new System.Drawing.Point(1460, 10);
            this.btnLogout.Margin = new System.Windows.Forms.Padding(4);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(120, 35);
            this.btnLogout.TabIndex = 3;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = false;
            // 
            // lblCurrentRank
            // 
            this.lblCurrentRank.AutoSize = true;
            this.lblCurrentRank.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentRank.ForeColor = System.Drawing.Color.White;
            this.lblCurrentRank.Location = new System.Drawing.Point(630, 15);
            this.lblCurrentRank.Name = "lblCurrentRank";
            this.lblCurrentRank.Size = new System.Drawing.Size(201, 20);
            this.lblCurrentRank.TabIndex = 2;
            this.lblCurrentRank.Text = "Current Rank: #2 in Team";
            // 
            // lblTodaySales
            // 
            this.lblTodaySales.AutoSize = true;
            this.lblTodaySales.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTodaySales.ForeColor = System.Drawing.Color.White;
            this.lblTodaySales.Location = new System.Drawing.Point(330, 15);
            this.lblTodaySales.Name = "lblTodaySales";
            this.lblTodaySales.Size = new System.Drawing.Size(160, 20);
            this.lblTodaySales.TabIndex = 1;
            this.lblTodaySales.Text = "Today Sales: $1,200";
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.ForeColor = System.Drawing.Color.White;
            this.lblWelcome.Location = new System.Drawing.Point(20, 15);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(189, 20);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "Welcome, [Sales Name]";
            // 
            // pnlMenu
            // 
            this.pnlMenu.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlMenu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMenu.Controls.Add(this.btnManagerCustomers);
            this.pnlMenu.Controls.Add(this.btnManagerProducts);
            this.pnlMenu.Controls.Add(this.btnManagerOder);
            this.pnlMenu.Controls.Add(this.btnDashboard);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMenu.Location = new System.Drawing.Point(0, 116);
            this.pnlMenu.Margin = new System.Windows.Forms.Padding(4);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(206, 746);
            this.pnlMenu.TabIndex = 2;
            // 
            // btnManagerCustomers
            // 
            this.btnManagerCustomers.BackColor = System.Drawing.Color.White;
            this.btnManagerCustomers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManagerCustomers.Location = new System.Drawing.Point(13, 230);
            this.btnManagerCustomers.Name = "btnManagerCustomers";
            this.btnManagerCustomers.Size = new System.Drawing.Size(180, 55);
            this.btnManagerCustomers.TabIndex = 3;
            this.btnManagerCustomers.Text = "Manage Customers";
            this.btnManagerCustomers.UseVisualStyleBackColor = false;
            // 
            // btnManagerProducts
            // 
            this.btnManagerProducts.BackColor = System.Drawing.Color.White;
            this.btnManagerProducts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManagerProducts.Location = new System.Drawing.Point(13, 160);
            this.btnManagerProducts.Name = "btnManagerProducts";
            this.btnManagerProducts.Size = new System.Drawing.Size(180, 55);
            this.btnManagerProducts.TabIndex = 2;
            this.btnManagerProducts.Text = "Manager Products";
            this.btnManagerProducts.UseVisualStyleBackColor = false;
            // 
            // btnManagerOder
            // 
            this.btnManagerOder.BackColor = System.Drawing.Color.White;
            this.btnManagerOder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManagerOder.Location = new System.Drawing.Point(13, 90);
            this.btnManagerOder.Name = "btnManagerOder";
            this.btnManagerOder.Size = new System.Drawing.Size(180, 55);
            this.btnManagerOder.TabIndex = 1;
            this.btnManagerOder.Text = "Manager Order";
            this.btnManagerOder.UseVisualStyleBackColor = false;
            // 
            // btnDashboard
            // 
            this.btnDashboard.BackColor = System.Drawing.Color.White;
            this.btnDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDashboard.Location = new System.Drawing.Point(13, 20);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Size = new System.Drawing.Size(180, 55);
            this.btnDashboard.TabIndex = 0;
            this.btnDashboard.Text = "Dashboard";
            this.btnDashboard.UseVisualStyleBackColor = false;
            this.btnDashboard.Click += new System.EventHandler(this.btnDashboard_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(206, 116);
            this.pnlMain.Margin = new System.Windows.Forms.Padding(4);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1394, 746);
            this.pnlMain.TabIndex = 3;
            // 
            // SalesDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1600, 862);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlMenu);
            this.Controls.Add(this.pnlInfoBar);
            this.Controls.Add(this.pnlHeader);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SalesDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sales Dashboard - Store X";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.SalesDashboard_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlInfoBar.ResumeLayout(false);
            this.pnlInfoBar.PerformLayout();
            this.pnlMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblStoreName;
        private System.Windows.Forms.Panel pnlInfoBar;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Label lblCurrentRank;
        private System.Windows.Forms.Label lblTodaySales;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Button btnManagerProducts;
        private System.Windows.Forms.Button btnManagerCustomers;
        private System.Windows.Forms.Button btnManagerOder;
        private System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.Panel pnlMain;
    }
}
