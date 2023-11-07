using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.AccessControl;

namespace QuizzWeb.Controllers
{
    public class PerformQuizController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CheckAnswer(Dictionary<string, string> formValues)
        {
            List<string> userAnswers = new List<string>();
            QuizManager quizManager = new QuizManager();
            QuizModel quiz = quizManager.searchQuiz(formValues["Title"]);
            quizManager.closeQuiz(quiz);



            foreach (string answer in formValues.Values)
            {
                userAnswers.Add(answer);
            }

            int i = 1;
            int countCorrect = 0;
            foreach (MCModel question in quiz.MCQuestions) {
                if (question.CorrectAnswer == userAnswers[i]) {
                    countCorrect++;
                }
                i++;
            }


            return Content($"Correct Answers: " + countCorrect);
        }
    }
}
