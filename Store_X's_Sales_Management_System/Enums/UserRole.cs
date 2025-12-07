namespace Store_X_s_Sales_Management_System.Enums
{
    /// <summary>
    /// Defines user roles in the system for permission management
    /// </summary>
    public enum UserRole
    {
        /// <summary>
        /// Administrator - Full access to all features
        /// </summary>
        Admin,

        /// <summary>
        /// Sales staff - Limited access, mainly for creating orders and viewing products
        /// </summary>
        Sales,

        /// <summary>
        /// Warehouse staff - Access to inventory management
        /// </summary>
        Warehouse
    }
}
