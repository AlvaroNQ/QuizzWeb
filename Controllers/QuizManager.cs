using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Text.Json;
using System.Linq;
using Microsoft.VisualBasic;
using System;

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
            List<QuizModel> jsonQuizzes = new List<QuizModel>();

            foreach (var jsonFile in jsonFiles)
            {
                string jsonContent = File.ReadAllText(jsonFile);
                JObject jsonObj = JObject.Parse(jsonContent);

                jsonQuizzes.Add(jsonObj.ToObject<QuizModel>());
            }

            this.Quiz = jsonQuizzes.FirstOrDefault(q => q.Title == quizTitle);

            if (this.Quiz == null)
                return null;


            return this.Quiz;
        }


        public void openQuiz(QuizModel quiz, string path = "Assets") {
            string jsonContent = File.ReadAllText(path + "/" + quiz.Metadata.CreationInfo.FileName);
            JObject jsonObj = JObject.Parse(jsonContent);

            jsonObj["Metadata"]["Status"] = QuizStatusModel.InProgress.ToString();
            jsonObj["Metadata"]["lastOpened"] = DateTime.Now;

            File.WriteAllText(path + "/" + quiz.Metadata.CreationInfo.FileName, jsonObj.ToString());
        }

        internal void closeQuiz(QuizModel quiz, string path = "Assets")
        {
            string jsonContent = File.ReadAllText(path + "/" + quiz.Metadata.CreationInfo.FileName);
            JObject jsonObj = JObject.Parse(jsonContent);

            jsonObj["Metadata"]["Status"] = QuizStatusModel.Completed.ToString();
            jsonObj["Metadata"]["lastOpened"] = DateTime.Now;

            File.WriteAllText(path + "/" + quiz.Metadata.CreationInfo.FileName, jsonObj.ToString());

        }
    }
}
