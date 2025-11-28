using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HealthForumMVC.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        
        public DbSet<Category> Categories { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Reply> Replies { get; set; }
        public DbSet<TopicLike> TopicLikes { get; set; }
        public DbSet<ReplyLike> ReplyLikes { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            // Configure relationships
            modelBuilder.Entity<Topic>()
                .HasOne(t => t.Author)
                .WithMany(u => u.Topics)
                .HasForeignKey(t => t.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);
            
            modelBuilder.Entity<Topic>()
                .HasOne(t => t.Category)
                .WithMany(c => c.Topics)
                .HasForeignKey(t => t.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);
            
            modelBuilder.Entity<Reply>()
                .HasOne(r => r.Author)
                .WithMany(u => u.Replies)
                .HasForeignKey(r => r.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);
            
            modelBuilder.Entity<Reply>()
                .HasOne(r => r.Topic)
                .WithMany(t => t.Replies)
                .HasForeignKey(r => r.TopicId)
                .OnDelete(DeleteBehavior.Cascade);
            
            modelBuilder.Entity<TopicLike>()
                .HasOne(tl => tl.Topic)
                .WithMany(t => t.Likes)
                .HasForeignKey(tl => tl.TopicId)
                .OnDelete(DeleteBehavior.Cascade);
            
            modelBuilder.Entity<TopicLike>()
                .HasOne(tl => tl.User)
                .WithMany(u => u.TopicLikes)
                .HasForeignKey(tl => tl.UserId)
                .OnDelete(DeleteBehavior.Restrict);
            
            modelBuilder.Entity<ReplyLike>()
                .HasOne(rl => rl.Reply)
                .WithMany(r => r.Likes)
                .HasForeignKey(rl => rl.ReplyId)
                .OnDelete(DeleteBehavior.Cascade);
            
            modelBuilder.Entity<ReplyLike>()
                .HasOne(rl => rl.User)
                .WithMany(u => u.ReplyLikes)
                .HasForeignKey(rl => rl.UserId)
                .OnDelete(DeleteBehavior.Restrict);
            
            modelBuilder.Entity<Report>()
                .HasOne(r => r.Reporter)
                .WithMany(u => u.Reports)
                .HasForeignKey(r => r.ReporterId)
                .OnDelete(DeleteBehavior.Restrict);
            
            modelBuilder.Entity<Notification>()
                .HasOne(n => n.User)
                .WithMany(u => u.Notifications)
                .HasForeignKey(n => n.UserId)
                .OnDelete(DeleteBehavior.Cascade);
            
            // Seed initial categories
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Dinh dưỡng", Description = "Thảo luận về chế độ ăn uống và dinh dưỡng", IconClass = "bi-egg-fried", DisplayOrder = 1 },
                new Category { Id = 2, Name = "Tập luyện", Description = "Chia sẻ về các bài tập và phương pháp rèn luyện sức khỏe", IconClass = "bi-heart-pulse", DisplayOrder = 2 },
                new Category { Id = 3, Name = "Hỏi đáp", Description = "Đặt câu hỏi và nhận tư vấn về sức khỏe", IconClass = "bi-question-circle", DisplayOrder = 3 },
                new Category { Id = 4, Name = "Sức khỏe tinh thần", Description = "Thảo luận về sức khỏe tâm lý và tinh thần", IconClass = "bi-emoji-smile", DisplayOrder = 4 },
                new Category { Id = 5, Name = "Bệnh lý", Description = "Thông tin và chia sẻ về các bệnh lý thường gặp", IconClass = "bi-hospital", DisplayOrder = 5 }
            );
        }
    }
}
