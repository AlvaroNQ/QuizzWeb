using QuizzWeb.Models.QuizModels;

public class QuizMetadataModel
{  
    public CreationInfo CreationInfo;
    public float PassRate { get; set; }
    public QuizStatusModel Status { get; set; }
    public DateTime? LastEdited { get; set; }
    public DateTime? LastOpened{ get; set; }

    public QuizMetadataModel(string? fileName=null)
    {
        this.CreationInfo = new CreationInfo(fileName);
        this.PassRate = 0.0f;
        this.Status = QuizStatusModel.NotStarted;
        this.LastEdited = null;
        this.LastOpened = null;
    }
    public void edited()
    {
        this.LastEdited = DateTime.Now;
    }
}