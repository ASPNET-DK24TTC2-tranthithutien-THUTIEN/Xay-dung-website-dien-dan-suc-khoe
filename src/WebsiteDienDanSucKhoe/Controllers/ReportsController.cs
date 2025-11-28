using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HealthForumMVC.Models;

namespace HealthForumMVC.Controllers
{
    [Authorize]
    public class ReportsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public ReportsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // POST: Reports/CreateTopicReport
        [HttpPost]
        public async Task<IActionResult> CreateTopicReport(int topicId, string reason)
        {
            var userId = _userManager.GetUserId(User);
            if (userId == null)
            {
                return Json(new { success = false, message = "Bạn cần đăng nhập để báo cáo" });
            }

            if (string.IsNullOrWhiteSpace(reason))
            {
                return Json(new { success = false, message = "Vui lòng nhập lý do báo cáo" });
            }

            var topic = await _context.Topics.FindAsync(topicId);
            if (topic == null || topic.IsDeleted)
            {
                return Json(new { success = false, message = "Không tìm thấy bài viết" });
            }

            var report = new Report
            {
                ReporterId = userId,
                TopicId = topicId,
                Type = ReportType.Topic,
                Reason = reason,
                Status = ReportStatus.Pending,
                CreatedDate = DateTime.Now
            };

            _context.Reports.Add(report);
            await _context.SaveChangesAsync();

            return Json(new { success = true, message = "Đã gửi báo cáo thành công. Cảm ơn bạn đã giúp chúng tôi duy trì cộng đồng lành mạnh." });
        }

        // POST: Reports/CreateReplyReport
        [HttpPost]
        public async Task<IActionResult> CreateReplyReport(int replyId, string reason)
        {
            var userId = _userManager.GetUserId(User);
            if (userId == null)
            {
                return Json(new { success = false, message = "Bạn cần đăng nhập để báo cáo" });
            }

            if (string.IsNullOrWhiteSpace(reason))
            {
                return Json(new { success = false, message = "Vui lòng nhập lý do báo cáo" });
            }

            var reply = await _context.Replies.FindAsync(replyId);
            if (reply == null || reply.IsDeleted)
            {
                return Json(new { success = false, message = "Không tìm thấy bình luận" });
            }

            var report = new Report
            {
                ReporterId = userId,
                ReplyId = replyId,
                Type = ReportType.Reply,
                Reason = reason,
                Status = ReportStatus.Pending,
                CreatedDate = DateTime.Now
            };

            _context.Reports.Add(report);
            await _context.SaveChangesAsync();

            return Json(new { success = true, message = "Đã gửi báo cáo thành công. Cảm ơn bạn đã giúp chúng tôi duy trì cộng đồng lành mạnh." });
        }
    }
}
