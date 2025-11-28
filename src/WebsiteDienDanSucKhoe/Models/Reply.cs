using System.ComponentModel.DataAnnotations;

namespace HealthForumMVC.Models
{
    public class Reply
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Nội dung phản hồi là bắt buộc")]
        public string Content { get; set; } = string.Empty;
        
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public int LikeCount { get; set; } = 0;
        public bool IsDeleted { get; set; } = false;
        
        // Foreign keys
        [Required]
        public int TopicId { get; set; }
        
        [Required]
        public string AuthorId { get; set; } = string.Empty;
        
        // Navigation properties
        public virtual Topic Topic { get; set; } = null!;
        public virtual ApplicationUser Author { get; set; } = null!;
        public virtual ICollection<ReplyLike> Likes { get; set; } = new List<ReplyLike>();
        public virtual ICollection<Report> Reports { get; set; } = new List<Report>();
    }
}
