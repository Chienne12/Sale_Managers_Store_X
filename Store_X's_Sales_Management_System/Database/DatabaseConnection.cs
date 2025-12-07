using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Store_X_s_Sales_Management_System
{
    /// <summary>
    /// Database connection management class
    /// Shared across the entire application
    /// </summary>
    public static class DatabaseConnection
    {
        
        public static string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["Mydatabase"].ConnectionString;
            }
        }

        /// 
        /// Create New SqlConnection 
        /// <returns>SqlConnection opened</returns>
        public static SqlConnection GetConnection()
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            conn.Open();
            Console.WriteLine("Database OK.");
            return conn;
        }

        //Test Connection
        public static bool TestConnection()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    Console.WriteLine("Check Database OK.");
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Check Database Faild {ex}.");
                return false;
            }
        }

        /// <summary>
        /// Execute SQL command without returning data (INSERT, UPDATE, DELETE)
        /// </summary>
        /// <param name="query">SQL Query</param>
        /// <param name="parameters">(optional)</param>
        /// <returns>Number of rows affected</returns>
        public static int ExecuteNonQuery(string query, SqlParameter[] parameters = null)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }

                    conn.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Execute SQL command returning a single value (COUNT, SUM, MAX, ...)
        /// </summary>
        /// <param name="query"> SQL</param>
        /// <param name="parameters"> (optional)</param>
        /// <returns></returns>
        public static object ExecuteScalar(string query, SqlParameter[] parameters = null)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }

                    conn.Open();
                    return cmd.ExecuteScalar();
                }
            }
        }

        /// <summary>
        /// Execute SQL command returning a DataTable
        /// </summary>
        /// <param name="query">SQL Query</param>
        /// <param name="parameters">(optional)</param>
        /// <returns>Returned DataTable</returns>
        public static DataTable ExecuteQuery(string query, SqlParameter[] parameters = null)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    return dataTable;
                }
            }
        }
    }
}
