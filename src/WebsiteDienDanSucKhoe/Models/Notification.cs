namespace HealthForumMVC.Models
{
    public enum NotificationType
    {
        NewReply,
        TopicLiked,
        ReplyLiked,
        Mention
    }
    
    public class Notification
    {
        public int Id { get; set; }
        public string Message { get; set; } = string.Empty;
        public NotificationType Type { get; set; }
        public bool IsRead { get; set; } = false;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string? Link { get; set; }
        
        // Foreign keys
        public string UserId { get; set; } = string.Empty;
        
        // Navigation properties
        public virtual ApplicationUser User { get; set; } = null!;
    }
}
