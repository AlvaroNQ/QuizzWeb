using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace QuizzWeb.Controllers
{
    public class QuizManager
    {
        public QuizModel? searchQuiz(string quizTitle)
        {
            var jsonFiles = Directory.EnumerateFiles("Assets", "*.json");

            foreach (var jsonFile in jsonFiles)
            {
                string jsonContent = System.IO.File.ReadAllText(jsonFile);
                JObject jsonObj = JObject.Parse(jsonContent);

                if (jsonObj["Title"].ToString() == quizTitle)
                {
                    //Quiz is opened
                    jsonObj["Metadata"]["Status"] = QuizStatusModel.InProgress.ToString();
                    jsonObj["Metadata"]["lastOpened"] = DateTime.Now;

                    System.IO.File.WriteAllText(jsonFile, jsonObj.ToString());
                    QuizModel quizModel = jsonObj.ToObject<QuizModel>();

                    return quizModel;
                }
            }
            return null;
        }

        public void openQuiz() { 
        
        }
    }
}
