public struct QuizMetadataModel
{
    public float PassRate;
    public QuizStatusModel Status { get; set; }
    public DateTime? creationDate { get; set; }
    public DateTime? lastOpened{ get; set; }

    public QuizMetadataModel()
    {
        this.PassRate = 0.0f;
        this.Status = QuizStatusModel.NotStarted;
        this.creationDate = DateTime.Now;
        this.lastOpened = null;
    }
}