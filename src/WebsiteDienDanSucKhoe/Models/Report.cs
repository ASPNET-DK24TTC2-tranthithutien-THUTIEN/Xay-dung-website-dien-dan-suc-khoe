using System.ComponentModel.DataAnnotations;

namespace HealthForumMVC.Models
{
    public enum ReportType
    {
        Topic,
        Reply
    }
    
    public enum ReportStatus
    {
        Pending,
        Reviewed,
        Resolved,
        Dismissed
    }
    
    public class Report
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Lý do báo cáo là bắt buộc")]
        [StringLength(500, ErrorMessage = "Lý do không được vượt quá 500 ký tự")]
        public string Reason { get; set; } = string.Empty;
        
        public ReportType Type { get; set; }
        public ReportStatus Status { get; set; } = ReportStatus.Pending;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? ReviewedDate { get; set; }
        public string? AdminNote { get; set; }
        
        // Foreign keys
        public string ReporterId { get; set; } = string.Empty;
        public int? TopicId { get; set; }
        public int? ReplyId { get; set; }
        
        // Navigation properties
        public virtual ApplicationUser Reporter { get; set; } = null!;
        public virtual Topic? Topic { get; set; }
        public virtual Reply? Reply { get; set; }
    }
}
