using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Text.Json;

namespace QuizzWeb.Controllers
{
    public class SaveQuizController : Controller
    {
        [HttpGet]
        public IActionResult Create()
        {
            Console.Out.WriteLine("OO");
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
            foreach (QuestionModel question in quiz.Questions) {
                question.Answers.Add(question.CorrectAnswer);
            }
            string path = "./Assets/";
            string[] filesInDir = Directory.GetFiles(path, "quiz*.json");
            string fileName = $"quiz{filesInDir.Length + 1}.json";
            string filePath = Path.Combine(path, fileName);

            string json = JsonSerializer.Serialize(quiz, new JsonSerializerOptions{WriteIndented = true});
            System.IO.File.WriteAllText(filePath, json);
        }
    }
}

