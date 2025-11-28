namespace HealthForumMVC.Models
{
    public class TopicLike
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        
        // Foreign keys
        public int TopicId { get; set; }
        public string UserId { get; set; } = string.Empty;
        
        // Navigation properties
        public virtual Topic Topic { get; set; } = null!;
        public virtual ApplicationUser User { get; set; } = null!;
    }
}
