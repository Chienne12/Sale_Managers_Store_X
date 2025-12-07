using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Store_X_s_Sales_Management_System.Forms.Admin.UserControls
{
    public partial class ucDashboardHome : UserControl
    {
        public ucDashboardHome()
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
                // Set default date range (last 7 days)
                dtpFromDate.Value = DateTime.Today.AddDays(-7);
                dtpToDate.Value = DateTime.Today;

                // Load initial data
                LoadStatistics();
                LoadCharts();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error initializing Dashboard: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Load general statistics (Cards)
        /// </summary>
        private void LoadStatistics()
        {
            try
            {
                // 1: Count total employees
                string queryCountEmployees = "SELECT COUNT(*) FROM Employees";
                object resultCountEmployees = DatabaseConnection.ExecuteScalar(queryCountEmployees, null);
                lblTotalEmployeesValue.Text = resultCountEmployees.ToString();

                // 2: Count total customers
                string queryCountCustomers = "SELECT COUNT(*) FROM Customers";
                object resultCountCustomers = DatabaseConnection.ExecuteScalar(queryCountCustomers, null);
                lblTotalCustomersValue.Text = resultCountCustomers.ToString();  // ✅ FIXED

                // 3: Calculate today's revenue
                string queryRevenueToday = @"SELECT ISNULL(SUM(TotalAmount), 0) FROM Orders 
                    WHERE CAST(OrderDate AS DATE) = CAST(GETDATE() AS DATE) 
                    AND OrderStatus='Completed'";
                object resultRevenueToday = DatabaseConnection.ExecuteScalar(queryRevenueToday, null);
                decimal revenueToday = Convert.ToDecimal(resultRevenueToday);
                lblRevenueTodayValue.Text = revenueToday.ToString("N0") + " VND";

                // 4: Count new orders (today)
                string queryCountNewOrders = @"SELECT COUNT(*) FROM Orders 
                    WHERE CAST(OrderDate AS DATE) = CAST(GETDATE() AS DATE)";
                object resultCountNewOrders = DatabaseConnection.ExecuteScalar(queryCountNewOrders, null);
                lblNewOrdersValue.Text = resultCountNewOrders.ToString();  // ✅ FIXED

                // 5: Count low stock products (Stock < 10)
                string queryCountLowStock = "SELECT COUNT(*) FROM Products WHERE StockQuantity < 10";
                object resultCountLowStock = DatabaseConnection.ExecuteScalar(queryCountLowStock, null);
                lblLowStockValue.Text = resultCountLowStock.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading statistics: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Load data for charts (use values from DateTimePicker)
        /// </summary>
        private void LoadCharts()
        {
            try
            {
                DateTime fromDate = dtpFromDate.Value.Date;
                DateTime toDate = dtpToDate.Value.Date;

                LoadSalesByEmployeeChart(fromDate, toDate);
                LoadSalesByCustomerChart(fromDate, toDate);
                LoadRevenueOverTimeChart(fromDate, toDate);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading charts: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Sales by Employee Chart (Bar Chart) - WITH DATE PARAMETERS
        /// </summary>
        private void LoadSalesByEmployeeChart(DateTime fromDate, DateTime toDate)
        {
            try
            {
                string query = @"SELECT TOP 10 
                    e.EmployeeName AS EmployeeName,
                    ISNULL(SUM(o.TotalAmount), 0) AS TotalSales
                FROM Employees e
                LEFT JOIN Orders o ON e.EmployeeId = o.EmployeeId
                    AND o.OrderStatus = 'Completed'
                    AND CAST(o.OrderDate AS DATE) >= @FromDate
                    AND CAST(o.OrderDate AS DATE) <= @ToDate
                GROUP BY e.EmployeeName
                ORDER BY TotalSales DESC";

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@FromDate", fromDate),
                    new SqlParameter("@ToDate", toDate)
                };

                DataTable dataTable = DatabaseConnection.ExecuteQuery(query, parameters);

                chartSalesByEmployee.Series["Sales"].Points.Clear();
                foreach (DataRow row in dataTable.Rows)
                {
                    chartSalesByEmployee.Series["Sales"].Points.AddXY(
                        row["EmployeeName"].ToString(),
                        Convert.ToDouble(row["TotalSales"])
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading employee chart: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Sales by Customer Chart (Pie Chart) - WITH DATE PARAMETERS
        /// </summary>
        private void LoadSalesByCustomerChart(DateTime fromDate, DateTime toDate)
        {
            try
            {
                string query = @"SELECT TOP 5 
                    c.CustomerName AS CustomerName,
                    ISNULL(SUM(o.TotalAmount), 0) AS TotalSpent
                FROM Customers c
                INNER JOIN Orders o ON c.CustomerId = o.CustomerId
                    AND o.OrderStatus = 'Completed'
                    AND CAST(o.OrderDate AS DATE) >= @FromDate
                    AND CAST(o.OrderDate AS DATE) <= @ToDate
                GROUP BY c.CustomerName
                ORDER BY TotalSpent DESC";

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@FromDate", fromDate),
                    new SqlParameter("@ToDate", toDate)
                };

                DataTable dataTable = DatabaseConnection.ExecuteQuery(query, parameters);

                chartSalesByCustomer.Series["Sales"].Points.Clear();
                foreach (DataRow row in dataTable.Rows)
                {
                    chartSalesByCustomer.Series["Sales"].Points.AddXY(
                        row["CustomerName"].ToString(),
                        Convert.ToDouble(row["TotalSpent"])
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading customer chart: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Revenue Over Time Chart (Line Chart) - WITH DATE PARAMETERS
        /// </summary>
        private void LoadRevenueOverTimeChart(DateTime fromDate, DateTime toDate)
        {
            try
            {
                string query = @"SELECT 
                    CAST(OrderDate AS DATE) AS OrderDate,
                    ISNULL(SUM(TotalAmount), 0) AS Revenue
                FROM Orders
                WHERE CAST(OrderDate AS DATE) >= @FromDate
                    AND CAST(OrderDate AS DATE) <= @ToDate
                    AND OrderStatus = 'Completed'
                GROUP BY CAST(OrderDate AS DATE)
                ORDER BY OrderDate";

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@FromDate", fromDate),
                    new SqlParameter("@ToDate", toDate)
                };

                DataTable dataTable = DatabaseConnection.ExecuteQuery(query, parameters);

                chartRevenueOverTime.Series["Revenue"].Points.Clear();
                foreach (DataRow row in dataTable.Rows)
                {
                    chartRevenueOverTime.Series["Revenue"].Points.AddXY(
                        Convert.ToDateTime(row["OrderDate"]).ToString("dd/MM"),
                        Convert.ToDouble(row["Revenue"])
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading revenue chart: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Handle Apply Date Range button click
        /// </summary>
        private void btnApplyDateRange_Click(object sender, EventArgs e)
        {
            // Validate: start date <= end date
            if (dtpFromDate.Value > dtpToDate.Value)
            {
                MessageBox.Show("Start date must be before or equal to end date!",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Reload charts with new date range
            LoadCharts();
        }

        /// <summary>
        /// Refresh all data
        /// </summary>
        public void RefreshData()
        {
            LoadStatistics();
            LoadCharts();
        }
    }
}