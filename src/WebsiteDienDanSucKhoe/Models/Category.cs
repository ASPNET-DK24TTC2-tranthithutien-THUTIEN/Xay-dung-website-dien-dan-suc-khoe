using System.ComponentModel.DataAnnotations;

namespace HealthForumMVC.Models
{
    public class Category
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Tên chuyên mục là bắt buộc")]
        [StringLength(100, ErrorMessage = "Tên chuyên mục không được vượt quá 100 ký tự")]
        public string Name { get; set; } = string.Empty;
        
        [StringLength(500, ErrorMessage = "Mô tả không được vượt quá 500 ký tự")]
        public string? Description { get; set; }
        
        public string? IconClass { get; set; }
        public int DisplayOrder { get; set; }
        
        // Navigation properties
        public virtual ICollection<Topic> Topics { get; set; } = new List<Topic>();
    }
}
