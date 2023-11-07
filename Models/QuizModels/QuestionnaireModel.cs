using QuizzWeb.Models.QuizModels;
using System.Collections;

public class QuestionnaireModel
{
    public string? Title { get; set; }
    public List<MCModel>? MCQuestions { get; set; }
    public List<TFModel>? TFQuestions { get; set; }
}