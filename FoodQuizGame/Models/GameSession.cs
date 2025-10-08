using System.ComponentModel.DataAnnotations;

namespace FoodQuizGame.Models;

public class GameSession
{
    [Key]
    public int Id { get; set; }
    
    [Required, StringLength(100)]
    public string PlayerName { get; set; } = string.Empty;
    
    public int Score { get; set; }
    
    public int CurrentQuestionIndex { get; set; } // เพิ่ม field นี้เพื่อติดตามคำถามปัจจุบัน
    
    public int TotalQuestions { get; set; }
    
    public DateTime StartedAt { get; set; }
    
    public DateTime? CompletedAt { get; set; }
    
    public bool IsCompleted { get; set; }
}