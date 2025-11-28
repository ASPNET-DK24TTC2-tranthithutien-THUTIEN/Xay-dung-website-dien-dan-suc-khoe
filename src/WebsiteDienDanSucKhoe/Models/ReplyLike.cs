namespace HealthForumMVC.Models
{
    public class ReplyLike
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        
        // Foreign keys
        public int ReplyId { get; set; }
        public string UserId { get; set; } = string.Empty;
        
        // Navigation properties
        public virtual Reply Reply { get; set; } = null!;
        public virtual ApplicationUser User { get; set; } = null!;
    }
}
