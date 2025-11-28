using System.ComponentModel.DataAnnotations;

namespace HealthForumMVC.Models
{
    public class Topic
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Tiêu đề là bắt buộc")]
        [StringLength(200, ErrorMessage = "Tiêu đề không được vượt quá 200 ký tự")]
        public string Title { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "Nội dung là bắt buộc")]
        public string Content { get; set; } = string.Empty;
        
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? LastActivityDate { get; set; }
        public int ViewCount { get; set; } = 0;
        public int LikeCount { get; set; } = 0;
        public int ReplyCount { get; set; } = 0;
        public bool IsDeleted { get; set; } = false;
        
        // Foreign keys
        [Required]
        public string AuthorId { get; set; } = string.Empty;
        
        [Required]
        public int CategoryId { get; set; }
        
        // Navigation properties
        public virtual ApplicationUser Author { get; set; } = null!;
        public virtual Category Category { get; set; } = null!;
        public virtual ICollection<Reply> Replies { get; set; } = new List<Reply>();
        public virtual ICollection<TopicLike> Likes { get; set; } = new List<TopicLike>();
        public virtual ICollection<Report> Reports { get; set; } = new List<Report>();
    }
}
