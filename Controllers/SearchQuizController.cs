// Controllers/QuizController.cs
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using QuizzWeb.Controllers;

namespace QuizzWeb.Models;
public class SearchQuizController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult LoadQuiz(string quizTitle)
    {
        QuizManager quizManager = new QuizManager();
        QuizModel? quiz = quizManager.searchQuiz(quizTitle);

        if (quiz != null) {
            quizManager.openQuiz(quiz);
            return View("LoadQuiz", quiz);
        }
        return Content("Quiz not found");
    }   
}
