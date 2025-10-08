namespace FoodQuizGame.Models.ViewModels;

public class ResultViewModel
{
    public int SessionId { get; set; }
    public string PlayerName { get; set; } = string.Empty;
    public int Score { get; set; }
    public int TotalQuestions { get; set; }
    public string ResultMessage { get; set; } = string.Empty;
    public string ResultEmoji { get; set; } = string.Empty;
    public string ResultColor { get; set; } = string.Empty;
}