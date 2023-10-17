
public class QuizModel : QuestionnaireModel
{
    public QuizMetadataModel? Metadata { get; set; }

    public QuizModel()
    {
        this.Metadata = new QuizMetadataModel();
    }
}

