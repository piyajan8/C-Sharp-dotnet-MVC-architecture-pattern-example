namespace FoodQuizGame.Models.ViewModels;

public class AnswerRequest
{
    public int SessionId { get; set; }
    public int QuestionId { get; set; }
    public int SelectedAnswer { get; set; }
}