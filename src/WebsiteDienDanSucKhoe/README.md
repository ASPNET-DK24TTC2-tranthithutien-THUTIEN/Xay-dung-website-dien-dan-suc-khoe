# 🏥 Diễn đàn Sức khỏe - Health Forum MVC

[![.NET](https://img.shields.io/badge/.NET-9.0-512BD4?logo=dotnet)](https://dotnet.microsoft.com/)
[![ASP.NET Core](https://img.shields.io/badge/ASP.NET%20Core-9.0-512BD4)](https://docs.microsoft.com/aspnet/core)
[![License](https://img.shields.io/badge/License-MIT-green.svg)](LICENSE)

Ứng dụng diễn đàn sức khỏe chuyên nghiệp được xây dựng bằng **ASP.NET Core MVC** với thiết kế hiện đại, giao diện đẹp mắt và đầy đủ tính năng MVP.

![Health Forum](https://img.shields.io/badge/Status-Production%20Ready-success)

---

## 📋 Mục lục

- [Tổng quan](#-tổng-quan)
- [Tính năng](#-tính-năng)
- [Công nghệ](#️-công-nghệ-sử-dụng)
- [Use Cases](#-use-cases)
- [Kiến trúc](#️-kiến-trúc-hệ-thống)
- [Cài đặt](#-cài-đặt-và-chạy)
- [Sử dụng](#-hướng-dẫn-sử-dụng)
- [Database](#-database-schema)
- [Bảo mật](#-bảo-mật)
- [Screenshots](#-screenshots)
- [Roadmap](#-roadmap)

---

## 🎯 Tổng quan

**Diễn đàn Sức khỏe** là một nền tảng cộng đồng trực tuyến nơi người dùng có thể:
- 💬 Chia sẻ kiến thức và kinh nghiệm về sức khỏe
- 🤝 Hỗ trợ lẫn nhau trong hành trình chăm sóc sức khỏe
- 📚 Học hỏi từ cộng đồng về dinh dưỡng, tập luyện, sức khỏe tinh thần
- 🔍 Tìm kiếm thông tin và giải đáp thắc mắc
- 👥 Kết nối với những người có cùng mục tiêu sức khỏe

### 🎨 Đặc điểm nổi bật:
- ✨ **Giao diện hiện đại** với gradient backgrounds và animations mượt mà
- 📱 **Responsive design** hoạt động hoàn hảo trên mọi thiết bị
- 🚀 **Performance cao** với Entity Framework Core optimization
- 🔒 **Bảo mật tốt** với ASP.NET Identity và role-based authorization
- 🎨 **UX/UI premium** với micro-interactions và glassmorphism effects

---

## 🌟 Tính năng

### 1️⃣ Hệ thống Tài khoản

| Chức năng | Mô tả | Trạng thái |
|-----------|-------|------------|
| **Đăng ký** | Tạo tài khoản với email & mật khẩu | ✅ |
| **Đăng nhập** | Xác thực người dùng với remember me | ✅ |
| **Quên mật khẩu** | Reset mật khẩu qua email | ✅ |
| **Hồ sơ cá nhân** | Xem thông tin tài khoản, ngày tham gia | ✅ |
| **Avatar** | Hiển thị ảnh đại diện (chữ cái đầu) | ✅ |

### 2️⃣ Quản lý Nội dung

| Chức năng | Mô tả | Trạng thái |
|-----------|-------|------------|
| **Tạo chủ đề** | Đăng câu hỏi/bài viết mới | ✅ |
| **Phân loại** | 5 chuyên mục: Dinh dưỡng, Tập luyện, Hỏi đáp, Sức khỏe tinh thần, Bệnh lý | ✅ |
| **Phản hồi** | Bình luận và trả lời chủ đề | ✅ |
| **Rich content** | Hỗ trợ ngắt dòng và format cơ bản | ✅ |
| **View tracking** | Đếm lượt xem tự động | ✅ |

### 3️⃣ Tương tác Xã hội

| Chức năng | Mô tả | Trạng thái |
|-----------|-------|------------|
| **Like bài viết** | Thích/bỏ thích chủ đề | ✅ |
| **Like phản hồi** | Thích/bỏ thích bình luận | ✅ |
| **Tìm kiếm** | Tìm trong tiêu đề và nội dung | ✅ |
| **Lọc chuyên mục** | Xem chủ đề theo category | ✅ |
| **Thông báo** | Nhận thông báo khi có phản hồi mới | ✅ |
| **Báo cáo** | Report nội dung vi phạm | ✅ |

### 4️⃣ Quản trị Hệ thống

| Chức năng | Mô tả | Vai trò |
|-----------|-------|---------|
| **Dashboard** | Thống kê tổng quan hệ thống | Admin, Moderator |
| **Quản lý người dùng** | Khóa/mở khóa tài khoản | Admin |
| **Quản lý chủ đề** | Xóa nội dung vi phạm | Admin, Moderator |
| **Xử lý báo cáo** | Duyệt và giải quyết reports | Admin, Moderator |
| **Kiểm duyệt** | Xóa phản hồi không phù hợp | Admin, Moderator |

---

## 🛠️ Công nghệ Sử dụng

### Backend
- **Framework**: ASP.NET Core 9.0 MVC
- **Language**: C# 12
- **Database**: SQL Server LocalDB
- **ORM**: Entity Framework Core 9.0
- **Authentication**: ASP.NET Core Identity
- **Pattern**: MVC (Model-View-Controller)

### Frontend
- **UI Framework**: Bootstrap 5.3
- **Icons**: Bootstrap Icons
- **Fonts**: Google Fonts (Inter)
- **JavaScript**: jQuery 3.x
- **CSS**: Custom modern design với CSS3

### Development Tools
- **IDE**: Visual Studio 2022 / VS Code
- **Version Control**: Git
- **Package Manager**: NuGet

### Dependencies
```xml
<PackageReference Include="Microsoft.EntityFrameworkCore.SqlServer" Version="9.0.0" />
<PackageReference Include="Microsoft.EntityFrameworkCore.Tools" Version="10.0.0" />
<PackageReference Include="Microsoft.AspNetCore.Identity.EntityFrameworkCore" Version="9.0.0" />
<PackageReference Include="Microsoft.EntityFrameworkCore.Design" Version="9.0.0" />
```

---

## 💼 Use Cases

### 👤 Người dùng thường (User)

#### UC1: Tìm kiếm thông tin sức khỏe
```
Actor: Người dùng chưa đăng ký
Flow:
1. Truy cập trang chủ
2. Xem các chủ đề phổ biến
3. Sử dụng tìm kiếm để tìm thông tin
4. Đọc chủ đề và phản hồi
5. Đăng ký nếu muốn tham gia thảo luận
```

#### UC2: Đặt câu hỏi về sức khỏe
```
Actor: Người dùng đã đăng nhập
Flow:
1. Đăng nhập vào hệ thống
2. Click "Tạo chủ đề mới"
3. Chọn chuyên mục phù hợp
4. Nhập tiêu đề và nội dung câu hỏi
5. Đăng bài và chờ phản hồi
6. Nhận thông báo khi có người trả lời
```

#### UC3: Chia sẻ kinh nghiệm
```
Actor: Người dùng có kinh nghiệm
Flow:
1. Tìm chủ đề liên quan
2. Đọc câu hỏi của người khác
3. Viết phản hồi chia sẻ kinh nghiệm
4. Nhận likes từ cộng đồng
5. Tiếp tục thảo luận trong thread
```

### 👨‍💼 Quản trị viên (Admin)

#### UC4: Kiểm duyệt nội dung
```
Actor: Admin/Moderator
Flow:
1. Đăng nhập với tài khoản admin
2. Xem dashboard thống kê
3. Kiểm tra báo cáo từ người dùng
4. Xem xét nội dung bị báo cáo
5. Quyết định xóa hoặc giữ lại
6. Cập nhật trạng thái báo cáo
```

#### UC5: Quản lý người dùng vi phạm
```
Actor: Admin
Flow:
1. Nhận báo cáo về người dùng vi phạm
2. Xem lịch sử hoạt động của người dùng
3. Đánh giá mức độ vi phạm
4. Khóa tài khoản nếu cần thiết
5. Ghi chú lý do khóa
```

---

## 🏗️ Kiến trúc Hệ thống

### Architecture Pattern: MVC (Model-View-Controller)

```
┌─────────────────────────────────────────────────────────┐
│                      Presentation Layer                  │
│  ┌──────────┐  ┌──────────┐  ┌──────────┐  ┌─────────┐ │
│  │  Views   │  │ Layouts  │  │ Partials │  │  wwwroot│ │
│  │ (.cshtml)│  │          │  │          │  │ (static)│ │
│  └──────────┘  └──────────┘  └──────────┘  └─────────┘ │
└─────────────────────────────────────────────────────────┘
                          ↕
┌─────────────────────────────────────────────────────────┐
│                     Business Logic Layer                 │
│  ┌──────────────────────────────────────────────────┐   │
│  │              Controllers                          │   │
│  │  - AccountController                             │   │
│  │  - TopicsController                              │   │
│  │  - RepliesController                             │   │
│  │  - AdminController                               │   │
│  │  - ReportsController                             │   │
│  └──────────────────────────────────────────────────┘   │
└─────────────────────────────────────────────────────────┘
                          ↕
┌─────────────────────────────────────────────────────────┐
│                      Data Access Layer                   │
│  ┌──────────────────────────────────────────────────┐   │
│  │         Entity Framework Core (ORM)              │   │
│  │  - ApplicationDbContext                          │   │
│  │  - Migrations                                    │   │
│  │  - LINQ Queries                                  │   │
│  └──────────────────────────────────────────────────┘   │
└─────────────────────────────────────────────────────────┘
                          ↕
┌─────────────────────────────────────────────────────────┐
│                      Database Layer                      │
│  ┌──────────────────────────────────────────────────┐   │
│  │         SQL Server LocalDB                       │   │
│  │  - AspNetUsers, AspNetRoles                      │   │
│  │  - Topics, Replies, Categories                   │   │
│  │  - Likes, Reports, Notifications                 │   │
│  └──────────────────────────────────────────────────┘   │
└─────────────────────────────────────────────────────────┘
```

### Data Flow

```
User Request → Routing → Controller → Model/DbContext → Database
                  ↓                          ↑
                View ← ViewModel ← Controller
```

### Security Layers

```
┌─────────────────────────────────────┐
│  Authentication (ASP.NET Identity)  │
├─────────────────────────────────────┤
│  Authorization (Role-based)         │
├─────────────────────────────────────┤
│  CSRF Protection                    │
├─────────────────────────────────────┤
│  SQL Injection Prevention (EF Core) │
├─────────────────────────────────────┤
│  XSS Protection (Razor)             │
└─────────────────────────────────────┘
```

---

## 🚀 Cài đặt và Chạy

### Yêu cầu hệ thống
- ✅ .NET 9.0 SDK ([Download](https://dotnet.microsoft.com/download))
- ✅ SQL Server LocalDB (đi kèm Visual Studio)
- ✅ Trình duyệt web hiện đại (Chrome, Firefox, Edge)

### Bước 1: Clone repository
```bash
git clone <repository-url>
cd WebsiteDienDanSucKhoe
```

### Bước 2: Restore packages
```bash
dotnet restore
```

### Bước 3: Chạy ứng dụng
```bash
dotnet run
```

Ứng dụng sẽ chạy tại: **http://localhost:5292**

### Bước 4: Truy cập và đăng nhập

**Tài khoản Admin:**
- Email: `admin@healthforum.com`
- Password: `Admin@123`

**Tài khoản User mẫu:**
- Email: `nguyenvana@example.com`
- Password: `User@123`

---

## 📖 Hướng dẫn Sử dụng

### Cho người dùng mới

1. **Đăng ký tài khoản**
   - Click "Đăng ký" trên thanh navigation
   - Điền email, tên hiển thị và mật khẩu
   - Click "Đăng ký" để tạo tài khoản

2. **Tạo chủ đề mới**
   - Đăng nhập vào hệ thống
   - Click "Tạo bài viết" hoặc "Tạo chủ đề mới"
   - Chọn chuyên mục phù hợp
   - Nhập tiêu đề và nội dung
   - Click "Đăng chủ đề"

3. **Tương tác với bài viết**
   - Click vào tiêu đề để xem chi tiết
   - Click ❤️ để thích bài viết
   - Viết phản hồi ở cuối trang
   - Click 🚩 để báo cáo nội dung vi phạm

### Cho quản trị viên

1. **Truy cập Dashboard**
   - Đăng nhập với tài khoản admin
   - Click "Quản trị" trên menu
   - Xem thống kê tổng quan

2. **Xử lý báo cáo**
   - Vào "Quản lý báo cáo"
   - Xem chi tiết nội dung bị báo cáo
   - Click ✅ để giải quyết hoặc ❌ để bỏ qua

3. **Quản lý người dùng**
   - Vào "Quản lý người dùng"
   - Tìm kiếm người dùng
   - Click 🔒 để khóa tài khoản vi phạm

---

## 💾 Database Schema

### Entity Relationship Diagram

```
┌─────────────────┐
│  AspNetUsers    │
│  (Identity)     │
├─────────────────┤
│ Id (PK)         │
│ Email           │
│ DisplayName     │
│ JoinedDate      │
│ IsBanned        │
└─────────────────┘
        │
        │ 1:N
        ├──────────────┐
        │              │
        ↓              ↓
┌─────────────┐  ┌─────────────┐
│   Topics    │  │   Replies   │
├─────────────┤  ├─────────────┤
│ Id (PK)     │  │ Id (PK)     │
│ Title       │  │ Content     │
│ Content     │  │ TopicId(FK) │
│ AuthorId(FK)│  │ AuthorId(FK)│
│ CategoryId  │  │ LikeCount   │
│ ViewCount   │  └─────────────┘
│ LikeCount   │
│ ReplyCount  │
└─────────────┘
        │
        │ N:1
        ↓
┌─────────────┐
│ Categories  │
├─────────────┤
│ Id (PK)     │
│ Name        │
│ Description │
│ IconClass   │
└─────────────┘
```

### Bảng chính

| Bảng | Mô tả | Số cột |
|------|-------|--------|
| **AspNetUsers** | Thông tin người dùng | 15+ |
| **Categories** | Chuyên mục diễn đàn | 5 |
| **Topics** | Chủ đề/bài viết | 11 |
| **Replies** | Phản hồi/bình luận | 7 |
| **TopicLikes** | Lượt thích chủ đề | 4 |
| **ReplyLikes** | Lượt thích phản hồi | 4 |
| **Reports** | Báo cáo vi phạm | 9 |
| **Notifications** | Thông báo | 7 |

---

## 🔐 Bảo mật

### Authentication & Authorization
- ✅ **ASP.NET Identity**: Quản lý người dùng và xác thực
- ✅ **Password Hashing**: Mật khẩu được hash an toàn
- ✅ **Role-based Access**: Phân quyền Admin, Moderator, User
- ✅ **Cookie Authentication**: Session management an toàn

### Data Protection
- ✅ **CSRF Protection**: ValidateAntiForgeryToken cho tất cả forms
- ✅ **SQL Injection Prevention**: Sử dụng EF Core parameterized queries
- ✅ **XSS Protection**: Razor engine tự động encode output
- ✅ **Input Validation**: Data annotations và ModelState validation

### Best Practices
- ✅ HTTPS enforcement
- ✅ Secure cookie settings
- ✅ Password complexity requirements
- ✅ Account lockout on failed attempts
- ✅ Audit logging cho admin actions

---

## 📸 Screenshots

### Trang chủ
- Hero section với gradient background
- Danh sách chuyên mục với icons
- Chủ đề mới nhất và phổ biến

### Danh sách chủ đề
- Tìm kiếm và lọc theo chuyên mục
- Hiển thị metadata: lượt xem, likes, replies
- Phân trang thông minh

### Chi tiết chủ đề
- Nội dung đầy đủ với author info
- Danh sách phản hồi
- Form viết phản hồi mới
- Nút like và báo cáo

### Admin Dashboard
- Thống kê tổng quan
- Quick actions
- Quản lý người dùng và nội dung

---

## 🎯 Roadmap

### Phase 1: MVP ✅ (Hoàn thành)
- [x] Hệ thống tài khoản
- [x] CRUD chủ đề và phản hồi
- [x] Like và tìm kiếm
- [x] Admin dashboard
- [x] Báo cáo vi phạm

### Phase 2: Enhanced Features (Kế hoạch)
- [ ] Upload ảnh cho bài viết
- [ ] Rich text editor (TinyMCE/CKEditor)
- [ ] Email notifications
- [ ] User profiles nâng cao
- [ ] Tags và hashtags

### Phase 3: Advanced Features (Tương lai)
- [ ] Real-time chat
- [ ] Hệ thống điểm và badges
- [ ] Follow users
- [ ] Bookmark posts
- [ ] Advanced search với filters
- [ ] API endpoints (RESTful)
- [ ] Mobile app (React Native/Flutter)

---

## 📁 Cấu trúc Project

```
WebsiteDienDanSucKhoe/
├── Controllers/              # MVC Controllers
│   ├── AccountController.cs  # Authentication
│   ├── AdminController.cs    # Admin functions
│   ├── HomeController.cs     # Homepage
│   ├── RepliesController.cs  # Reply management
│   ├── ReportsController.cs  # Report handling
│   └── TopicsController.cs   # Topic CRUD
├── Models/                   # Data models
│   ├── ApplicationDbContext.cs
│   ├── ApplicationUser.cs
│   ├── Category.cs
│   ├── Topic.cs
│   ├── Reply.cs
│   ├── TopicLike.cs
│   ├── ReplyLike.cs
│   ├── Report.cs
│   └── Notification.cs
├── ViewModels/              # Form models
│   ├── LoginViewModel.cs
│   ├── RegisterViewModel.cs
│   └── ForgotPasswordViewModel.cs
├── Views/                   # Razor views
│   ├── Account/            # Login, Register
│   ├── Admin/              # Admin pages
│   ├── Home/               # Homepage
│   ├── Topics/             # Topic views
│   └── Shared/             # Layouts, partials
├── Data/                   # Data seeding
│   └── SeedData.cs
├── wwwroot/                # Static files
│   ├── css/
│   │   └── site.css        # Custom styles
│   ├── js/
│   │   └── site.js
│   └── lib/                # Bootstrap, jQuery
├── Migrations/             # EF Core migrations
├── appsettings.json        # Configuration
├── Program.cs              # App entry point
└── README.md               # This file
```

---

## 🤝 Đóng góp

Mọi đóng góp đều được chào đón! Để đóng góp:

1. Fork repository
2. Tạo branch mới (`git checkout -b feature/AmazingFeature`)
3. Commit changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to branch (`git push origin feature/AmazingFeature`)
5. Tạo Pull Request

---

## 📄 License

Dự án này được phân phối dưới giấy phép MIT License. Xem file `LICENSE` để biết thêm chi tiết.

MIT License cho phép:
- ✅ Sử dụng thương mại
- ✅ Sửa đổi
- ✅ Phân phối
- ✅ Sử dụng cá nhân

---

## 📞 Liên hệ & Hỗ trợ

- 📧 Email: support@healthforum.com
- 🐛 Issues: [GitHub Issues](https://github.com/your-repo/issues)
- 📖 Documentation: [Wiki](https://github.com/your-repo/wiki)
- 💬 Discussions: [GitHub Discussions](https://github.com/your-repo/discussions)

---

## 🙏 Acknowledgments

- ASP.NET Core Team
- Bootstrap Team
- Entity Framework Core Team
- Cộng đồng .NET Việt Nam

---

## 📊 Thống kê Dự án

- **Ngôn ngữ chính**: C# (85%), HTML/CSS (10%), JavaScript (5%)
- **Tổng dòng code**: ~3,500 lines
- **Số lượng files**: 45+ files
- **Controllers**: 6
- **Models**: 8
- **Views**: 20+
- **Thời gian phát triển**: 2 giờ

---

**⭐ Nếu bạn thấy dự án hữu ích, hãy cho một star trên GitHub!**

**Made with ❤️ using ASP.NET Core MVC**

