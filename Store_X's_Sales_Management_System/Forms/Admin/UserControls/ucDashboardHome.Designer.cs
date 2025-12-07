namespace Store_X_s_Sales_Management_System.Forms.Admin.UserControls
{
    partial class ucDashboardHome
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea10 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series10 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea11 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series11 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea12 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series12 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.pnlOrderStatistics = new System.Windows.Forms.Panel();
            this.chartRevenueOverTime = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartSalesByCustomer = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartSalesByEmployee = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnApplyDateRange = new System.Windows.Forms.Button();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.lblToDate = new System.Windows.Forms.Label();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.lblFromDate = new System.Windows.Forms.Label();
            this.lblOrderStatistics = new System.Windows.Forms.Label();
            this.pnlCardLowStock = new System.Windows.Forms.Panel();
            this.lblLowStockValue = new System.Windows.Forms.Label();
            this.lblLowStockTitle = new System.Windows.Forms.Label();
            this.pnlCardNewOrders = new System.Windows.Forms.Panel();
            this.lblNewOrdersValue = new System.Windows.Forms.Label();
            this.lblNewOrdersTitle = new System.Windows.Forms.Label();
            this.pnlCardRevenueToday = new System.Windows.Forms.Panel();
            this.lblRevenueTodayValue = new System.Windows.Forms.Label();
            this.lblRevenueTodayTitle = new System.Windows.Forms.Label();
            this.pnlCardEmployees = new System.Windows.Forms.Panel();
            this.lblTotalEmployeesValue = new System.Windows.Forms.Label();
            this.lblTotalEmployeesTitle = new System.Windows.Forms.Label();
            this.pnlCardCustomers = new System.Windows.Forms.Panel();
            this.lblTotalCustomersValue = new System.Windows.Forms.Label();
            this.lblTotalCustomersTitle = new System.Windows.Forms.Label();
            this.pnlOrderStatistics.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartRevenueOverTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartSalesByCustomer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartSalesByEmployee)).BeginInit();
            this.pnlCardLowStock.SuspendLayout();
            this.pnlCardNewOrders.SuspendLayout();
            this.pnlCardRevenueToday.SuspendLayout();
            this.pnlCardEmployees.SuspendLayout();
            this.pnlCardCustomers.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlOrderStatistics
            // 
            this.pnlOrderStatistics.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlOrderStatistics.BackColor = System.Drawing.Color.White;
            this.pnlOrderStatistics.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlOrderStatistics.Controls.Add(this.chartRevenueOverTime);
            this.pnlOrderStatistics.Controls.Add(this.chartSalesByCustomer);
            this.pnlOrderStatistics.Controls.Add(this.chartSalesByEmployee);
            this.pnlOrderStatistics.Controls.Add(this.btnApplyDateRange);
            this.pnlOrderStatistics.Controls.Add(this.dtpToDate);
            this.pnlOrderStatistics.Controls.Add(this.lblToDate);
            this.pnlOrderStatistics.Controls.Add(this.dtpFromDate);
            this.pnlOrderStatistics.Controls.Add(this.lblFromDate);
            this.pnlOrderStatistics.Controls.Add(this.lblOrderStatistics);
            this.pnlOrderStatistics.Location = new System.Drawing.Point(27, 147);
            this.pnlOrderStatistics.Margin = new System.Windows.Forms.Padding(4);
            this.pnlOrderStatistics.Name = "pnlOrderStatistics";
            this.pnlOrderStatistics.Size = new System.Drawing.Size(1351, 638);
            this.pnlOrderStatistics.TabIndex = 3;
            // 
            // chartRevenueOverTime
            // 
            this.chartRevenueOverTime.Anchor = System.Windows.Forms.AnchorStyles.None;
            chartArea10.Name = "ChartArea1";
            this.chartRevenueOverTime.ChartAreas.Add(chartArea10);
            this.chartRevenueOverTime.Location = new System.Drawing.Point(36, 350);
            this.chartRevenueOverTime.Margin = new System.Windows.Forms.Padding(4);
            this.chartRevenueOverTime.Name = "chartRevenueOverTime";
            series10.ChartArea = "ChartArea1";
            series10.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series10.Name = "Revenue";
            this.chartRevenueOverTime.Series.Add(series10);
            this.chartRevenueOverTime.Size = new System.Drawing.Size(1267, 253);
            this.chartRevenueOverTime.TabIndex = 4;
            this.chartRevenueOverTime.Text = "Revenue over Time";
            // 
            // chartSalesByCustomer
            // 
            this.chartSalesByCustomer.Anchor = System.Windows.Forms.AnchorStyles.None;
            chartArea11.Name = "ChartArea1";
            this.chartSalesByCustomer.ChartAreas.Add(chartArea11);
            this.chartSalesByCustomer.Location = new System.Drawing.Point(811, 63);
            this.chartSalesByCustomer.Margin = new System.Windows.Forms.Padding(4);
            this.chartSalesByCustomer.Name = "chartSalesByCustomer";
            series11.ChartArea = "ChartArea1";
            series11.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series11.Name = "Sales";
            this.chartSalesByCustomer.Series.Add(series11);
            this.chartSalesByCustomer.Size = new System.Drawing.Size(491, 269);
            this.chartSalesByCustomer.TabIndex = 3;
            this.chartSalesByCustomer.Text = "Sales by Customer";
            // 
            // chartSalesByEmployee
            // 
            this.chartSalesByEmployee.Anchor = System.Windows.Forms.AnchorStyles.None;
            chartArea12.Name = "ChartArea1";
            this.chartSalesByEmployee.ChartAreas.Add(chartArea12);
            this.chartSalesByEmployee.Location = new System.Drawing.Point(36, 63);
            this.chartSalesByEmployee.Margin = new System.Windows.Forms.Padding(4);
            this.chartSalesByEmployee.Name = "chartSalesByEmployee";
            series12.ChartArea = "ChartArea1";
            series12.Name = "Sales";
            this.chartSalesByEmployee.Series.Add(series12);
            this.chartSalesByEmployee.Size = new System.Drawing.Size(493, 269);
            this.chartSalesByEmployee.TabIndex = 2;
            this.chartSalesByEmployee.Text = "Sales by Employee";
            // 
            // btnApplyDateRange
            // 
            this.btnApplyDateRange.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnApplyDateRange.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnApplyDateRange.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApplyDateRange.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnApplyDateRange.ForeColor = System.Drawing.Color.White;
            this.btnApplyDateRange.Location = new System.Drawing.Point(1175, 18);
            this.btnApplyDateRange.Name = "btnApplyDateRange";
            this.btnApplyDateRange.Size = new System.Drawing.Size(100, 38);
            this.btnApplyDateRange.TabIndex = 9;
            this.btnApplyDateRange.Text = "Apply";
            this.btnApplyDateRange.UseVisualStyleBackColor = false;
            this.btnApplyDateRange.Click += new System.EventHandler(this.btnApplyDateRange_Click);
            // 
            // dtpToDate
            // 
            this.dtpToDate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpToDate.Location = new System.Drawing.Point(980, 20);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(120, 22);
            this.dtpToDate.TabIndex = 8;
            // 
            // lblToDate
            // 
            this.lblToDate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblToDate.AutoSize = true;
            this.lblToDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblToDate.Location = new System.Drawing.Point(900, 23);
            this.lblToDate.Name = "lblToDate";
            this.lblToDate.Size = new System.Drawing.Size(83, 18);
            this.lblToDate.TabIndex = 7;
            this.lblToDate.Text = "To Date:";
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFromDate.Location = new System.Drawing.Point(770, 20);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(120, 22);
            this.dtpFromDate.TabIndex = 6;
            // 
            // lblFromDate
            // 
            this.lblFromDate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblFromDate.AutoSize = true;
            this.lblFromDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblFromDate.Location = new System.Drawing.Point(700, 23);
            this.lblFromDate.Name = "lblFromDate";
            this.lblFromDate.Size = new System.Drawing.Size(72, 18);
            this.lblFromDate.TabIndex = 5;
            this.lblFromDate.Text = "From Date:";
            // 
            // lblOrderStatistics
            // 
            this.lblOrderStatistics.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblOrderStatistics.AutoSize = true;
            this.lblOrderStatistics.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderStatistics.Location = new System.Drawing.Point(32, 23);
            this.lblOrderStatistics.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOrderStatistics.Name = "lblOrderStatistics";
            this.lblOrderStatistics.Size = new System.Drawing.Size(209, 24);
            this.lblOrderStatistics.TabIndex = 0;
            this.lblOrderStatistics.Text = "Order Statistics Panel";
            // 
            // pnlCardLowStock
            // 
            this.pnlCardLowStock.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlCardLowStock.BackColor = System.Drawing.Color.White;
            this.pnlCardLowStock.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCardLowStock.Controls.Add(this.lblLowStockValue);
            this.pnlCardLowStock.Controls.Add(this.lblLowStockTitle);
            this.pnlCardLowStock.Location = new System.Drawing.Point(1079, 4);
            this.pnlCardLowStock.Margin = new System.Windows.Forms.Padding(4);
            this.pnlCardLowStock.Name = "pnlCardLowStock";
            this.pnlCardLowStock.Size = new System.Drawing.Size(299, 135);
            this.pnlCardLowStock.TabIndex = 2;
            // 
            // lblLowStockValue
            // 
            this.lblLowStockValue.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblLowStockValue.AutoSize = true;
            this.lblLowStockValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLowStockValue.Location = new System.Drawing.Point(115, 62);
            this.lblLowStockValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLowStockValue.Name = "lblLowStockValue";
            this.lblLowStockValue.Size = new System.Drawing.Size(76, 46);
            this.lblLowStockValue.TabIndex = 1;
            this.lblLowStockValue.Text = "XX";
            // 
            // lblLowStockTitle
            // 
            this.lblLowStockTitle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblLowStockTitle.AutoSize = true;
            this.lblLowStockTitle.ForeColor = System.Drawing.Color.Gray;
            this.lblLowStockTitle.Location = new System.Drawing.Point(120, 28);
            this.lblLowStockTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLowStockTitle.Name = "lblLowStockTitle";
            this.lblLowStockTitle.Size = new System.Drawing.Size(68, 16);
            this.lblLowStockTitle.TabIndex = 0;
            this.lblLowStockTitle.Text = "Low Stock";
            // 
            // pnlCardNewOrders
            // 
            this.pnlCardNewOrders.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlCardNewOrders.BackColor = System.Drawing.Color.White;
            this.pnlCardNewOrders.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCardNewOrders.Controls.Add(this.lblNewOrdersValue);
            this.pnlCardNewOrders.Controls.Add(this.lblNewOrdersTitle);
            this.pnlCardNewOrders.Location = new System.Drawing.Point(775, 4);
            this.pnlCardNewOrders.Margin = new System.Windows.Forms.Padding(4);
            this.pnlCardNewOrders.Name = "pnlCardNewOrders";
            this.pnlCardNewOrders.Size = new System.Drawing.Size(282, 135);
            this.pnlCardNewOrders.TabIndex = 1;
            // 
            // lblNewOrdersValue
            // 
            this.lblNewOrdersValue.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblNewOrdersValue.AutoSize = true;
            this.lblNewOrdersValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNewOrdersValue.Location = new System.Drawing.Point(105, 62);
            this.lblNewOrdersValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNewOrdersValue.Name = "lblNewOrdersValue";
            this.lblNewOrdersValue.Size = new System.Drawing.Size(104, 46);
            this.lblNewOrdersValue.TabIndex = 1;
            this.lblNewOrdersValue.Text = "XXX";
            // 
            // lblNewOrdersTitle
            // 
            this.lblNewOrdersTitle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblNewOrdersTitle.AutoSize = true;
            this.lblNewOrdersTitle.ForeColor = System.Drawing.Color.Gray;
            this.lblNewOrdersTitle.Location = new System.Drawing.Point(110, 25);
            this.lblNewOrdersTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNewOrdersTitle.Name = "lblNewOrdersTitle";
            this.lblNewOrdersTitle.Size = new System.Drawing.Size(78, 16);
            this.lblNewOrdersTitle.TabIndex = 0;
            this.lblNewOrdersTitle.Text = "New Orders";
            // 
            // pnlCardRevenueToday
            // 
            this.pnlCardRevenueToday.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlCardRevenueToday.BackColor = System.Drawing.Color.White;
            this.pnlCardRevenueToday.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCardRevenueToday.Controls.Add(this.lblRevenueTodayValue);
            this.pnlCardRevenueToday.Controls.Add(this.lblRevenueTodayTitle);
            this.pnlCardRevenueToday.Location = new System.Drawing.Point(469, 4);
            this.pnlCardRevenueToday.Margin = new System.Windows.Forms.Padding(4);
            this.pnlCardRevenueToday.Name = "pnlCardRevenueToday";
            this.pnlCardRevenueToday.Size = new System.Drawing.Size(282, 135);
            this.pnlCardRevenueToday.TabIndex = 0;
            // 
            // lblRevenueTodayValue
            // 
            this.lblRevenueTodayValue.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblRevenueTodayValue.AutoSize = true;
            this.lblRevenueTodayValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRevenueTodayValue.Location = new System.Drawing.Point(28, 62);
            this.lblRevenueTodayValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRevenueTodayValue.Name = "lblRevenueTodayValue";
            this.lblRevenueTodayValue.Size = new System.Drawing.Size(43, 46);
            this.lblRevenueTodayValue.TabIndex = 1;
            this.lblRevenueTodayValue.Text = "$";
            
            // 
            // lblRevenueTodayTitle
            // 
            this.lblRevenueTodayTitle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblRevenueTodayTitle.AutoSize = true;
            this.lblRevenueTodayTitle.ForeColor = System.Drawing.Color.Gray;
            this.lblRevenueTodayTitle.Location = new System.Drawing.Point(94, 25);
            this.lblRevenueTodayTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRevenueTodayTitle.Name = "lblRevenueTodayTitle";
            this.lblRevenueTodayTitle.Size = new System.Drawing.Size(105, 16);
            this.lblRevenueTodayTitle.TabIndex = 2;
            this.lblRevenueTodayTitle.Text = "Revenue Today";
            // 
            // pnlCardEmployees
            // 
            this.pnlCardEmployees.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlCardEmployees.BackColor = System.Drawing.Color.White;
            this.pnlCardEmployees.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCardEmployees.Controls.Add(this.lblTotalEmployeesValue);
            this.pnlCardEmployees.Controls.Add(this.lblTotalEmployeesTitle);
            this.pnlCardEmployees.Location = new System.Drawing.Point(27, 4);
            this.pnlCardEmployees.Margin = new System.Windows.Forms.Padding(4);
            this.pnlCardEmployees.Name = "pnlCardEmployees";
            this.pnlCardEmployees.Size = new System.Drawing.Size(200, 135);
            this.pnlCardEmployees.TabIndex = 4;
            // 
            // lblTotalEmployeesValue
            // 
            this.lblTotalEmployeesValue.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTotalEmployeesValue.AutoSize = true;
            this.lblTotalEmployeesValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalEmployeesValue.ForeColor = System.Drawing.Color.Black;
            this.lblTotalEmployeesValue.Location = new System.Drawing.Point(82, 62);
            this.lblTotalEmployeesValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalEmployeesValue.Name = "lblTotalEmployeesValue";
            this.lblTotalEmployeesValue.Size = new System.Drawing.Size(43, 46);
            this.lblTotalEmployeesValue.TabIndex = 1;
            this.lblTotalEmployeesValue.Text = "0";
            // 
            // lblTotalEmployeesTitle
            // 
            this.lblTotalEmployeesTitle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTotalEmployeesTitle.AutoSize = true;
            this.lblTotalEmployeesTitle.BackColor = System.Drawing.Color.White;
            this.lblTotalEmployeesTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblTotalEmployeesTitle.ForeColor = System.Drawing.Color.Black;
            this.lblTotalEmployeesTitle.Location = new System.Drawing.Point(57, 24);
            this.lblTotalEmployeesTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalEmployeesTitle.Name = "lblTotalEmployeesTitle";
            this.lblTotalEmployeesTitle.Size = new System.Drawing.Size(100, 20);
            this.lblTotalEmployeesTitle.TabIndex = 0;
            this.lblTotalEmployeesTitle.Text = "Employees";
            // 
            // pnlCardCustomers
            // 
            this.pnlCardCustomers.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlCardCustomers.BackColor = System.Drawing.Color.White;
            this.pnlCardCustomers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCardCustomers.Controls.Add(this.lblTotalCustomersValue);
            this.pnlCardCustomers.Controls.Add(this.lblTotalCustomersTitle);
            this.pnlCardCustomers.Location = new System.Drawing.Point(240, 4);
            this.pnlCardCustomers.Margin = new System.Windows.Forms.Padding(4);
            this.pnlCardCustomers.Name = "pnlCardCustomers";
            this.pnlCardCustomers.Size = new System.Drawing.Size(200, 135);
            this.pnlCardCustomers.TabIndex = 5;
            // 
            // lblTotalCustomersValue
            // 
            this.lblTotalCustomersValue.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTotalCustomersValue.AutoSize = true;
            this.lblTotalCustomersValue.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalCustomersValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalCustomersValue.ForeColor = System.Drawing.Color.Black;
            this.lblTotalCustomersValue.Location = new System.Drawing.Point(79, 62);
            this.lblTotalCustomersValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalCustomersValue.Name = "lblTotalCustomersValue";
            this.lblTotalCustomersValue.Size = new System.Drawing.Size(43, 46);
            this.lblTotalCustomersValue.TabIndex = 1;
            this.lblTotalCustomersValue.Text = "0";
            // 
            // lblTotalCustomersTitle
            // 
            this.lblTotalCustomersTitle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTotalCustomersTitle.AutoSize = true;
            this.lblTotalCustomersTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalCustomersTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblTotalCustomersTitle.ForeColor = System.Drawing.Color.Black;
            this.lblTotalCustomersTitle.Location = new System.Drawing.Point(55, 24);
            this.lblTotalCustomersTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalCustomersTitle.Name = "lblTotalCustomersTitle";
            this.lblTotalCustomersTitle.Size = new System.Drawing.Size(100, 20);
            this.lblTotalCustomersTitle.TabIndex = 0;
            this.lblTotalCustomersTitle.Text = "Customers";
            // 
            // ucDashboardHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.pnlCardLowStock);
            this.Controls.Add(this.pnlCardNewOrders);
            this.Controls.Add(this.pnlCardRevenueToday);
            this.Controls.Add(this.pnlOrderStatistics);
            this.Controls.Add(this.pnlCardEmployees);
            this.Controls.Add(this.pnlCardCustomers);
            this.Name = "ucDashboardHome";
            this.Size = new System.Drawing.Size(1393, 800);
            this.pnlOrderStatistics.ResumeLayout(false);
            this.pnlOrderStatistics.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartRevenueOverTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartSalesByCustomer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartSalesByEmployee)).EndInit();
            this.pnlCardLowStock.ResumeLayout(false);
            this.pnlCardLowStock.PerformLayout();
            this.pnlCardNewOrders.ResumeLayout(false);
            this.pnlCardNewOrders.PerformLayout();
            this.pnlCardRevenueToday.ResumeLayout(false);
            this.pnlCardRevenueToday.PerformLayout();
            this.pnlCardEmployees.ResumeLayout(false);
            this.pnlCardEmployees.PerformLayout();
            this.pnlCardCustomers.ResumeLayout(false);
            this.pnlCardCustomers.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlOrderStatistics;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartRevenueOverTime;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartSalesByCustomer;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartSalesByEmployee;
        private System.Windows.Forms.Label lblOrderStatistics;
        private System.Windows.Forms.Panel pnlCardLowStock;
        private System.Windows.Forms.Label lblLowStockValue;
        private System.Windows.Forms.Label lblLowStockTitle;
        private System.Windows.Forms.Panel pnlCardNewOrders;
        private System.Windows.Forms.Label lblNewOrdersValue;
        private System.Windows.Forms.Label lblNewOrdersTitle;
        private System.Windows.Forms.Panel pnlCardRevenueToday;
        private System.Windows.Forms.Label lblRevenueTodayValue;
        private System.Windows.Forms.Label lblRevenueTodayTitle;
        // Card Employees
        private System.Windows.Forms.Panel pnlCardEmployees;
        private System.Windows.Forms.Label lblTotalEmployeesValue;
        private System.Windows.Forms.Label lblTotalEmployeesTitle;
        // Card Customers
        private System.Windows.Forms.Panel pnlCardCustomers;
        private System.Windows.Forms.Label lblTotalCustomersValue;
        private System.Windows.Forms.Label lblTotalCustomersTitle;
        // Date Range Controls
        private System.Windows.Forms.Label lblFromDate;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.Label lblToDate;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.Button btnApplyDateRange;
    }
}
