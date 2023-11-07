namespace QuizzWeb.Models.QuizModels
{
    public interface QuestionBase
    {
        public string QuestionText { get; set; }

        bool Equals(object obj);
        public bool IsCorrectAnswer(string userAnswer);

    }
}
