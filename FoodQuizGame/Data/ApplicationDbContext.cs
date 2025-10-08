using Microsoft.EntityFrameworkCore;
using FoodQuizGame.Models;

namespace FoodQuizGame.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Question> Questions { get; set; }
    public DbSet<GameSession> GameSessions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Question>().HasData(
            new Question
            {
                Id = 1,
                QuestionText = "อาหารไทยชนิดไหนที่มีส่วนผสมของกะทิ น้ำตาล และเครื่องเทศ?",
                Option1 = "ต้มยำกุ้ง",
                Option2 = "แกงเขียวหวาน",
                Option3 = "มัสมั่นไก่",
                Option4 = "ส้มตำ",
                CorrectAnswer = 2, // มัสมั่นไก่
                Emoji = "🍛",
                OrderIndex = 1
            },
            new Question
            {
                Id = 2,
                QuestionText = "ผลไม้ชนิดใดที่ขึ้นชื่อว่าเป็น 'ราชาแห่งผลไม้'?",
                Option1 = "มังคุด",
                Option2 = "ทุเรียน",
                Option3 = "ลำไย",
                Option4 = "ลิ้นจี่",
                CorrectAnswer = 1, // ทุเรียน
                Emoji = "👑",
                OrderIndex = 2
            },
            new Question
            {
                Id = 3,
                QuestionText = "ของหวานไทยชนิดไหนที่ทำจากไข่แดงและน้ำตาล?",
                Option1 = "ขนมชั้น",
                Option2 = "ฝอยทอง",
                Option3 = "บัวลอย",
                Option4 = "ขนมครก",
                CorrectAnswer = 1, // ฝอยทอง
                Emoji = "🍮",
                OrderIndex = 3
            },
            new Question
            {
                Id = 4,
                QuestionText = "อาหารจานด่วนที่มีต้นกำเนิดจากอิตาลีคืออะไร?",
                Option1 = "เบอร์เกอร์",
                Option2 = "พิซซ่า",
                Option3 = "ทาโก้",
                Option4 = "ซูชิ",
                CorrectAnswer = 1, // พิซซ่า
                Emoji = "🍕",
                OrderIndex = 4
            },
            new Question
            {
                Id = 5,
                QuestionText = "เครื่องดื่มชนิดใดที่ได้จากการหมักใบชา?",
                Option1 = "กาแฟ",
                Option2 = "โกโก้",
                Option3 = "ชาเขียว",
                Option4 = "โซดา",
                CorrectAnswer = 2, // ชาเขียว
                Emoji = "🍵",
                OrderIndex = 5
            }
        );
    }
}