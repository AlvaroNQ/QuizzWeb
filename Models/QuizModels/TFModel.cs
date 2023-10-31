namespace QuizzWeb.Models.QuizModels
{
    public record TFModel : QuestionBase
    {
        public string QuestionText { get; set; }
        public bool Answer { get; set; }

        public bool IsCorrectAnswer(string userAnswer)
        {
            throw new NotImplementedException();
        }
    }
}