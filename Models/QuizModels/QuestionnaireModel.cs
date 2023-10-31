using QuizzWeb.Models.QuizModels;
using System.Collections;

public class QuestionnaireModel
{
    public string? Title { get; set; }
    public List<MCModel>? MCQuestion { get; set; }
    public List<TFModel>? TFQuestion { get; set; }

    public void AddQuestion<T>(T question) where T : QuestionBase
    {
        if (question is MCModel mcQuestion)
        {
            MCQuestion?.Add(mcQuestion);
        }
        else if (question is TFModel tfQuestion)
        {
            TFQuestion?.Add(tfQuestion);
        }
    }

    public void RemoveQuestion<T>(T question) where T : QuestionBase
    {
        if (question is MCModel mcQuestion)
        {
            MCQuestion?.Remove(mcQuestion);
        }
        else if (question is TFModel tfQuestion)
        {
            TFQuestion?.Remove(tfQuestion);
        }
    }
}