namespace FoodQuizGame.Models.ViewModels;

public class QuizViewModel
{
    public int SessionId { get; set; }
    public Question CurrentQuestion { get; set; } = new();
    public int CurrentQuestionNumber { get; set; }
    public int TotalQuestions { get; set; }
    public int CurrentScore { get; set; }
    public string PlayerName { get; set; } = string.Empty;
}