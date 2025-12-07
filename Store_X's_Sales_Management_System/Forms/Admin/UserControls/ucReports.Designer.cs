namespace Store_X_s_Sales_Management_System.Forms.Admin.UserControls
{
    partial class ucReports
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.pnlFilters = new System.Windows.Forms.Panel();
            this.btnExportPDF = new System.Windows.Forms.Button();
            this.btnExportExcel = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.lblToDate = new System.Windows.Forms.Label();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.lblFromDate = new System.Windows.Forms.Label();
            this.cboReportType = new System.Windows.Forms.ComboBox();
            this.lblReportType = new System.Windows.Forms.Label();
            this.pnlStats = new System.Windows.Forms.Panel();
            this.pnlCardAverage = new System.Windows.Forms.Panel();
            this.lblAverageValue = new System.Windows.Forms.Label();
            this.lblAverageTitle = new System.Windows.Forms.Label();
            this.pnlCardTotalValue = new System.Windows.Forms.Panel();
            this.lblTotalValueAmount = new System.Windows.Forms.Label();
            this.lblTotalValueTitle = new System.Windows.Forms.Label();
            this.pnlCardTotalRecords = new System.Windows.Forms.Panel();
            this.lblTotalRecordsValue = new System.Windows.Forms.Label();
            this.lblTotalRecordsTitle = new System.Windows.Forms.Label();
            this.chartReport = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.pnlDetails = new System.Windows.Forms.Panel();
            this.dgvReportDetails = new System.Windows.Forms.DataGridView();
            this.colDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlFilters.SuspendLayout();
            this.pnlStats.SuspendLayout();
            this.pnlCardAverage.SuspendLayout();
            this.pnlCardTotalValue.SuspendLayout();
            this.pnlCardTotalRecords.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartReport)).BeginInit();
            this.pnlDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReportDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlFilters
            // 
            this.pnlFilters.BackColor = System.Drawing.Color.White;
            this.pnlFilters.Controls.Add(this.btnExportPDF);
            this.pnlFilters.Controls.Add(this.btnExportExcel);
            this.pnlFilters.Controls.Add(this.btnPrint);
            this.pnlFilters.Controls.Add(this.btnGenerate);
            this.pnlFilters.Controls.Add(this.dtpToDate);
            this.pnlFilters.Controls.Add(this.lblToDate);
            this.pnlFilters.Controls.Add(this.dtpFromDate);
            this.pnlFilters.Controls.Add(this.lblFromDate);
            this.pnlFilters.Controls.Add(this.cboReportType);
            this.pnlFilters.Controls.Add(this.lblReportType);
            this.pnlFilters.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilters.Location = new System.Drawing.Point(0, 0);
            this.pnlFilters.Name = "pnlFilters";
            this.pnlFilters.Size = new System.Drawing.Size(1200, 100);
            this.pnlFilters.TabIndex = 0;
            // 
            // btnExportPDF
            // 
            this.btnExportPDF.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportPDF.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnExportPDF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportPDF.Location = new System.Drawing.Point(1080, 55);
            this.btnExportPDF.Name = "btnExportPDF";
            this.btnExportPDF.Size = new System.Drawing.Size(100, 35);
            this.btnExportPDF.TabIndex = 9;
            this.btnExportPDF.Text = "Export PDF";
            this.btnExportPDF.Visible = false;
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportExcel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnExportExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportExcel.Location = new System.Drawing.Point(970, 55);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(100, 35);
            this.btnExportExcel.TabIndex = 8;
            this.btnExportExcel.Text = "Export Excel";
            this.btnExportExcel.UseVisualStyleBackColor = false;
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Location = new System.Drawing.Point(1080, 15);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(100, 35);
            this.btnPrint.TabIndex = 7;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = false;
            // 
            // btnGenerate
            // 
            this.btnGenerate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenerate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnGenerate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerate.ForeColor = System.Drawing.Color.White;
            this.btnGenerate.Location = new System.Drawing.Point(930, 15);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(140, 35);
            this.btnGenerate.TabIndex = 6;
            this.btnGenerate.Text = "Generate Report";
            this.btnGenerate.UseVisualStyleBackColor = false;
            // 
            // dtpToDate
            // 
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpToDate.Location = new System.Drawing.Point(780, 20);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(120, 22);
            this.dtpToDate.TabIndex = 5;
            // 
            // lblToDate
            // 
            this.lblToDate.AutoSize = true;
            this.lblToDate.Location = new System.Drawing.Point(710, 23);
            this.lblToDate.Name = "lblToDate";
            this.lblToDate.Size = new System.Drawing.Size(56, 16);
            this.lblToDate.TabIndex = 4;
            this.lblToDate.Text = "To Date";
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFromDate.Location = new System.Drawing.Point(570, 20);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(120, 22);
            this.dtpFromDate.TabIndex = 3;
            // 
            // lblFromDate
            // 
            this.lblFromDate.AutoSize = true;
            this.lblFromDate.Location = new System.Drawing.Point(480, 23);
            this.lblFromDate.Name = "lblFromDate";
            this.lblFromDate.Size = new System.Drawing.Size(70, 16);
            this.lblFromDate.TabIndex = 2;
            this.lblFromDate.Text = "From Date";
            // 
            // cboReportType
            // 
            this.cboReportType.FormattingEnabled = true;
            this.cboReportType.Items.AddRange(new object[] {
            "Revenue Analysis",
            "Sales by Employee",
            "Inventory Status"});
            this.cboReportType.Location = new System.Drawing.Point(133, 20);
            this.cboReportType.Name = "cboReportType";
            this.cboReportType.Size = new System.Drawing.Size(200, 24);
            this.cboReportType.TabIndex = 1;
            this.cboReportType.Text = "Revenue Analysis";
            // 
            // lblReportType
            // 
            this.lblReportType.AutoSize = true;
            this.lblReportType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReportType.Location = new System.Drawing.Point(10, 22);
            this.lblReportType.Name = "lblReportType";
            this.lblReportType.Size = new System.Drawing.Size(117, 20);
            this.lblReportType.TabIndex = 0;
            this.lblReportType.Text = "Report Type:";
            // 
            // pnlStats
            // 
            this.pnlStats.Controls.Add(this.pnlCardAverage);
            this.pnlStats.Controls.Add(this.pnlCardTotalValue);
            this.pnlStats.Controls.Add(this.pnlCardTotalRecords);
            this.pnlStats.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlStats.Location = new System.Drawing.Point(0, 100);
            this.pnlStats.Name = "pnlStats";
            this.pnlStats.Padding = new System.Windows.Forms.Padding(20);
            this.pnlStats.Size = new System.Drawing.Size(1200, 150);
            this.pnlStats.TabIndex = 1;
            // 
            // pnlCardAverage
            // 
            this.pnlCardAverage.BackColor = System.Drawing.Color.White;
            this.pnlCardAverage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCardAverage.Controls.Add(this.lblAverageValue);
            this.pnlCardAverage.Controls.Add(this.lblAverageTitle);
            this.pnlCardAverage.Location = new System.Drawing.Point(820, 20);
            this.pnlCardAverage.Name = "pnlCardAverage";
            this.pnlCardAverage.Size = new System.Drawing.Size(350, 110);
            this.pnlCardAverage.TabIndex = 2;
            // 
            // lblAverageValue
            // 
            this.lblAverageValue.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblAverageValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAverageValue.Location = new System.Drawing.Point(0, 58);
            this.lblAverageValue.Name = "lblAverageValue";
            this.lblAverageValue.Size = new System.Drawing.Size(348, 50);
            this.lblAverageValue.TabIndex = 1;
            this.lblAverageValue.Text = "$123.45";
            this.lblAverageValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAverageTitle
            // 
            this.lblAverageTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblAverageTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAverageTitle.Location = new System.Drawing.Point(0, 0);
            this.lblAverageTitle.Name = "lblAverageTitle";
            this.lblAverageTitle.Size = new System.Drawing.Size(348, 40);
            this.lblAverageTitle.TabIndex = 0;
            this.lblAverageTitle.Text = "Average";
            this.lblAverageTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlCardTotalValue
            // 
            this.pnlCardTotalValue.BackColor = System.Drawing.Color.White;
            this.pnlCardTotalValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCardTotalValue.Controls.Add(this.lblTotalValueAmount);
            this.pnlCardTotalValue.Controls.Add(this.lblTotalValueTitle);
            this.pnlCardTotalValue.Location = new System.Drawing.Point(420, 20);
            this.pnlCardTotalValue.Name = "pnlCardTotalValue";
            this.pnlCardTotalValue.Size = new System.Drawing.Size(350, 110);
            this.pnlCardTotalValue.TabIndex = 1;
            // 
            // lblTotalValueAmount
            // 
            this.lblTotalValueAmount.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblTotalValueAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalValueAmount.Location = new System.Drawing.Point(0, 58);
            this.lblTotalValueAmount.Name = "lblTotalValueAmount";
            this.lblTotalValueAmount.Size = new System.Drawing.Size(348, 50);
            this.lblTotalValueAmount.TabIndex = 1;
            this.lblTotalValueAmount.Text = "$123,456.78";
            this.lblTotalValueAmount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTotalValueTitle
            // 
            this.lblTotalValueTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTotalValueTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalValueTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTotalValueTitle.Name = "lblTotalValueTitle";
            this.lblTotalValueTitle.Size = new System.Drawing.Size(348, 40);
            this.lblTotalValueTitle.TabIndex = 0;
            this.lblTotalValueTitle.Text = "Total Value";
            this.lblTotalValueTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlCardTotalRecords
            // 
            this.pnlCardTotalRecords.BackColor = System.Drawing.Color.White;
            this.pnlCardTotalRecords.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCardTotalRecords.Controls.Add(this.lblTotalRecordsValue);
            this.pnlCardTotalRecords.Controls.Add(this.lblTotalRecordsTitle);
            this.pnlCardTotalRecords.Location = new System.Drawing.Point(20, 20);
            this.pnlCardTotalRecords.Name = "pnlCardTotalRecords";
            this.pnlCardTotalRecords.Size = new System.Drawing.Size(350, 110);
            this.pnlCardTotalRecords.TabIndex = 0;
            // 
            // lblTotalRecordsValue
            // 
            this.lblTotalRecordsValue.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblTotalRecordsValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalRecordsValue.Location = new System.Drawing.Point(0, 58);
            this.lblTotalRecordsValue.Name = "lblTotalRecordsValue";
            this.lblTotalRecordsValue.Size = new System.Drawing.Size(348, 50);
            this.lblTotalRecordsValue.TabIndex = 1;
            this.lblTotalRecordsValue.Text = "1,234";
            this.lblTotalRecordsValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTotalRecordsTitle
            // 
            this.lblTotalRecordsTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTotalRecordsTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalRecordsTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTotalRecordsTitle.Name = "lblTotalRecordsTitle";
            this.lblTotalRecordsTitle.Size = new System.Drawing.Size(348, 40);
            this.lblTotalRecordsTitle.TabIndex = 0;
            this.lblTotalRecordsTitle.Text = "Total Records";
            this.lblTotalRecordsTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chartReport
            // 
            chartArea1.Name = "ChartArea1";
            this.chartReport.ChartAreas.Add(chartArea1);
            this.chartReport.Dock = System.Windows.Forms.DockStyle.Top;
            legend1.Name = "Legend1";
            this.chartReport.Legends.Add(legend1);
            this.chartReport.Location = new System.Drawing.Point(0, 250);
            this.chartReport.Name = "chartReport";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartReport.Series.Add(series1);
            this.chartReport.Size = new System.Drawing.Size(1200, 300);
            this.chartReport.TabIndex = 2;
            this.chartReport.Text = "chart1";
            // 
            // pnlDetails
            // 
            this.pnlDetails.Controls.Add(this.dgvReportDetails);
            this.pnlDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDetails.Location = new System.Drawing.Point(0, 550);
            this.pnlDetails.Name = "pnlDetails";
            this.pnlDetails.Padding = new System.Windows.Forms.Padding(20);
            this.pnlDetails.Size = new System.Drawing.Size(1200, 250);
            this.pnlDetails.TabIndex = 3;
            // 
            // dgvReportDetails
            // 
            this.dgvReportDetails.AllowUserToAddRows = false;
            this.dgvReportDetails.AllowUserToDeleteRows = false;
            this.dgvReportDetails.BackgroundColor = System.Drawing.Color.White;
            this.dgvReportDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReportDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDate,
            this.colItemName,
            this.colQuantity,
            this.colAmount});
            this.dgvReportDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvReportDetails.Location = new System.Drawing.Point(20, 20);
            this.dgvReportDetails.Name = "dgvReportDetails";
            this.dgvReportDetails.ReadOnly = true;
            this.dgvReportDetails.RowHeadersWidth = 51;
            this.dgvReportDetails.RowTemplate.Height = 24;
            this.dgvReportDetails.Size = new System.Drawing.Size(1160, 210);
            this.dgvReportDetails.TabIndex = 0;
            // 
            // colDate
            // 
            this.colDate.HeaderText = "Date";
            this.colDate.MinimumWidth = 6;
            this.colDate.Name = "colDate";
            this.colDate.ReadOnly = true;
            this.colDate.Width = 125;
            // 
            // colItemName
            // 
            this.colItemName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colItemName.HeaderText = "Item Name";
            this.colItemName.MinimumWidth = 6;
            this.colItemName.Name = "colItemName";
            this.colItemName.ReadOnly = true;
            // 
            // colQuantity
            // 
            this.colQuantity.HeaderText = "Quantity";
            this.colQuantity.MinimumWidth = 6;
            this.colQuantity.Name = "colQuantity";
            this.colQuantity.ReadOnly = true;
            this.colQuantity.Width = 125;
            // 
            // colAmount
            // 
            this.colAmount.HeaderText = "Amount";
            this.colAmount.MinimumWidth = 6;
            this.colAmount.Name = "colAmount";
            this.colAmount.ReadOnly = true;
            this.colAmount.Width = 125;
            // 
            // ucReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlDetails);
            this.Controls.Add(this.chartReport);
            this.Controls.Add(this.pnlStats);
            this.Controls.Add(this.pnlFilters);
            this.Name = "ucReports";
            this.Size = new System.Drawing.Size(1200, 800);
            this.pnlFilters.ResumeLayout(false);
            this.pnlFilters.PerformLayout();
            this.pnlStats.ResumeLayout(false);
            this.pnlCardAverage.ResumeLayout(false);
            this.pnlCardTotalValue.ResumeLayout(false);
            this.pnlCardTotalRecords.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartReport)).EndInit();
            this.pnlDetails.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReportDetails)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlFilters;
        private System.Windows.Forms.Label lblReportType;
        private System.Windows.Forms.ComboBox cboReportType;
        private System.Windows.Forms.Label lblFromDate;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.Label lblToDate;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnExportExcel;
        private System.Windows.Forms.Button btnExportPDF;
        private System.Windows.Forms.Panel pnlStats;
        private System.Windows.Forms.Panel pnlCardTotalRecords;
        private System.Windows.Forms.Label lblTotalRecordsTitle;
        private System.Windows.Forms.Label lblTotalRecordsValue;
        private System.Windows.Forms.Panel pnlCardTotalValue;
        private System.Windows.Forms.Label lblTotalValueAmount;
        private System.Windows.Forms.Label lblTotalValueTitle;
        private System.Windows.Forms.Panel pnlCardAverage;
        private System.Windows.Forms.Label lblAverageValue;
        private System.Windows.Forms.Label lblAverageTitle;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartReport;
        private System.Windows.Forms.Panel pnlDetails;
        private System.Windows.Forms.DataGridView dgvReportDetails;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAmount;
    }
}
