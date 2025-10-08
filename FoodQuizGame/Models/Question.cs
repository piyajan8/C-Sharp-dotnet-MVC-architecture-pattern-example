using System.ComponentModel.DataAnnotations;

namespace FoodQuizGame.Models;

public class Question
{
    [Key]
    public int Id { get; set; }
    
    [Required, StringLength(500)]
    public string QuestionText { get; set; } = string.Empty;
    
    [Required, StringLength(200)]
    public string Option1 { get; set; } = string.Empty;
    
    [Required, StringLength(200)]
    public string Option2 { get; set; } = string.Empty;
    
    [Required, StringLength(200)]
    public string Option3 { get; set; } = string.Empty;
    
    [Required, StringLength(200)]
    public string Option4 { get; set; } = string.Empty;
    
    [Required]
    public int CorrectAnswer { get; set; }
    
    [StringLength(10)]
    public string Emoji { get; set; } = string.Empty;
    
    public int OrderIndex { get; set; }
}