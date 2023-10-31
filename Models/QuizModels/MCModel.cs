using QuizzWeb.Models.QuizModels;

public record MCModel: QuestionBase
{
    public string QuestionText { get ; set; }
	public string CorrectAnswer { get; set; }
	public List<string>? Answers { get; set; }

    public bool IsCorrectAnswer(string userAnswer)
    {
        throw new NotImplementedException();
    }

    public object ToModel()
    {
        return this;
    }
}