using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Text.Json;
using System.Linq;

namespace QuizzWeb.Controllers
{
    public class QuizManager
    {
        private QuizModel? Quiz = null;
        private String PathToJsons;
        public QuizManager(string pathToJsons = "./Assets/")
        {
            this.PathToJsons = pathToJsons;
        }

        public QuizModel? searchQuiz(string quizTitle)
        {
            var jsonFiles = Directory.EnumerateFiles(this.PathToJsons, "*.json");

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
            }

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

            // Pass the name of the quiz into the view
            return matchingQuiz;
        }

        public void openQuiz(QuizModel quiz, string path = "Assets") {
            string jsonContent = File.ReadAllText(path + "/" + quiz.Metadata.Value.FileName);
            JObject jsonObj = JObject.Parse(jsonContent);

            jsonObj["Metadata"]["Status"] = QuizStatusModel.InProgress.ToString();
            jsonObj["Metadata"]["lastOpened"] = DateTime.Now;

            File.WriteAllText(path + "/" + quiz.Metadata.Value.FileName, jsonObj.ToString());
        }

        internal void closeQuiz(QuizModel quiz, string path = "Assets")
        {
            string jsonContent = File.ReadAllText(path + "/" + quiz.Metadata.Value.FileName);
            JObject jsonObj = JObject.Parse(jsonContent);

            jsonObj["Metadata"]["Status"] = QuizStatusModel.Completed.ToString();
            jsonObj["Metadata"]["lastOpened"] = DateTime.Now;

            File.WriteAllText(path + "/" + quiz.Metadata.Value.FileName, jsonObj.ToString());

        }
    }
}
