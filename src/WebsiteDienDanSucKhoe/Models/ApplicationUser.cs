using Microsoft.AspNetCore.Identity;

namespace HealthForumMVC.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? DisplayName { get; set; }
        public string? AvatarUrl { get; set; }
        public DateTime JoinedDate { get; set; } = DateTime.Now;
        public bool IsBanned { get; set; } = false;
        
        // Navigation properties
        public virtual ICollection<Topic> Topics { get; set; } = new List<Topic>();
        public virtual ICollection<Reply> Replies { get; set; } = new List<Reply>();
        public virtual ICollection<TopicLike> TopicLikes { get; set; } = new List<TopicLike>();
        public virtual ICollection<ReplyLike> ReplyLikes { get; set; } = new List<ReplyLike>();
        public virtual ICollection<Report> Reports { get; set; } = new List<Report>();
        public virtual ICollection<Notification> Notifications { get; set; } = new List<Notification>();
    }
}
