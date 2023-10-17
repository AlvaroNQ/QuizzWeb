using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.IO;

namespace QuizzWeb.Controllers
{
    public class QuizManager
    {
        private QuizModel? Quiz = null;
        private String PathToJsons;
        public QuizManager(string pathToJsons = "Assets")
        {
            this.PathToJsons = pathToJsons;
        }

        public QuizModel? searchQuiz(string quizTitle)
        {
            var jsonFiles = Directory.EnumerateFiles(this.PathToJsons, "*.json");

            foreach (var jsonFile in jsonFiles)
            {
                string jsonContent = File.ReadAllText(jsonFile);
                JObject jsonObj = JObject.Parse(jsonContent);

                if (jsonObj["Title"].ToString() == quizTitle)
                {
                    this.Quiz = jsonObj.ToObject<QuizModel>();
                    return Quiz;
                }
            }
            return this.Quiz;
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
