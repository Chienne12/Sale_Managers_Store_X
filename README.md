# Hướng dẫn sử dụng Store X's Sales Management System

## 1. Đăng nhập
- Nhập **Username**, **Password**, chọn **Role** (Admin, SalePerson, Warehouse) trong danh sách thả xuống.
- Nhấn **Enter** hoặc nút **Login** để vào hệ thống. Thông tin sai sẽ được báo lỗi và yêu cầu nhập lại.

## 2. Quyền Admin
- **Dashboard**
  1) Mở tab Dashboard (mặc định).  
  2) Chọn khoảng ngày **From/To** nếu cần lọc.  
  3) Xem các thẻ thống kê (Nhân viên, Khách hàng, Doanh thu hôm nay, Đơn mới, Low stock).  
  4) Biểu đồ tự làm mới theo khoảng ngày đã chọn.
- **Manage Employees**
  1) Chọn nhân viên trong bảng (nếu sửa/xóa). Để thêm nhân viên mới, **đảm bảo không có dòng nào được chọn trong bảng**.  
  2) Nhập **Họ tên**, **Username**, chọn **Role** (Admin/SalePerson/Warehouse), **Authority Level** và **Password**.  
  3) Nhấn **Add** để thêm mới, **Edit** để cập nhật, **Delete** để đánh dấu nghỉ, **Reactivate** để khôi phục.  
  4) Dùng **Role filter** để lọc nhanh theo vai trò.  
  5) Sau thao tác, dữ liệu sẽ tải lại vào bảng.
- **Manage Customers**
  1) Nhập/tìm kiếm theo từ khóa; dùng bộ lọc trạng thái nếu có.  
  2) Chọn dòng để sửa hoặc nhấn **Add** để thêm khách mới.  
  3) Điền thông tin khách và lưu.  
  4) Với khách bị khóa, chọn và nhấn **Reactivate** để mở lại.
- **Manage Products**
  1) Chọn bộ lọc: từ khóa, **Category**, **Supplier**, hoặc nhấn **Low Stock** để xem hàng sắp hết.  
  2) Chọn sản phẩm để sửa/xóa hoặc nhấn **Add** để thêm mới.  
  3) Trong tab **Categories** và **Suppliers**, chọn dòng rồi **Add/Update/Delete** tương ứng.  
  4) Nhấn **Save/Update** để áp dụng; bảng sẽ làm mới.
- **Manage Orders**
  1) Chọn **Status** (All/Pending/Completed/Cancelled), **Employee**, ngày, hoặc nhập **Search Order ID** để lọc.  
  2) Chọn đơn trong bảng để xem chi tiết; chi tiết hiển thị ở panel bên phải.  
  3) Nhấn **Add** để tạo đơn mới, **Edit** để chỉnh sửa, **Delete** để hủy, **Print** để in hóa đơn.  
  4) Thao tác xong, danh sách đơn tự làm mới.
- **Reports**
  1) Mở tab Reports.  
  2) Chọn khoảng thời gian/bộ lọc (nếu có).  
  3) Xem các biểu đồ/báo cáo tổng hợp.
- **Logout**
  1) Nhấn **Logout** để quay về màn hình đăng nhập.

## 3. Quyền Sale (SalePerson)
- Màn hình chính hiển thị chào mừng kèm doanh số hôm nay và thứ hạng theo ngày.
- **Tìm sản phẩm**
  1) Gõ từ khóa vào ô tìm kiếm; có thể chọn **Category** hoặc bật **In stock only**.  
  2) Nhấn **Add to cart** tại từng sản phẩm (tự giới hạn theo tồn kho).  
  3) Danh sách sản phẩm tự lọc theo tiêu chí đã chọn.
- **Quản lý giỏ hàng**
  1) Xem giỏ ở panel phải.  
  2) Double-click 1 dòng để giảm số lượng; chọn dòng và nhấn **Remove Item** để xóa; nhấn **Cancel** để xóa toàn bộ giỏ.  
  3) Tổng tiền hiển thị dưới dạng **TOTAL**.
- **Chọn khách hàng**
  1) Chọn **Existing** để lấy khách từ danh sách có sẵn; chọn khách trong combo.  
  2) Chọn **New Customer** để nhập **Name**, **Phone** (bắt buộc) và **Address** (tùy chọn).  
  3) ⚠️ Nếu số điện thoại đã tồn tại, hệ thống sẽ **tự động dùng lại khách đã có** thay vì tạo mới; muốn tạo khách khác, hãy nhập số điện thoại chưa tồn tại.
- **Thanh toán**
  1) Chọn **Payment method**.  
  2) Nhấn **Check** để tạo đơn (lưu Order + OrderDetails, trừ tồn kho).  
  3) Sau thành công, giỏ được làm mới; nhấn **Print** để in hóa đơn nếu cần.

## 4. Quyền Warehouse
- **Dashboard**
  1) Mở Dashboard để xem tổng số mặt hàng, số lượng hàng sắp hết (<10), tổng giá trị tồn kho.  
  2) Màu cảnh báo đỏ cho hàng sắp hết.
- **Replenishment**
  1) Trong bảng hàng sắp hết, chọn dòng cần nhập.  
  2) Nhấn **Import Stock**, nhập số lượng, xác nhận.  
  3) Hệ thống cộng tồn và cập nhật lại thống kê.
- **Stock Movements**
  1) Xem bảng **Recent Stock Movements (From Sales)** để theo dõi các lần xuất kho gần nhất (từ đơn bán hoàn tất).  
  2) Không cần thao tác lưu; bảng tự tải dữ liệu mới khi mở.
- **Manage Products**
  1) Sử dụng tương tự phần Admin: lọc, thêm/sửa/xóa sản phẩm; quản lý danh mục/nhà cung cấp tại các tab riêng.  
  2) Nhấn lưu/cập nhật để áp dụng thay đổi.
- **Change Password**
  1) Nhấn nút 🔐 trong menu.  
  2) Nhập mật khẩu hiện tại, mật khẩu mới, xác nhận mật khẩu mới.  
  3) Lưu để cập nhật; đóng hộp thoại khi hoàn tất.

## 5. Lưu ý
- Tên role cần khớp với danh sách đăng nhập: **Admin**, **SalePerson**, **Warehouse**.
- Ứng dụng cần kết nối cơ sở dữ liệu đã có sẵn dữ liệu nhân viên, khách hàng, sản phẩm để hoạt động đầy đủ.
