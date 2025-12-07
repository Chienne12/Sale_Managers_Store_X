using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Store_X_s_Sales_Management_System.Forms.Admin.UserControls
{
    public partial class ucReports : UserControl
    {
        public ucReports()
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
                // Set default date range (last 30 days)
                dtpFromDate.Value = DateTime.Today.AddDays(-30);
                dtpToDate.Value = DateTime.Today;

                // Set default report type
                cboReportType.SelectedIndex = 0;

                // Wire up events
                btnGenerate.Click += btnGenerate_Click;
                cboReportType.SelectedIndexChanged += cboReportType_SelectedIndexChanged;
                btnExportExcel.Click += btnExportExcel_Click;
                btnExportPDF.Click += btnExportPDF_Click;
                btnPrint.Click += btnPrint_Click;

                // Setup chart
                chartReport.Series.Clear();
                chartReport.Series.Add("Data");
                chartReport.Series["Data"].ChartType = SeriesChartType.Column;

                // Load initial report
                LoadRevenueReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error initializing: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Handle Generate Report button click
        /// </summary>
        private void btnGenerate_Click(object sender, EventArgs e)
        {
            // Validate date range
            if (dtpFromDate.Value > dtpToDate.Value)
            {
                MessageBox.Show("Start date must be before or equal to end date!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            GenerateReport();
        }

        /// <summary>
        /// Handle report type change
        /// </summary>
        private void cboReportType_SelectedIndexChanged(object sender, EventArgs e)
        {
            GenerateReport();
        }

        /// <summary>
        /// Generate report based on selected type
        /// </summary>
        private void GenerateReport()
        {
            switch (cboReportType.SelectedIndex)
            {
                case 0: // Revenue Analysis
                    LoadRevenueReport();
                    break;
                case 1: // Sales by Employee
                    LoadEmployeeSalesReport();
                    break;
                case 2: // Inventory Status
                    LoadInventoryReport();
                    break;
                default:
                    LoadRevenueReport();
                    break;
            }
        }

        /// <summary>
        /// Load revenue analysis report
        /// </summary>
        private void LoadRevenueReport()
        {
            try
            {
                DateTime fromDate = dtpFromDate.Value.Date;
                DateTime toDate = dtpToDate.Value.Date;

                // Query daily revenue
                string query = @"SELECT 
                    CAST(OrderDate AS DATE) AS OrderDate,
                    COUNT(OrderId) AS TotalOrders,
                    SUM(TotalAmount) AS Revenue
                FROM Orders
                WHERE CAST(OrderDate AS DATE) >= @FromDate
                  AND CAST(OrderDate AS DATE) <= @ToDate
                  AND OrderStatus = 'Completed'
                GROUP BY CAST(OrderDate AS DATE)
                ORDER BY OrderDate";

                SqlParameter[] parameters = {
                    new SqlParameter("@FromDate", fromDate),
                    new SqlParameter("@ToDate", toDate)
                };

                DataTable dt = DatabaseConnection.ExecuteQuery(query, parameters);

                // Update statistics cards
                int totalOrders = 0;
                decimal totalRevenue = 0;
                foreach (DataRow row in dt.Rows)
                {
                    totalOrders += Convert.ToInt32(row["TotalOrders"]);
                    totalRevenue += Convert.ToDecimal(row["Revenue"]);
                }

                lblTotalRecordsTitle.Text = "Total Orders";
                lblTotalRecordsValue.Text = totalOrders.ToString("N0");
                lblTotalValueTitle.Text = "Total Revenue";
                lblTotalValueAmount.Text = totalRevenue.ToString("N0") + " VND";
                lblAverageTitle.Text = "Average Order";
                lblAverageValue.Text = (totalOrders > 0 ? (totalRevenue / totalOrders) : 0).ToString("N0") + " VND";

                // Update chart
                chartReport.Series["Data"].Points.Clear();
                chartReport.Series["Data"].ChartType = SeriesChartType.Line;
                foreach (DataRow row in dt.Rows)
                {
                    chartReport.Series["Data"].Points.AddXY(
                        Convert.ToDateTime(row["OrderDate"]).ToString("dd/MM"),
                        Convert.ToDouble(row["Revenue"])
                    );
                }

                // Update grid headers
                SetGridHeaders("Date", "Total Orders", "", "Revenue");
                dgvReportDetails.Rows.Clear();
                foreach (DataRow row in dt.Rows)
                {
                    dgvReportDetails.Rows.Add(
                        Convert.ToDateTime(row["OrderDate"]).ToString("dd/MM/yyyy"),
                        $"{row["TotalOrders"]} orders",
                        "-",
                        Convert.ToDecimal(row["Revenue"]).ToString("N0")
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading revenue report: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Load sales by employee report
        /// </summary>
        private void LoadEmployeeSalesReport()
        {
            try
            {
                DateTime fromDate = dtpFromDate.Value.Date;
                DateTime toDate = dtpToDate.Value.Date;

                string query = @"SELECT 
                    e.EmployeeName,
                    COUNT(o.OrderId) AS TotalOrders,
                    ISNULL(SUM(o.TotalAmount), 0) AS TotalSales
                FROM Employees e
                LEFT JOIN Orders o ON e.EmployeeId = o.EmployeeId 
                    AND o.OrderStatus = 'Completed'
                    AND CAST(o.OrderDate AS DATE) >= @FromDate
                    AND CAST(o.OrderDate AS DATE) <= @ToDate
                GROUP BY e.EmployeeId, e.EmployeeName
                ORDER BY TotalSales DESC";

                SqlParameter[] parameters = {
                    new SqlParameter("@FromDate", fromDate),
                    new SqlParameter("@ToDate", toDate)
                };

                DataTable dt = DatabaseConnection.ExecuteQuery(query, parameters);

                // Update statistics
                int totalOrders = 0;
                decimal totalSales = 0;
                int employeeCount = dt.Rows.Count;
                foreach (DataRow row in dt.Rows)
                {
                    totalOrders += Convert.ToInt32(row["TotalOrders"]);
                    totalSales += Convert.ToDecimal(row["TotalSales"]);
                }

                lblTotalRecordsTitle.Text = "Total Employees";
                lblTotalRecordsValue.Text = employeeCount.ToString();
                lblTotalValueTitle.Text = "Total Sales";
                lblTotalValueAmount.Text = totalSales.ToString("N0") + " VND";
                lblAverageTitle.Text = "Average per Employee";
                lblAverageValue.Text = (employeeCount > 0 ? (totalSales / employeeCount) : 0).ToString("N0") + " VND";

                // Update chart
                chartReport.Series["Data"].Points.Clear();
                chartReport.Series["Data"].ChartType = SeriesChartType.Bar;
                foreach (DataRow row in dt.Rows)
                {
                    chartReport.Series["Data"].Points.AddXY(
                        row["EmployeeName"].ToString(),
                        Convert.ToDouble(row["TotalSales"])
                    );
                }

                // Update grid headers
                SetGridHeaders("", "Employee Name", "Total Orders", "Total Sales");
                dgvReportDetails.Rows.Clear();
                foreach (DataRow row in dt.Rows)
                {
                    dgvReportDetails.Rows.Add(
                        "-",
                        row["EmployeeName"],
                        row["TotalOrders"].ToString() + " orders",
                        Convert.ToDecimal(row["TotalSales"]).ToString("N0")
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading employee report: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Load inventory status report
        /// </summary>
        private void LoadInventoryReport()
        {
            try
            {
                string query = @"SELECT 
                    p.ProductName,
                    c.CategoryName,
                    p.StockQuantity,
                    p.ProductPrice,
                    (p.StockQuantity * p.ProductPrice) AS InventoryValue
                FROM Products p
                INNER JOIN Categories c ON p.CategoryId = c.CategoryId
                ORDER BY p.StockQuantity ASC";

                DataTable dt = DatabaseConnection.ExecuteQuery(query, null);

                // Update statistics
                int totalProducts = dt.Rows.Count;
                int lowStockCount = 0;
                decimal totalValue = 0;
                foreach (DataRow row in dt.Rows)
                {
                    int stock = Convert.ToInt32(row["StockQuantity"]);
                    if (stock < 10) lowStockCount++;
                    totalValue += Convert.ToDecimal(row["InventoryValue"]);
                }

                lblTotalRecordsTitle.Text = "Total Products";
                lblTotalRecordsValue.Text = totalProducts.ToString();
                lblTotalValueTitle.Text = "Inventory Value";
                lblTotalValueAmount.Text = totalValue.ToString("N0") + " VND";
                lblAverageTitle.Text = "Low Stock Items";
                lblAverageValue.Text = lowStockCount.ToString();

                // Update chart - show by category
                string categoryQuery = @"SELECT 
                    c.CategoryName,
                    SUM(p.StockQuantity) AS TotalStock
                FROM Products p
                INNER JOIN Categories c ON p.CategoryId = c.CategoryId
                GROUP BY c.CategoryName";

                DataTable categoryDt = DatabaseConnection.ExecuteQuery(categoryQuery, null);

                chartReport.Series["Data"].Points.Clear();
                chartReport.Series["Data"].ChartType = SeriesChartType.Pie;
                foreach (DataRow row in categoryDt.Rows)
                {
                    chartReport.Series["Data"].Points.AddXY(
                        row["CategoryName"].ToString(),
                        Convert.ToDouble(row["TotalStock"])
                    );
                }

                // Update grid headers
                SetGridHeaders("Category", "Product Name", "Stock Qty", "Inventory Value");
                dgvReportDetails.Rows.Clear();
                foreach (DataRow row in dt.Rows)
                {
                    dgvReportDetails.Rows.Add(
                        row["CategoryName"],
                        row["ProductName"],
                        row["StockQuantity"],
                        Convert.ToDecimal(row["InventoryValue"]).ToString("N0")
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading inventory report: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Export report to Excel (CSV format)
        /// </summary>
        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvReportDetails.Rows.Count == 0)
                {
                    MessageBox.Show("No data to export!", "Warning",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
                saveDialog.FileName = $"Report_{cboReportType.Text}_{DateTime.Now:yyyyMMdd_HHmmss}.csv";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    StringBuilder sb = new StringBuilder();

                    // Header
                    sb.AppendLine($"Report: {cboReportType.Text}");
                    sb.AppendLine($"Date Range: {dtpFromDate.Value:dd/MM/yyyy} - {dtpToDate.Value:dd/MM/yyyy}");
                    sb.AppendLine($"Generated: {DateTime.Now:dd/MM/yyyy HH:mm:ss}");
                    sb.AppendLine();

                    // Statistics
                    sb.AppendLine($"{lblTotalRecordsTitle.Text},{lblTotalRecordsValue.Text}");
                    sb.AppendLine($"{lblTotalValueTitle.Text},{lblTotalValueAmount.Text}");
                    sb.AppendLine($"{lblAverageTitle.Text},{lblAverageValue.Text}");
                    sb.AppendLine();

                    // Column headers
                    string[] headers = new string[dgvReportDetails.Columns.Count];
                    for (int i = 0; i < dgvReportDetails.Columns.Count; i++)
                    {
                        headers[i] = dgvReportDetails.Columns[i].HeaderText;
                    }
                    sb.AppendLine(string.Join(",", headers));

                    // Data rows
                    foreach (DataGridViewRow row in dgvReportDetails.Rows)
                    {
                        string[] cells = new string[row.Cells.Count];
                        for (int i = 0; i < row.Cells.Count; i++)
                        {
                            cells[i] = row.Cells[i].Value?.ToString().Replace(",", ";") ?? "";
                        }
                        sb.AppendLine(string.Join(",", cells));
                    }

                    File.WriteAllText(saveDialog.FileName, sb.ToString(), Encoding.UTF8);
                    MessageBox.Show($"Report exported successfully!\n{saveDialog.FileName}", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error exporting to Excel: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Export report to PDF (HTML format that can be printed to PDF)
        /// </summary>
        private void btnExportPDF_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvReportDetails.Rows.Count == 0)
                {
                    MessageBox.Show("No data to export!", "Warning",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "HTML files (*.html)|*.html|All files (*.*)|*.*";
                saveDialog.FileName = $"Report_{cboReportType.Text}_{DateTime.Now:yyyyMMdd_HHmmss}.html";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    StringBuilder sb = new StringBuilder();

                    // HTML header
                    sb.AppendLine("<!DOCTYPE html>");
                    sb.AppendLine("<html><head>");
                    sb.AppendLine("<meta charset='UTF-8'>");
                    sb.AppendLine("<title>Report - Store X</title>");
                    sb.AppendLine("<style>");
                    sb.AppendLine("body { font-family: Arial, sans-serif; margin: 20px; }");
                    sb.AppendLine("h1 { color: #333; }");
                    sb.AppendLine(".info { margin: 10px 0; }");
                    sb.AppendLine(".stats { display: flex; gap: 20px; margin: 20px 0; }");
                    sb.AppendLine(".stat-card { border: 1px solid #ddd; padding: 15px; border-radius: 5px; text-align: center; }");
                    sb.AppendLine(".stat-title { font-size: 12px; color: #666; }");
                    sb.AppendLine(".stat-value { font-size: 18px; font-weight: bold; color: #333; }");
                    sb.AppendLine("table { border-collapse: collapse; width: 100%; margin-top: 20px; }");
                    sb.AppendLine("th, td { border: 1px solid #ddd; padding: 10px; text-align: left; }");
                    sb.AppendLine("th { background-color: #4CAF50; color: white; }");
                    sb.AppendLine("tr:nth-child(even) { background-color: #f2f2f2; }");
                    sb.AppendLine("</style></head><body>");

                    // Title and info
                    sb.AppendLine($"<h1>Report: {cboReportType.Text}</h1>");
                    sb.AppendLine($"<div class='info'>Date Range: {dtpFromDate.Value:dd/MM/yyyy} - {dtpToDate.Value:dd/MM/yyyy}</div>");
                    sb.AppendLine($"<div class='info'>Generated: {DateTime.Now:dd/MM/yyyy HH:mm:ss}</div>");

                    // Statistics cards
                    sb.AppendLine("<div class='stats'>");
                    sb.AppendLine($"<div class='stat-card'><div class='stat-title'>{lblTotalRecordsTitle.Text}</div><div class='stat-value'>{lblTotalRecordsValue.Text}</div></div>");
                    sb.AppendLine($"<div class='stat-card'><div class='stat-title'>{lblTotalValueTitle.Text}</div><div class='stat-value'>{lblTotalValueAmount.Text}</div></div>");
                    sb.AppendLine($"<div class='stat-card'><div class='stat-title'>{lblAverageTitle.Text}</div><div class='stat-value'>{lblAverageValue.Text}</div></div>");
                    sb.AppendLine("</div>");

                    // Table
                    sb.AppendLine("<table>");
                    sb.AppendLine("<tr>");
                    for (int i = 0; i < dgvReportDetails.Columns.Count; i++)
                    {
                        sb.AppendLine($"<th>{dgvReportDetails.Columns[i].HeaderText}</th>");
                    }
                    sb.AppendLine("</tr>");

                    foreach (DataGridViewRow row in dgvReportDetails.Rows)
                    {
                        sb.AppendLine("<tr>");
                        for (int i = 0; i < row.Cells.Count; i++)
                        {
                            sb.AppendLine($"<td>{row.Cells[i].Value?.ToString() ?? ""}</td>");
                        }
                        sb.AppendLine("</tr>");
                    }
                    sb.AppendLine("</table>");

                    // Footer
                    sb.AppendLine("<div style='margin-top: 30px; text-align: center; color: #666;'>");
                    sb.AppendLine("<p>Store X Sales Management System</p>");
                    sb.AppendLine("<p><em>To save as PDF: Open this file in browser and Print → Save as PDF</em></p>");
                    sb.AppendLine("</div>");
                    sb.AppendLine("</body></html>");

                    File.WriteAllText(saveDialog.FileName, sb.ToString(), Encoding.UTF8);
                    MessageBox.Show($"Report exported successfully!\n{saveDialog.FileName}\n\nTo convert to PDF: Open the HTML file in a browser and use Print → Save as PDF", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Open in default browser
                    System.Diagnostics.Process.Start(saveDialog.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error exporting to PDF: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Print report
        /// </summary>
        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvReportDetails.Rows.Count == 0)
                {
                    MessageBox.Show("No data to print!", "Warning",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Create temp HTML file and open for printing
                string tempFile = Path.Combine(Path.GetTempPath(), $"Report_{DateTime.Now:yyyyMMdd_HHmmss}.html");

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("<!DOCTYPE html><html><head><meta charset='UTF-8'><title>Print Report</title>");
                sb.AppendLine("<style>body{font-family:Arial;margin:20px}table{border-collapse:collapse;width:100%}th,td{border:1px solid #000;padding:8px}th{background:#4CAF50;color:white}</style>");
                sb.AppendLine("</head><body>");
                sb.AppendLine($"<h2>{cboReportType.Text} Report</h2>");
                sb.AppendLine($"<p>Date: {dtpFromDate.Value:dd/MM/yyyy} - {dtpToDate.Value:dd/MM/yyyy}</p>");
                sb.AppendLine("<table><tr>");
                
                for (int i = 0; i < dgvReportDetails.Columns.Count; i++)
                    sb.AppendLine($"<th>{dgvReportDetails.Columns[i].HeaderText}</th>");
                sb.AppendLine("</tr>");

                foreach (DataGridViewRow row in dgvReportDetails.Rows)
                {
                    sb.AppendLine("<tr>");
                    for (int i = 0; i < row.Cells.Count; i++)
                        sb.AppendLine($"<td>{row.Cells[i].Value?.ToString() ?? ""}</td>");
                    sb.AppendLine("</tr>");
                }
                
                sb.AppendLine("</table>");
                sb.AppendLine("<script>window.onload=function(){window.print();}</script>");
                sb.AppendLine("</body></html>");

                File.WriteAllText(tempFile, sb.ToString(), Encoding.UTF8);
                System.Diagnostics.Process.Start(tempFile);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error printing: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Helper to set grid headers dynamically
        /// </summary>
        private void SetGridHeaders(string col1, string col2, string col3, string col4)
        {
            if (dgvReportDetails.Columns.Count >= 4)
            {
                dgvReportDetails.Columns[0].HeaderText = col1;
                dgvReportDetails.Columns[1].HeaderText = col2;
                dgvReportDetails.Columns[2].HeaderText = col3;
                dgvReportDetails.Columns[3].HeaderText = col4;
            }
        }
    }
}
