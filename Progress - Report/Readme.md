
# Báo cáo tiến độ - Tuần 2

**Họ và tên:** Trần Thị Thu Tiền  
**MSSV:** DK24TTC2  
**Dự án:** Xây dựng website diễn đàn sức khỏe (ASP.NET)  
**Thời gian:** 20/10/2025 – 26/10/2025  

## 1. Công việc đã hoàn thành ✅
- Thiết kế giao diện trang chủ và trang đăng nhập.    
- Cài đặt môi trường phát triển (Visual Studio, .NET SDK, Docker).  
- Kết nối cơ sở dữ liệu SQL Server.  
- Viết tài liệu mô tả chức năng người dùng.
## 2. Kế hoạch tuần tiếp theo 🗓️
- Sử dụng các controls của ASP.NET.  
- Kết nối cơ sở dữ liệu SQL Server.  
- Quản lý trạng thái và các đối tượng của ASP.NET.
- Liên kết giữa menu và file sitemap
 ## 3.  Nội dung chính 🧩


<header class="navbar navbar-expand-lg navbar-light bg-light shadow-sm">
    <div class="container">
        <a class="navbar-brand fw-bold text-success" href="/">💚 Diễn đàn Sức khỏe</a>
        <div>
            <a href="/Account/Login" class="btn btn-outline-success me-2">Đăng nhập</a>
            <a href="/Account/Register" class="btn btn-success">Đăng ký</a>
        </div>
    </div>
</header>

<section class="banner text-center bg-success text-white py-5">
    <div class="container">
        <h1>Chào mừng đến với Diễn đàn Sức khỏe</h1>
        <p>Chia sẻ – Học hỏi – Cùng nhau khỏe mạnh hơn 💪</p>
    </div>
</section>

<section class="container my-5">
    <h2 class="text-center mb-4">🌿 Chuyên mục nổi bật</h2>
    <div class="row g-4">
        <div class="col-md-3">
            <div class="card h-100 shadow-sm">
                <img src="/images/nutrition.jpg" class="card-img-top" alt="Dinh dưỡng">
                <div class="card-body text-center">
                    <h5 class="card-title">Dinh dưỡng</h5>
                    <p class="card-text">Cập nhật kiến thức về chế độ ăn uống lành mạnh.</p>
                </div>
            </div>
        </div>
        <div class="col-md-3">
            <div class="card h-100 shadow-sm">
                <img src="/images/workout.jpg" class="card-img-top" alt="Tập luyện">
                <div class="card-body text-center">
                    <h5 class="card-title">Tập luyện</h5>
                    <p class="card-text">Chia sẻ bài tập và kinh nghiệm rèn luyện thể lực.</p>
                </div>
            </div>
        </div>
        <div class="col-md-3">
            <div class="card h-100 shadow-sm">
                <img src="/images/mental.jpg" class="card-img-top" alt="Sức khỏe tinh thần">
                <div class="card-body text-center">
                    <h5 class="card-title">Sức khỏe tinh thần</h5>
                    <p class="card-text">Giữ tinh thần lạc quan, cân bằng cuộc sống.</p>
                </div>
            </div>
        </div>
        <div class="col-md-3">
            <div class="card h-100 shadow-sm">
                <img src="/images/disease.jpg" class="card-img-top" alt="Bệnh thường gặp">
                <div class="card-body text-center">
                    <h5 class="card-title">Bệnh thường gặp</h5>
                    <p class="card-text">Tìm hiểu triệu chứng và cách phòng tránh bệnh.</p>
                </div>
            </div>
        </div>
    </div>
</section>

<footer class="bg-dark text-white text-center py-3 mt-5">

<div class="d-flex justify-content-center align-items-center vh-100 bg-light">
    <div class="card shadow-lg p-4" style="width: 400px;">
        <h3 class="text-center text-success mb-3">Đăng nhập</h3>
        <form asp-action="Login" method="post">
            <div class="mb-3">
                <label for="Username" class="form-label">Tên đăng nhập hoặc Email</label>
                <input type="text" class="form-control" id="Username" name="Username" required>
            </div>
            <div class="mb-3">
                <label for="Password" class="form-label">Mật khẩu</label>
                <input type="password" class="form-control" id="Password" name="Password" required>
            </div>
            <div class="form-check mb-3">
                <input class="form-check-input" type="checkbox" id="RememberMe" name="RememberMe">
                <label class="form-check-label" for="RememberMe">Ghi nhớ đăng nhập</label>
            </div>
            <button type="submit" class="btn btn-success w-100">Đăng nhập</button>
            <div class="text-center mt-3">
                <a href="/Account/ForgotPassword" class="text-decoration-none">Quên mật khẩu?</a><br>
                <a href="/Account/Register" class="text-decoration-none">Chưa có tài khoản? Đăng ký ngay</a>
            </div>
        </form>
    </div>
</div>

