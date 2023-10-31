namespace QuizzWeb.Models.QuizModels
{
    public interface QuestionBase
    {
        public string QuestionText { get; set; }
        public bool IsCorrectAnswer(string userAnswer);

    }
}
