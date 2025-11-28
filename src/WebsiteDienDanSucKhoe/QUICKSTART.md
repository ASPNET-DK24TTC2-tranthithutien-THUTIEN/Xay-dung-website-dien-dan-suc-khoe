# Hướng dẫn Sử dụng Nhanh

## 🚀 Khởi động Ứng dụng

1. Mở terminal/command prompt tại thư mục dự án
2. Chạy lệnh:
```bash
dotnet run
```
3. Mở trình duyệt và truy cập: `http://localhost:5292`

## 👤 Tài khoản Demo

### Tài khoản Admin
- **Email**: admin@healthforum.com
- **Mật khẩu**: Admin@123

### Tài khoản Người dùng
- **Email**: nguyenvana@example.com
- **Mật khẩu**: User@123

- **Email**: tranthib@example.com
- **Mật khẩu**: User@123

- **Email**: levanc@example.com
- **Mật khẩu**: User@123

- **Email**: phamthid@example.com
- **Mật khẩu**: User@123

- **Email**: hoangvane@example.com
- **Mật khẩu**: User@123

## 📝 Dữ liệu Demo

Ứng dụng đã được tạo sẵn với:
- ✅ 5 người dùng thường
- ✅ 1 tài khoản admin
- ✅ 10 chủ đề về các vấn đề sức khỏe
- ✅ 20+ phản hồi
- ✅ Likes cho bài viết và phản hồi
- ✅ 5 chuyên mục: Dinh dưỡng, Tập luyện, Hỏi đáp, Sức khỏe tinh thần, Bệnh lý

## 🎯 Các Tính năng Chính

### Người dùng thường:
1. **Đăng ký/Đăng nhập**: Tạo tài khoản mới hoặc đăng nhập
2. **Xem chủ đề**: Duyệt qua các chủ đề theo chuyên mục
3. **Tìm kiếm**: Tìm kiếm chủ đề theo từ khóa
4. **Tạo chủ đề**: Đăng câu hỏi hoặc chia sẻ kinh nghiệm
5. **Phản hồi**: Trả lời các chủ đề
6. **Thích**: Like bài viết và phản hồi
7. **Báo cáo**: Báo cáo nội dung vi phạm

### Admin/Moderator:
1. **Dashboard**: Xem thống kê tổng quan
2. **Quản lý người dùng**: Khóa/mở khóa tài khoản
3. **Quản lý nội dung**: Xóa chủ đề và phản hồi vi phạm
4. **Xử lý báo cáo**: Duyệt và xử lý các báo cáo từ người dùng

## 🎨 Giao diện

- **Trang chủ**: Hiển thị chuyên mục, chủ đề mới nhất và phổ biến
- **Danh sách chủ đề**: Xem tất cả chủ đề với tìm kiếm và lọc
- **Chi tiết chủ đề**: Xem nội dung đầy đủ và phản hồi
- **Tạo chủ đề**: Form tạo chủ đề mới
- **Admin Dashboard**: Bảng điều khiển quản trị

## 💡 Mẹo Sử dụng

1. **Đăng nhập với tài khoản admin** để trải nghiệm đầy đủ tính năng quản trị
2. **Tạo chủ đề mới** để thấy cách hệ thống hoạt động
3. **Thử tìm kiếm** với từ khóa như "dinh dưỡng", "tập luyện", "ngủ"
4. **Like và phản hồi** các bài viết để tăng tương tác
5. **Thử báo cáo** một bài viết để xem quy trình kiểm duyệt

## 🔧 Xử lý Sự cố

### Lỗi kết nối database
```bash
dotnet ef database drop
dotnet ef migrations remove
dotnet ef migrations add InitialCreate
dotnet run
```

### Xóa dữ liệu và tạo lại
1. Xóa file database trong thư mục dự án (nếu có)
2. Chạy lại `dotnet run` - database sẽ được tạo lại tự động

### Port đã được sử dụng
- Thay đổi port trong `Properties/launchSettings.json`
- Hoặc dừng ứng dụng đang chạy trên port 5292

## 📱 Responsive Design

Ứng dụng tương thích với:
- 💻 Desktop
- 📱 Mobile
- 📱 Tablet

## 🎓 Học tập

Dự án này phù hợp để:
- Học ASP.NET Core MVC
- Hiểu về Entity Framework Core
- Thực hành ASP.NET Identity
- Xây dựng ứng dụng web thực tế

## 📞 Hỗ trợ

Nếu gặp vấn đề, vui lòng:
1. Kiểm tra console/terminal có lỗi gì không
2. Đảm bảo đã cài đặt .NET 9.0 SDK
3. Kiểm tra SQL Server LocalDB đã được cài đặt

---

**Chúc bạn trải nghiệm vui vẻ! 🎉**
