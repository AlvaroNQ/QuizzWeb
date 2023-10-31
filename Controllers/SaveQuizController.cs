using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace QuizzWeb.Controllers
{
    public class SaveQuizController : Controller
    {
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Save(QuizModel quiz)
        {

            SaveQuizJson(quiz);
            return RedirectToAction("Index", "Home"); // Redirect to the main page after saving
        }

        private void SaveQuizJson(QuizModel quiz)
        {
            foreach (var question in quiz.MCQuestion) {
                question.Answers?.Insert(0, question.CorrectAnswer);
            }

            string path = "./Assets/";
            string[] filesInDir = Directory.GetFiles(path, "quiz*.json");
            string fileName = $"quiz{filesInDir.Length + 1}.json";
            string filePath = Path.Combine(path, fileName);
            
            QuizMetadataModel metadata = new QuizMetadataModel(fileName);
            quiz.Metadata = metadata;

            string json = JsonSerializer.Serialize(quiz, new JsonSerializerOptions{WriteIndented = true});
            System.IO.File.WriteAllText(filePath, json);
        }
    }
}

