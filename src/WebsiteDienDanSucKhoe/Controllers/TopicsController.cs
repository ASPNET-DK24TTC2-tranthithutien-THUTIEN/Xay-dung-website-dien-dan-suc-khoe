using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HealthForumMVC.Models;

namespace HealthForumMVC.Controllers
{
    public class TopicsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public TopicsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Topics
        public async Task<IActionResult> Index(int? categoryId, string? searchQuery, int page = 1)
        {
            int pageSize = 20;
            var query = _context.Topics
                .Include(t => t.Author)
                .Include(t => t.Category)
                .Where(t => !t.IsDeleted);

            if (categoryId.HasValue)
            {
                query = query.Where(t => t.CategoryId == categoryId.Value);
            }

            if (!string.IsNullOrWhiteSpace(searchQuery))
            {
                query = query.Where(t => t.Title.Contains(searchQuery) || t.Content.Contains(searchQuery));
                ViewData["SearchQuery"] = searchQuery;
            }

            var totalItems = await query.CountAsync();
            var topics = await query
                .OrderByDescending(t => t.LastActivityDate ?? t.CreatedDate)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            ViewData["CurrentPage"] = page;
            ViewData["TotalPages"] = (int)Math.Ceiling(totalItems / (double)pageSize);
            ViewData["CategoryId"] = categoryId;
            ViewData["Categories"] = await _context.Categories.OrderBy(c => c.DisplayOrder).ToListAsync();

            return View(topics);
        }

        // GET: Topics/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var topic = await _context.Topics
                .Include(t => t.Author)
                .Include(t => t.Category)
                .Include(t => t.Replies)
                    .ThenInclude(r => r.Author)
                .Include(t => t.Likes)
                .FirstOrDefaultAsync(m => m.Id == id && !m.IsDeleted);

            if (topic == null)
            {
                return NotFound();
            }

            // Increment view count
            topic.ViewCount++;
            await _context.SaveChangesAsync();

            // Check if current user has liked this topic
            if (User.Identity?.IsAuthenticated == true)
            {
                var userId = _userManager.GetUserId(User);
                ViewData["HasLiked"] = await _context.TopicLikes.AnyAsync(tl => tl.TopicId == id && tl.UserId == userId);
            }

            return View(topic);
        }

        // GET: Topics/Create
        [Authorize]
        public async Task<IActionResult> Create()
        {
            ViewData["Categories"] = await _context.Categories.OrderBy(c => c.DisplayOrder).ToListAsync();
            return View();
        }

        // POST: Topics/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create([Bind("Title,Content,CategoryId")] Topic topic)
        {
            // Remove validation errors for properties we're setting manually
            ModelState.Remove("AuthorId");
            ModelState.Remove("Author");
            ModelState.Remove("Category");
            
            if (ModelState.IsValid)
            {
                var userId = _userManager.GetUserId(User);
                if (userId == null)
                {
                    return Unauthorized();
                }

                topic.AuthorId = userId;
                topic.CreatedDate = DateTime.Now;
                topic.LastActivityDate = DateTime.Now;
                topic.ViewCount = 0;
                topic.LikeCount = 0;
                topic.ReplyCount = 0;
                topic.IsDeleted = false;

                _context.Add(topic);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Details), new { id = topic.Id });
            }

            ViewData["Categories"] = await _context.Categories.OrderBy(c => c.DisplayOrder).ToListAsync();
            return View(topic);
        }

        // POST: Topics/Like/5
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Like(int id)
        {
            var userId = _userManager.GetUserId(User);
            if (userId == null)
            {
                return Json(new { success = false, message = "Bạn cần đăng nhập để thích bài viết" });
            }

            var topic = await _context.Topics.FindAsync(id);
            if (topic == null || topic.IsDeleted)
            {
                return Json(new { success = false, message = "Không tìm thấy bài viết" });
            }

            var existingLike = await _context.TopicLikes
                .FirstOrDefaultAsync(tl => tl.TopicId == id && tl.UserId == userId);

            if (existingLike != null)
            {
                // Unlike
                _context.TopicLikes.Remove(existingLike);
                topic.LikeCount--;
                await _context.SaveChangesAsync();
                return Json(new { success = true, liked = false, likeCount = topic.LikeCount });
            }
            else
            {
                // Like
                var like = new TopicLike
                {
                    TopicId = id,
                    UserId = userId,
                    CreatedDate = DateTime.Now
                };
                _context.TopicLikes.Add(like);
                topic.LikeCount++;
                
                // Create notification for topic author
                if (topic.AuthorId != userId)
                {
                    var notification = new Notification
                    {
                        UserId = topic.AuthorId,
                        Type = NotificationType.TopicLiked,
                        Message = $"{User.Identity?.Name} đã thích bài viết của bạn: {topic.Title}",
                        Link = $"/Topics/Details/{topic.Id}",
                        CreatedDate = DateTime.Now
                    };
                    _context.Notifications.Add(notification);
                }
                
                await _context.SaveChangesAsync();
                return Json(new { success = true, liked = true, likeCount = topic.LikeCount });
            }
        }

        // POST: Topics/Delete/5
        [HttpPost]
        [Authorize(Roles = "Admin,Moderator")]
        public async Task<IActionResult> Delete(int id)
        {
            var topic = await _context.Topics.FindAsync(id);
            if (topic == null)
            {
                return Json(new { success = false, message = "Không tìm thấy bài viết" });
            }

            topic.IsDeleted = true;
            await _context.SaveChangesAsync();

            return Json(new { success = true, message = "Đã xóa bài viết thành công" });
        }
    }
}
