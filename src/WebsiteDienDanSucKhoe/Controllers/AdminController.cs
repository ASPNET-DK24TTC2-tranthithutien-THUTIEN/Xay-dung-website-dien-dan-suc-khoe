using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HealthForumMVC.Models;

namespace HealthForumMVC.Controllers
{
    [Authorize(Roles = "Admin,Moderator")]
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public AdminController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Admin
        public async Task<IActionResult> Index()
        {
            var stats = new
            {
                TotalUsers = await _context.Users.CountAsync(),
                TotalTopics = await _context.Topics.CountAsync(t => !t.IsDeleted),
                TotalReplies = await _context.Replies.CountAsync(r => !r.IsDeleted),
                PendingReports = await _context.Reports.CountAsync(r => r.Status == ReportStatus.Pending)
            };

            ViewData["Stats"] = stats;
            return View();
        }

        // GET: Admin/Reports
        public async Task<IActionResult> Reports(int page = 1)
        {
            int pageSize = 20;
            var query = _context.Reports
                .Include(r => r.Reporter)
                .Include(r => r.Topic)
                .Include(r => r.Reply)
                .OrderByDescending(r => r.CreatedDate);

            var totalItems = await query.CountAsync();
            var reports = await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            ViewData["CurrentPage"] = page;
            ViewData["TotalPages"] = (int)Math.Ceiling(totalItems / (double)pageSize);

            return View(reports);
        }

        // POST: Admin/ReviewReport
        [HttpPost]
        public async Task<IActionResult> ReviewReport(int id, string action, string? adminNote)
        {
            var report = await _context.Reports.FindAsync(id);
            if (report == null)
            {
                return Json(new { success = false, message = "Không tìm thấy báo cáo" });
            }

            report.ReviewedDate = DateTime.Now;
            report.AdminNote = adminNote;

            switch (action)
            {
                case "resolve":
                    report.Status = ReportStatus.Resolved;
                    break;
                case "dismiss":
                    report.Status = ReportStatus.Dismissed;
                    break;
                default:
                    return Json(new { success = false, message = "Hành động không hợp lệ" });
            }

            await _context.SaveChangesAsync();
            return Json(new { success = true, message = "Đã xử lý báo cáo thành công" });
        }

        // GET: Admin/Users
        public async Task<IActionResult> Users(int page = 1, string? searchQuery = null)
        {
            int pageSize = 20;
            var query = _context.Users.AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchQuery))
            {
                query = query.Where(u => u.Email!.Contains(searchQuery) || u.DisplayName!.Contains(searchQuery));
                ViewData["SearchQuery"] = searchQuery;
            }

            var totalItems = await query.CountAsync();
            var users = await query
                .OrderByDescending(u => u.JoinedDate)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            ViewData["CurrentPage"] = page;
            ViewData["TotalPages"] = (int)Math.Ceiling(totalItems / (double)pageSize);

            return View(users);
        }

        // POST: Admin/BanUser
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> BanUser(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return Json(new { success = false, message = "Không tìm thấy người dùng" });
            }

            user.IsBanned = !user.IsBanned;
            await _userManager.UpdateAsync(user);

            var message = user.IsBanned ? "Đã khóa tài khoản người dùng" : "Đã mở khóa tài khoản người dùng";
            return Json(new { success = true, message = message, isBanned = user.IsBanned });
        }

        // GET: Admin/Topics
        public async Task<IActionResult> Topics(int page = 1, bool showDeleted = false)
        {
            int pageSize = 20;
            var query = _context.Topics
                .Include(t => t.Author)
                .Include(t => t.Category)
                .AsQueryable();

            if (!showDeleted)
            {
                query = query.Where(t => !t.IsDeleted);
            }

            var totalItems = await query.CountAsync();
            var topics = await query
                .OrderByDescending(t => t.CreatedDate)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            ViewData["CurrentPage"] = page;
            ViewData["TotalPages"] = (int)Math.Ceiling(totalItems / (double)pageSize);
            ViewData["ShowDeleted"] = showDeleted;

            return View(topics);
        }
    }
}
