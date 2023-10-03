using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Text.Json;

namespace QuizzWeb.Controllers
{
    public class SaveQuizzController : Controller
    {
        [HttpGet]
        public IActionResult Create()
        {
            Console.Out.WriteLine("OO");
            return View();
        }

        [HttpPost]
        public IActionResult Save(QuizViewModel quiz)
        {
            SaveQuizzJson(quiz);
            return RedirectToAction("Index", "Home"); // Redirect to the main page after saving
        }

        private void SaveQuizzJson(QuizViewModel quizz)
        {
            string path = "./Assets/";
            string[] filesInDir = Directory.GetFiles(path, "quizz*.json");
            string fileName = $"quizz{filesInDir.Length + 1}.json";
            string filePath = Path.Combine(path, fileName);

            string json = JsonSerializer.Serialize(quizz, new JsonSerializerOptions{WriteIndented = true});
            System.IO.File.WriteAllText(filePath, json);
        }
    }
}

