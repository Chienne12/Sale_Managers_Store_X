# Hướng dẫn sử dụng Store X's Sales Management System

## 1. Đăng nhập
- Nhập **Username**, **Password**, chọn **Role** (Admin, SalePerson, Warehouse) trong danh sách thả xuống.
- Nhấn **Enter** hoặc nút **Login** để vào hệ thống. Thông tin sai sẽ được báo lỗi và yêu cầu nhập lại.

## 2. Quyền Admin
- **Dashboard**: Xem nhanh tổng nhân viên, khách hàng, doanh thu hôm nay, đơn mới và số mặt hàng sắp hết. Chọn khoảng ngày (From/To) để làm mới biểu đồ doanh thu theo nhân viên, khách hàng và theo thời gian.
- **Manage Employees**: Thêm/sửa nhân viên với họ tên, username, vai trò (Admin/SalePerson/Warehouse), cấp độ quyền và mật khẩu; lọc theo vai trò; đánh dấu nghỉ việc/khôi phục nhân viên; cập nhật lại mật khẩu khi chỉnh sửa.
- **Manage Customers**: Thêm khách hàng mới, chỉnh sửa thông tin, tìm kiếm, lọc trạng thái (đang hoạt động/đã khóa), kích hoạt lại khách bị khóa.
- **Manage Products**: Tìm kiếm theo từ khóa, danh mục, nhà cung cấp; thêm/sửa/xóa sản phẩm; xem nhanh hàng sắp hết bằng nút **Low Stock**; quản lý danh mục và nhà cung cấp ở các tab riêng.
- **Manage Orders**: Lọc đơn theo trạng thái (Pending/Completed/Cancelled), nhân viên, ngày; tìm kiếm theo mã đơn hoặc tên khách; xem chi tiết & dòng sản phẩm, in hóa đơn, thêm/chỉnh sửa/hủy đơn.
- **Reports**: Xem báo cáo doanh thu/bán hàng tổng hợp (theo thiết kế của trang Reports).
- **Logout**: Thoát về màn hình đăng nhập.

## 3. Quyền Sale (SalePerson)
- Màn hình chính hiển thị chào mừng kèm doanh số hôm nay và thứ hạng theo ngày.
- **Tìm sản phẩm**: Gõ từ khóa, lọc theo danh mục, hoặc bật **In stock only** để chỉ xem hàng còn tồn. Mỗi sản phẩm cho phép **Add to cart** (tự động cộng dồn số lượng tối đa bằng tồn kho).
- **Quản lý giỏ hàng**: Danh sách giỏ ở panel bên phải; nhấn **Remove Item** hoặc double-click để giảm/bỏ từng dòng; **Cancel** để xóa toàn bộ giỏ.
- **Chọn khách hàng**: Chế độ **Existing** để chọn khách đã có từ danh sách; **New Customer** để nhập tên, điện thoại, địa chỉ (bắt buộc tên & điện thoại).
- **Thanh toán**: Chọn **Payment method**, nhấn **Check** để tạo đơn hoàn tất (lưu Order, OrderDetails và trừ tồn kho); nhấn **Print** để in hóa đơn; giỏ sẽ tự làm mới sau khi tạo đơn thành công.

## 4. Quyền Warehouse
- **Dashboard**: Xem tổng số mặt hàng, số lượng hàng sắp hết (<10), tổng giá trị tồn kho.
- **Replenishment**: Bảng hàng sắp hết kèm nút **Import Stock**; nhập số lượng cần bổ sung để cộng tồn và cập nhật thống kê.
- **Stock Movements**: Bảng **Recent Stock Movements (From Sales)** hiển thị các lượt xuất kho gần nhất dựa trên đơn bán hoàn tất.
- **Manage Products**: Tương tự Admin để cập nhật sản phẩm, danh mục, nhà cung cấp.
- **Change Password**: Nút 🔐 trong menu cho phép đổi mật khẩu tài khoản kho.

## 5. Lưu ý
- Tên role cần khớp với danh sách đăng nhập: **Admin**, **SalePerson**, **Warehouse**.
- Ứng dụng cần kết nối cơ sở dữ liệu đã có sẵn dữ liệu nhân viên, khách hàng, sản phẩm để hoạt động đầy đủ.
