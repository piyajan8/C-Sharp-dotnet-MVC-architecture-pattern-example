using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FoodQuizGame.Data;
using FoodQuizGame.Models;
using FoodQuizGame.Models.ViewModels;

namespace FoodQuizGame.Controllers;

public class GameController : Controller
{
    private readonly ApplicationDbContext _context;

    public GameController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Start()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> StartGame(string? playerName)
    {
        var session = new GameSession
        {
            PlayerName = string.IsNullOrWhiteSpace(playerName) ? "Guest" : playerName,
            Score = 0,
            CurrentQuestionIndex = 0, // เริ่มที่คำถามแรก
            TotalQuestions = 5,
            StartedAt = DateTime.Now,
            IsCompleted = false
        };

        _context.GameSessions.Add(session);
        await _context.SaveChangesAsync();

        return RedirectToAction("Play", new { sessionId = session.Id });
    }

    public async Task<IActionResult> Play(int sessionId)
    {
        var session = await _context.GameSessions.FindAsync(sessionId);
        if (session == null || session.IsCompleted)
        {
            return RedirectToAction("Start");
        }

        // ใช้ CurrentQuestionIndex แทน Score เพื่อติดตามคำถามปัจจุบัน
        if (session.CurrentQuestionIndex >= session.TotalQuestions)
        {
            return RedirectToAction("Result", new { sessionId });
        }

        var question = await _context.Questions
            .Where(q => q.OrderIndex == session.CurrentQuestionIndex + 1)
            .FirstOrDefaultAsync();

        if (question == null)
        {
            return RedirectToAction("Result", new { sessionId });
        }

        var viewModel = new QuizViewModel
        {
            SessionId = sessionId,
            CurrentQuestion = question,
            CurrentQuestionNumber = session.CurrentQuestionIndex + 1,
            TotalQuestions = session.TotalQuestions,
            CurrentScore = session.Score,
            PlayerName = session.PlayerName
        };

        return View(viewModel);
    }

    [HttpPost]
    public async Task<IActionResult> SubmitAnswer([FromBody] AnswerRequest request)
    {
        var session = await _context.GameSessions.FindAsync(request.SessionId);
        var question = await _context.Questions.FindAsync(request.QuestionId);

        if (session == null || question == null)
        {
            return Json(new { success = false, message = "Invalid session or question" });
        }

        bool isCorrect = request.SelectedAnswer == question.CorrectAnswer;

        // ถ้าตอบถูกให้เพิ่มคะแนน
        if (isCorrect)
        {
            session.Score++;
        }

        // ไปคำถามถัดไปเสมอ (ไม่ว่าจะตอบถูกหรือผิด)
        session.CurrentQuestionIndex++;

        await _context.SaveChangesAsync();

        return Json(new
        {
            success = true,
            isCorrect = isCorrect,
            correctAnswer = question.CorrectAnswer,
            score = session.Score
        });
    }

    public async Task<IActionResult> Result(int sessionId)
    {
        var session = await _context.GameSessions.FindAsync(sessionId);
        if (session == null)
        {
            return RedirectToAction("Start");
        }

        if (!session.IsCompleted)
        {
            session.IsCompleted = true;
            session.CompletedAt = DateTime.Now;
            await _context.SaveChangesAsync();
        }

        string resultMessage, resultEmoji, resultColor;
        
        if (session.Score == 5)
        {
            resultMessage = "คุณคือปรมาจารย์ด้านอาหาร!";
            resultEmoji = "🎉";
            resultColor = "text-green-500";
        }
        else if (session.Score >= 3)
        {
            resultMessage = "คุณรู้เรื่องอาหารดีเลย";
            resultEmoji = "😊";
            resultColor = "text-blue-500";
        }
        else
        {
            resultMessage = "ฝึกฝนอีกนิดก็เก่งแน่!";
            resultEmoji = "💪";
            resultColor = "text-orange-500";
        }

        var viewModel = new ResultViewModel
        {
            SessionId = sessionId,
            PlayerName = session.PlayerName,
            Score = session.Score,
            TotalQuestions = session.TotalQuestions,
            ResultMessage = resultMessage,
            ResultEmoji = resultEmoji,
            ResultColor = resultColor
        };

        return View(viewModel);
    }
}