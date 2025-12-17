# Store X's Sales Management System - User Guide

## 1. Login
- Enter **Username** and **Password**, then choose a **Role** (Admin, SalePerson, Warehouse).
- Press **Enter** or click **Login**. If credentials are wrong, the form will show an error and stay on the login screen.

## 2. Admin Role
- **Dashboard**
  1) Open the Dashboard tab (default).  
  2) Set the **From/To** date range if needed.  
  3) View cards: Employees, Customers, Today Revenue, New Orders, Low Stock.  
  4) Charts refresh automatically based on the selected range.
- **Manage Employees**
  1) Select a row to edit/delete. To add a new employee, make sure no row is selected.  
  2) Enter **Full name**, **Username**, choose **Role** (Admin/SalePerson/Warehouse), **Authority Level**, and **Password**.  
  3) Click **Add** to create, **Edit** to update, **Delete** to mark resigned, **Reactivate** to restore.  
  4) Use the **Role filter** to quickly filter by role.  
  5) After each action, the grid reloads.
- **Manage Customers**
  1) Search by keyword; use status filters if available.  
  2) Select a row to edit or click **Add** to create a new customer.  
  3) Fill customer details and save.  
  4) For locked customers, select and click **Reactivate** to reopen.
- **Manage Products**
  1) Filter by keyword, **Category**, **Supplier**, or click **Low Stock** to see items running low.  
  2) Select a product to edit/delete or click **Add** to create.  
  3) In **Categories** and **Suppliers** tabs, select a row then **Add/Update/Delete** as needed.  
  4) Save/Update to apply changes; the grid refreshes.
- **Manage Orders**
  1) Choose **Status** (All/Pending/Completed/Cancelled), **Employee**, date, or enter **Search Order ID** to filter.  
  2) Select an order to view details; line items appear in the right panel.  
  3) Click **Add** to create, **Edit** to modify, **Delete** to cancel, **Print** to print the invoice.  
  4) The order list refreshes after actions.
- **Reports**
  1) Open the Reports tab.  
  2) Choose time range/filters if available.  
  3) View summary charts/reports.
- **Logout**
  1) Click **Logout** to return to the login screen.

## 3. SalePerson Role
- The home screen shows a welcome message, today’s sales, and today’s rank.
- **Find Products**
  1) Type a keyword in search; optionally choose **Category** or enable **In stock only**.  
  2) Click **Add to cart** on products (quantity capped by stock).  
  3) The list filters automatically according to your criteria.
- **Cart Management**
  1) View the cart in the right panel.  
  2) Double-click a line to reduce its quantity by 1; select a line and click **Remove Item** to delete; click **Cancel** to clear the cart.  
  3) Total is shown as **TOTAL**.
- **Customer Selection**
  1) Choose **Existing** to pick a customer from the dropdown.  
  2) Choose **New Customer** and enter **Name**, **Phone** (required), and **Address** (optional).  
  3) If the phone number already exists, the system reuses that customer instead of creating a new one; to create a different customer, use a phone number that does not exist.
- **Checkout**
  1) Choose **Payment method**.  
  2) Click **Check** to create the order (saves Order + OrderDetails, deducts stock).  
  3) After success, the cart is cleared; click **Print** to print the receipt if needed.

## 4. Warehouse Role
- **Dashboard**
  1) Open Dashboard to see total items, low-stock count (less than 10 units), and total inventory value.  
  2) Low-stock count appears in red when present.
- **Replenishment**
  1) In the low-stock table, select a row to import.  
  2) Click **Import Stock**, enter quantity, confirm.  
  3) Stock increases and stats refresh.
- **Stock Movements**
  1) View **Recent Stock Movements (From Sales)** to track recent exports from completed sales.  
  2) Data reloads automatically when opened.
- **Manage Products**
  1) Same usage as Admin: filter, add/edit/delete products; manage categories/suppliers in their tabs.  
  2) Save/Update to apply changes.
- **Change Password**
  1) Click the change-password button in the menu.  
  2) Enter current password, new password, confirm new password.  
  3) Save to update; close the dialog when done.

## 5. Notes
- Role names must match login options: **Admin**, **SalePerson**, **Warehouse**.
- The application needs a database with existing employees, customers, and products to operate fully.
