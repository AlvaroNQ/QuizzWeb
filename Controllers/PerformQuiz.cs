using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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

            foreach (var answer in formValues.Values)
            {
                userAnswers.Add(answer);
            }



            return Content($"Selected Answers: {string.Join(", ", userAnswers)}");
        }
    }
}
