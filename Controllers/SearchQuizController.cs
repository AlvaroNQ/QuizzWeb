// Controllers/QuizController.cs
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Linq;

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
        var jsonFiles = Directory.EnumerateFiles("./Assets/", "*.json");

        // Deserialize each file content into QuizModel and project into a list.
        var quizzes = jsonFiles.Select(file =>
        {
            string content = System.IO.File.ReadAllText(file);
            return JsonSerializer.Deserialize<QuizModel>(content);
        }).ToList();

        // Find the matching quiz using LINQ
        var matchingQuiz = quizzes.FirstOrDefault(q => q.Title == quizTitle);

        if (matchingQuiz != null)
        {
            // If a quiz is found, update its properties
            matchingQuiz.Metadata = new QuizMetadataModel
            {
                creationDate = matchingQuiz.Metadata.Value.creationDate,
                Status = QuizStatusModel.InProgress,
                lastOpened = DateTime.Now,
            };

            // Find the file path of the matching quiz
            string quizFilePath = jsonFiles.First(file =>
            {
                string content = System.IO.File.ReadAllText(file);
                var quiz = JsonSerializer.Deserialize<QuizModel>(content);
                return quiz.Title == quizTitle;
            });

            // Serialize the updated quiz back to JSON and save it to the file
            string updatedQuizJson = JsonSerializer.Serialize(matchingQuiz);
            System.IO.File.WriteAllText(quizFilePath, updatedQuizJson);

            // Pass the updated quiz into the view
            return View("LoadQuiz", matchingQuiz);
        }

        return Content("Quiz not found");
    }
}


    