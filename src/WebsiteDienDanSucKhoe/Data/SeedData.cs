using Microsoft.AspNetCore.Identity;
using HealthForumMVC.Models;

namespace HealthForumMVC.Data
{
    public static class SeedData
    {
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<ApplicationDbContext>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            // Kiểm tra xem đã có dữ liệu chưa
            if (context.Topics.Any())
            {
                return; // Đã có dữ liệu
            }

            // Tạo người dùng mẫu
            var users = new List<ApplicationUser>();
            
            var user1 = new ApplicationUser
            {
                UserName = "nguyenvana@example.com",
                Email = "nguyenvana@example.com",
                DisplayName = "Nguyễn Văn A",
                EmailConfirmed = true,
                JoinedDate = DateTime.Now.AddMonths(-6)
            };
            await userManager.CreateAsync(user1, "User@123");
            await userManager.AddToRoleAsync(user1, "User");
            users.Add(user1);

            var user2 = new ApplicationUser
            {
                UserName = "tranthib@example.com",
                Email = "tranthib@example.com",
                DisplayName = "Trần Thị B",
                EmailConfirmed = true,
                JoinedDate = DateTime.Now.AddMonths(-5)
            };
            await userManager.CreateAsync(user2, "User@123");
            await userManager.AddToRoleAsync(user2, "User");
            users.Add(user2);

            var user3 = new ApplicationUser
            {
                UserName = "levanc@example.com",
                Email = "levanc@example.com",
                DisplayName = "Lê Văn C",
                EmailConfirmed = true,
                JoinedDate = DateTime.Now.AddMonths(-4)
            };
            await userManager.CreateAsync(user3, "User@123");
            await userManager.AddToRoleAsync(user3, "User");
            users.Add(user3);

            var user4 = new ApplicationUser
            {
                UserName = "phamthid@example.com",
                Email = "phamthid@example.com",
                DisplayName = "Phạm Thị D",
                EmailConfirmed = true,
                JoinedDate = DateTime.Now.AddMonths(-3)
            };
            await userManager.CreateAsync(user4, "User@123");
            await userManager.AddToRoleAsync(user4, "User");
            users.Add(user4);

            var user5 = new ApplicationUser
            {
                UserName = "hoangvane@example.com",
                Email = "hoangvane@example.com",
                DisplayName = "Hoàng Văn E",
                EmailConfirmed = true,
                JoinedDate = DateTime.Now.AddMonths(-2)
            };
            await userManager.CreateAsync(user5, "User@123");
            await userManager.AddToRoleAsync(user5, "User");
            users.Add(user5);

            // Tạo chủ đề mẫu
            var topics = new List<Topic>
            {
                new Topic
                {
                    Title = "Chế độ ăn uống lành mạnh cho người bận rộn",
                    Content = "Xin chào mọi người! Mình là dân văn phòng, ngồi nhiều và thường xuyên ăn nhanh. Mọi người có thể chia sẻ chế độ ăn uống lành mạnh mà vẫn tiện lợi cho người bận rộn như mình không?\n\nMình đang muốn cải thiện sức khỏe nhưng không có nhiều thời gian nấu nướng. Cảm ơn mọi người!",
                    CategoryId = 1, // Dinh dưỡng
                    AuthorId = users[0].Id,
                    CreatedDate = DateTime.Now.AddDays(-15),
                    LastActivityDate = DateTime.Now.AddDays(-2),
                    ViewCount = 245,
                    LikeCount = 12,
                    ReplyCount = 0
                },
                new Topic
                {
                    Title = "Bài tập cardio tại nhà hiệu quả",
                    Content = "Chào các bạn! Do dịch bệnh nên mình không thể đến phòng gym. Các bạn có thể gợi ý một số bài tập cardio hiệu quả có thể tập tại nhà không?\n\nMình muốn giảm cân và tăng cường sức bền. Không gian nhà mình khá hạn chế nên cần những bài tập không cần nhiều dụng cụ. Cảm ơn!",
                    CategoryId = 2, // Tập luyện
                    AuthorId = users[1].Id,
                    CreatedDate = DateTime.Now.AddDays(-12),
                    LastActivityDate = DateTime.Now.AddDays(-1),
                    ViewCount = 189,
                    LikeCount = 8,
                    ReplyCount = 0
                },
                new Topic
                {
                    Title = "Làm thế nào để ngủ ngon hơn?",
                    Content = "Gần đây mình hay bị mất ngủ, ngủ không sâu giấc. Buổi sáng dậy thấy mệt mỏi và không tập trung được.\n\nCác bạn có kinh nghiệm gì để cải thiện chất lượng giấc ngủ không? Mình đã thử uống sữa ấm trước khi ngủ nhưng không thấy hiệu quả lắm.",
                    CategoryId = 3, // Hỏi đáp
                    AuthorId = users[2].Id,
                    CreatedDate = DateTime.Now.AddDays(-10),
                    LastActivityDate = DateTime.Now.AddHours(-5),
                    ViewCount = 312,
                    LikeCount = 15,
                    ReplyCount = 0
                },
                new Topic
                {
                    Title = "Cách giảm stress hiệu quả",
                    Content = "Công việc gần đây khá áp lực, mình thấy mình hay căng thẳng và lo lắng. Các bạn có cách nào giảm stress hiệu quả không?\n\nMình đã thử nghe nhạc thư giãn nhưng vẫn chưa đủ. Mong mọi người chia sẻ kinh nghiệm!",
                    CategoryId = 4, // Sức khỏe tinh thần
                    AuthorId = users[3].Id,
                    CreatedDate = DateTime.Now.AddDays(-8),
                    LastActivityDate = DateTime.Now.AddHours(-3),
                    ViewCount = 156,
                    LikeCount = 10,
                    ReplyCount = 0
                },
                new Topic
                {
                    Title = "Phòng ngừa cảm cúm mùa đông",
                    Content = "Mùa đông sắp đến, mình muốn hỏi các bạn về cách phòng ngừa cảm cúm hiệu quả.\n\nNgoài việc giữ ấm cơ thể, các bạn còn có biện pháp nào khác không? Có nên uống vitamin C không?",
                    CategoryId = 5, // Bệnh lý
                    AuthorId = users[4].Id,
                    CreatedDate = DateTime.Now.AddDays(-6),
                    LastActivityDate = DateTime.Now.AddHours(-1),
                    ViewCount = 98,
                    LikeCount = 5,
                    ReplyCount = 0
                },
                new Topic
                {
                    Title = "Thực đơn giảm cân khoa học",
                    Content = "Mình cao 1m65, nặng 70kg và muốn giảm xuống 60kg. Các bạn có thể gợi ý thực đơn giảm cân khoa học không?\n\nMình không muốn nhịn ăn quá nhiều vì sợ ảnh hưởng sức khỏe. Mong các bạn tư vấn!",
                    CategoryId = 1, // Dinh dưỡng
                    AuthorId = users[0].Id,
                    CreatedDate = DateTime.Now.AddDays(-5),
                    LastActivityDate = DateTime.Now.AddMinutes(-30),
                    ViewCount = 267,
                    LikeCount = 18,
                    ReplyCount = 0
                },
                new Topic
                {
                    Title = "Yoga cho người mới bắt đầu",
                    Content = "Mình muốn tập yoga để tăng cường sức khỏe và giảm stress. Các bạn có thể gợi ý những tư thế yoga cơ bản cho người mới bắt đầu không?\n\nMình hoàn toàn mới với yoga nên cần hướng dẫn chi tiết. Cảm ơn mọi người!",
                    CategoryId = 2, // Tập luyện
                    AuthorId = users[1].Id,
                    CreatedDate = DateTime.Now.AddDays(-4),
                    LastActivityDate = DateTime.Now.AddMinutes(-15),
                    ViewCount = 134,
                    LikeCount = 7,
                    ReplyCount = 0
                },
                new Topic
                {
                    Title = "Uống bao nhiêu nước mỗi ngày là đủ?",
                    Content = "Mình thường nghe nói nên uống 2 lít nước mỗi ngày, nhưng có phải ai cũng vậy không?\n\nCó cách nào biết mình cần uống bao nhiêu nước mỗi ngày không? Và nên uống vào thời điểm nào trong ngày?",
                    CategoryId = 3, // Hỏi đáp
                    AuthorId = users[2].Id,
                    CreatedDate = DateTime.Now.AddDays(-3),
                    LastActivityDate = DateTime.Now.AddMinutes(-10),
                    ViewCount = 178,
                    LikeCount = 9,
                    ReplyCount = 0
                },
                new Topic
                {
                    Title = "Thiền định có thực sự hiệu quả?",
                    Content = "Mình nghe nhiều người nói về lợi ích của thiền định nhưng chưa bao giờ thử. Các bạn có kinh nghiệm với thiền định không?\n\nNó có thực sự giúp giảm stress và cải thiện tâm trạng không? Làm thế nào để bắt đầu?",
                    CategoryId = 4, // Sức khỏe tinh thần
                    AuthorId = users[3].Id,
                    CreatedDate = DateTime.Now.AddDays(-2),
                    LastActivityDate = DateTime.Now.AddMinutes(-5),
                    ViewCount = 145,
                    LikeCount = 11,
                    ReplyCount = 0
                },
                new Topic
                {
                    Title = "Đau lưng do ngồi nhiều - Cách khắc phục",
                    Content = "Mình làm việc văn phòng, ngồi nhiều nên hay bị đau lưng. Các bạn có cách nào khắc phục không?\n\nMình đã thử ngồi ghế ergonomic nhưng vẫn bị đau. Có bài tập nào giúp giảm đau lưng không?",
                    CategoryId = 5, // Bệnh lý
                    AuthorId = users[4].Id,
                    CreatedDate = DateTime.Now.AddDays(-1),
                    LastActivityDate = DateTime.Now.AddMinutes(-2),
                    ViewCount = 89,
                    LikeCount = 6,
                    ReplyCount = 0
                }
            };

            context.Topics.AddRange(topics);
            await context.SaveChangesAsync();

            // Tạo phản hồi mẫu
            var replies = new List<Reply>
            {
                // Phản hồi cho chủ đề 1
                new Reply
                {
                    Content = "Mình cũng là dân văn phòng và đây là cách mình áp dụng:\n\n1. Chuẩn bị đồ ăn vào cuối tuần cho cả tuần\n2. Ưu tiên thực phẩm dễ chế biến: salad, trứng luộc, yến mạch\n3. Mang theo hoa quả và hạt để ăn vặt lành mạnh\n\nHy vọng giúp ích cho bạn!",
                    TopicId = topics[0].Id,
                    AuthorId = users[1].Id,
                    CreatedDate = DateTime.Now.AddDays(-14),
                    LikeCount = 5
                },
                new Reply
                {
                    Content = "Bạn có thể thử meal prep nhé! Mình nấu 1 lần cho 3-4 ngày, chia ra hộp và bảo quản tủ lạnh. Tiện lợi lắm!",
                    TopicId = topics[0].Id,
                    AuthorId = users[2].Id,
                    CreatedDate = DateTime.Now.AddDays(-13),
                    LikeCount = 3
                },
                new Reply
                {
                    Content = "Mình khuyên bạn nên ăn nhiều rau xanh, protein từ cá và gà, hạn chế đồ chiên rán. Uống đủ nước cũng rất quan trọng!",
                    TopicId = topics[0].Id,
                    AuthorId = users[3].Id,
                    CreatedDate = DateTime.Now.AddDays(-2),
                    LikeCount = 4
                },

                // Phản hồi cho chủ đề 2
                new Reply
                {
                    Content = "Mình gợi ý một số bài tập:\n\n1. Jumping jacks - 3 hiệp x 30 giây\n2. Burpees - 3 hiệp x 10 lần\n3. Mountain climbers - 3 hiệp x 20 lần\n4. High knees - 3 hiệp x 30 giây\n\nNghỉ 30 giây giữa các hiệp nhé!",
                    TopicId = topics[1].Id,
                    AuthorId = users[0].Id,
                    CreatedDate = DateTime.Now.AddDays(-11),
                    LikeCount = 7
                },
                new Reply
                {
                    Content = "Bạn có thể tham khảo các video trên YouTube về HIIT workout. Rất hiệu quả và không cần dụng cụ!",
                    TopicId = topics[1].Id,
                    AuthorId = users[4].Id,
                    CreatedDate = DateTime.Now.AddDays(-1),
                    LikeCount = 2
                },

                // Phản hồi cho chủ đề 3
                new Reply
                {
                    Content = "Mình có một số gợi ý:\n\n1. Tắt điện thoại trước khi ngủ 1 tiếng\n2. Giữ phòng ngủ mát mẻ và tối\n3. Tập thở sâu trước khi ngủ\n4. Tránh caffeine sau 2 giờ chiều\n\nHy vọng giúp bạn ngủ ngon hơn!",
                    TopicId = topics[2].Id,
                    AuthorId = users[0].Id,
                    CreatedDate = DateTime.Now.AddDays(-9),
                    LikeCount = 8
                },
                new Reply
                {
                    Content = "Bạn thử đọc sách trước khi ngủ xem sao. Mình thấy hiệu quả lắm, giúp não bộ thư giãn.",
                    TopicId = topics[2].Id,
                    AuthorId = users[1].Id,
                    CreatedDate = DateTime.Now.AddDays(-8),
                    LikeCount = 4
                },
                new Reply
                {
                    Content = "Mình khuyên bạn nên tập thể dục đều đặn, nhưng không tập quá muộn. Tập vào buổi sáng hoặc chiều sẽ tốt hơn.",
                    TopicId = topics[2].Id,
                    AuthorId = users[4].Id,
                    CreatedDate = DateTime.Now.AddHours(-5),
                    LikeCount = 3
                },

                // Phản hồi cho chủ đề 4
                new Reply
                {
                    Content = "Mình thấy tập yoga và thiền định rất hiệu quả trong việc giảm stress. Bạn có thể thử xem!",
                    TopicId = topics[3].Id,
                    AuthorId = users[0].Id,
                    CreatedDate = DateTime.Now.AddDays(-7),
                    LikeCount = 6
                },
                new Reply
                {
                    Content = "Dành thời gian cho sở thích cá nhân cũng giúp giảm stress đấy. Mình thường vẽ tranh hoặc nghe nhạc.",
                    TopicId = topics[3].Id,
                    AuthorId = users[2].Id,
                    CreatedDate = DateTime.Now.AddHours(-3),
                    LikeCount = 2
                },

                // Phản hồi cho chủ đề 5
                new Reply
                {
                    Content = "Ngoài giữ ấm, bạn nên:\n\n1. Rửa tay thường xuyên\n2. Ăn nhiều trái cây giàu vitamin C\n3. Ngủ đủ giấc\n4. Tập thể dục đều đặn\n\nĐây là cách tốt nhất để tăng cường miễn dịch!",
                    TopicId = topics[4].Id,
                    AuthorId = users[1].Id,
                    CreatedDate = DateTime.Now.AddDays(-5),
                    LikeCount = 5
                },
                new Reply
                {
                    Content = "Vitamin C có thể giúp ích nhưng không nên lạm dụng. Tốt nhất là bổ sung từ thực phẩm tự nhiên.",
                    TopicId = topics[4].Id,
                    AuthorId = users[3].Id,
                    CreatedDate = DateTime.Now.AddHours(-1),
                    LikeCount = 3
                },

                // Phản hồi cho chủ đề 6
                new Reply
                {
                    Content = "Thực đơn gợi ý:\n\nSáng: Yến mạch + trái cây\nTrưa: Cơm gạo lứt + thịt gà + rau\nTối: Salad + cá hồi\n\nNhớ ăn đủ 3 bữa và uống nhiều nước nhé!",
                    TopicId = topics[5].Id,
                    AuthorId = users[2].Id,
                    CreatedDate = DateTime.Now.AddDays(-4),
                    LikeCount = 9
                },
                new Reply
                {
                    Content = "Bạn nên kết hợp ăn uống lành mạnh với tập luyện đều đặn. Chỉ ăn kiêng thôi thì khó giảm cân bền vững.",
                    TopicId = topics[5].Id,
                    AuthorId = users[4].Id,
                    CreatedDate = DateTime.Now.AddMinutes(-30),
                    LikeCount = 4
                },

                // Phản hồi cho chủ đề 7
                new Reply
                {
                    Content = "Một số tư thế cơ bản:\n\n1. Mountain Pose (Tadasana)\n2. Downward Dog (Adho Mukha Svanasana)\n3. Child's Pose (Balasana)\n4. Cat-Cow Pose (Marjaryasana)\n\nBắt đầu từ những tư thế này nhé!",
                    TopicId = topics[6].Id,
                    AuthorId = users[3].Id,
                    CreatedDate = DateTime.Now.AddDays(-3),
                    LikeCount = 6
                },
                new Reply
                {
                    Content = "Mình khuyên bạn nên tìm một giáo viên yoga hoặc xem video hướng dẫn để tránh chấn thương.",
                    TopicId = topics[6].Id,
                    AuthorId = users[0].Id,
                    CreatedDate = DateTime.Now.AddMinutes(-15),
                    LikeCount = 2
                },

                // Phản hồi cho chủ đề 8
                new Reply
                {
                    Content = "Lượng nước cần uống phụ thuộc vào cân nặng, hoạt động và thời tiết. Công thức đơn giản: cân nặng (kg) x 30-35ml.\n\nVí dụ: 60kg x 30ml = 1.8 lít/ngày",
                    TopicId = topics[7].Id,
                    AuthorId = users[1].Id,
                    CreatedDate = DateTime.Now.AddDays(-2),
                    LikeCount = 7
                },
                new Reply
                {
                    Content = "Nên uống nước đều đặn trong ngày, không chờ khát mới uống. Uống nhiều nước vào buổi sáng rất tốt!",
                    TopicId = topics[7].Id,
                    AuthorId = users[4].Id,
                    CreatedDate = DateTime.Now.AddMinutes(-10),
                    LikeCount = 3
                },

                // Phản hồi cho chủ đề 9
                new Reply
                {
                    Content = "Thiền định thực sự hiệu quả! Mình tập được 6 tháng rồi, thấy tâm trạng ổn định hơn nhiều.\n\nBắt đầu với 5-10 phút mỗi ngày, tập trung vào hơi thở. Có nhiều app hướng dẫn miễn phí đấy!",
                    TopicId = topics[8].Id,
                    AuthorId = users[0].Id,
                    CreatedDate = DateTime.Now.AddDays(-1),
                    LikeCount = 8
                },
                new Reply
                {
                    Content = "Mình cũng mới bắt đầu thiền định. Khó khăn lúc đầu nhưng kiên trì sẽ thấy hiệu quả. Quan trọng là đều đặn!",
                    TopicId = topics[8].Id,
                    AuthorId = users[2].Id,
                    CreatedDate = DateTime.Now.AddMinutes(-5),
                    LikeCount = 4
                },

                // Phản hồi cho chủ đề 10
                new Reply
                {
                    Content = "Một số bài tập giúp giảm đau lưng:\n\n1. Cat-Cow stretch\n2. Child's pose\n3. Knee to chest stretch\n4. Pelvic tilt\n\nTập 2 lần/ngày, mỗi lần 10-15 phút. Nhớ nghỉ ngơi đủ giấc nhé!",
                    TopicId = topics[9].Id,
                    AuthorId = users[1].Id,
                    CreatedDate = DateTime.Now.AddHours(-12),
                    LikeCount = 5
                },
                new Reply
                {
                    Content = "Bạn nên đứng dậy đi lại mỗi 30-45 phút. Ngồi lâu một chỗ rất hại lưng. Mình đặt báo thức để nhắc nhở.",
                    TopicId = topics[9].Id,
                    AuthorId = users[3].Id,
                    CreatedDate = DateTime.Now.AddMinutes(-2),
                    LikeCount = 3
                }
            };

            context.Replies.AddRange(replies);

            // Cập nhật số lượng phản hồi cho các chủ đề
            topics[0].ReplyCount = 3;
            topics[1].ReplyCount = 2;
            topics[2].ReplyCount = 3;
            topics[3].ReplyCount = 2;
            topics[4].ReplyCount = 2;
            topics[5].ReplyCount = 2;
            topics[6].ReplyCount = 2;
            topics[7].ReplyCount = 2;
            topics[8].ReplyCount = 2;
            topics[9].ReplyCount = 2;

            await context.SaveChangesAsync();

            // Tạo một số likes mẫu
            var topicLikes = new List<TopicLike>();
            var replyLikes = new List<ReplyLike>();

            // Thêm likes cho topics
            for (int i = 0; i < topics.Count; i++)
            {
                var numLikes = topics[i].LikeCount;
                for (int j = 0; j < numLikes && j < users.Count; j++)
                {
                    topicLikes.Add(new TopicLike
                    {
                        TopicId = topics[i].Id,
                        UserId = users[j].Id,
                        CreatedDate = DateTime.Now.AddDays(-i)
                    });
                }
            }

            // Thêm likes cho replies
            for (int i = 0; i < replies.Count; i++)
            {
                var numLikes = replies[i].LikeCount;
                for (int j = 0; j < numLikes && j < users.Count; j++)
                {
                    replyLikes.Add(new ReplyLike
                    {
                        ReplyId = replies[i].Id,
                        UserId = users[j].Id,
                        CreatedDate = DateTime.Now.AddDays(-i)
                    });
                }
            }

            context.TopicLikes.AddRange(topicLikes);
            context.ReplyLikes.AddRange(replyLikes);
            await context.SaveChangesAsync();
        }
    }
}
