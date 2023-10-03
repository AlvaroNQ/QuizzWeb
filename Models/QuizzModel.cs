public class QuizViewModel
{
    public string title { get; set; }
    public List<QuestionViewModel> questions { get; set; }
}

public class QuestionViewModel
{
    public string questionText { get; set; }
    public string correctAnswer { get; set; }
    public List<string> answers { get; set; }
}
