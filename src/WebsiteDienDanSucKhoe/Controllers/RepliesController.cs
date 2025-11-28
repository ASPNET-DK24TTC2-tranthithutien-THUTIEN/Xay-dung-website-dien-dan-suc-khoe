using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HealthForumMVC.Models;

namespace HealthForumMVC.Controllers
{
    [Authorize]
    public class RepliesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public RepliesController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // POST: Replies/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Content,TopicId")] Reply reply)
        {
            if (ModelState.IsValid)
            {
                var userId = _userManager.GetUserId(User);
                if (userId == null)
                {
                    return Unauthorized();
                }

                var topic = await _context.Topics.FindAsync(reply.TopicId);
                if (topic == null || topic.IsDeleted)
                {
                    return NotFound();
                }

                reply.AuthorId = userId;
                reply.CreatedDate = DateTime.Now;

                _context.Add(reply);
                
                // Update topic
                topic.ReplyCount++;
                topic.LastActivityDate = DateTime.Now;
                
                // Create notification for topic author
                if (topic.AuthorId != userId)
                {
                    var notification = new Notification
                    {
                        UserId = topic.AuthorId,
                        Type = NotificationType.NewReply,
                        Message = $"{User.Identity?.Name} đã trả lời bài viết của bạn: {topic.Title}",
                        Link = $"/Topics/Details/{topic.Id}",
                        CreatedDate = DateTime.Now
                    };
                    _context.Notifications.Add(notification);
                }
                
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", "Topics", new { id = reply.TopicId });
            }

            return RedirectToAction("Details", "Topics", new { id = reply.TopicId });
        }

        // POST: Replies/Like/5
        [HttpPost]
        public async Task<IActionResult> Like(int id)
        {
            var userId = _userManager.GetUserId(User);
            if (userId == null)
            {
                return Json(new { success = false, message = "Bạn cần đăng nhập để thích bình luận" });
            }

            var reply = await _context.Replies.FindAsync(id);
            if (reply == null || reply.IsDeleted)
            {
                return Json(new { success = false, message = "Không tìm thấy bình luận" });
            }

            var existingLike = await _context.ReplyLikes
                .FirstOrDefaultAsync(rl => rl.ReplyId == id && rl.UserId == userId);

            if (existingLike != null)
            {
                // Unlike
                _context.ReplyLikes.Remove(existingLike);
                reply.LikeCount--;
                await _context.SaveChangesAsync();
                return Json(new { success = true, liked = false, likeCount = reply.LikeCount });
            }
            else
            {
                // Like
                var like = new ReplyLike
                {
                    ReplyId = id,
                    UserId = userId,
                    CreatedDate = DateTime.Now
                };
                _context.ReplyLikes.Add(like);
                reply.LikeCount++;
                
                // Create notification for reply author
                if (reply.AuthorId != userId)
                {
                    var notification = new Notification
                    {
                        UserId = reply.AuthorId,
                        Type = NotificationType.ReplyLiked,
                        Message = $"{User.Identity?.Name} đã thích bình luận của bạn",
                        Link = $"/Topics/Details/{reply.TopicId}",
                        CreatedDate = DateTime.Now
                    };
                    _context.Notifications.Add(notification);
                }
                
                await _context.SaveChangesAsync();
                return Json(new { success = true, liked = true, likeCount = reply.LikeCount });
            }
        }

        // POST: Replies/Delete/5
        [HttpPost]
        [Authorize(Roles = "Admin,Moderator")]
        public async Task<IActionResult> Delete(int id)
        {
            var reply = await _context.Replies.Include(r => r.Topic).FirstOrDefaultAsync(r => r.Id == id);
            if (reply == null)
            {
                return Json(new { success = false, message = "Không tìm thấy bình luận" });
            }

            reply.IsDeleted = true;
            
            // Update topic reply count
            if (reply.Topic != null)
            {
                reply.Topic.ReplyCount = Math.Max(0, reply.Topic.ReplyCount - 1);
            }
            
            await _context.SaveChangesAsync();

            return Json(new { success = true, message = "Đã xóa bình luận thành công" });
        }
    }
}
