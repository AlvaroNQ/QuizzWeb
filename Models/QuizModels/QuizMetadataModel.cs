public struct QuizMetadataModel
{
    public string? FileName { get; set; }
    public float PassRate { get; set; }
    public QuizStatusModel Status { get; set; }
    public DateTime? creationDate { get; set; }
    public DateTime? lastOpened{ get; set; }

    public QuizMetadataModel(string? FileName = null)
    {
        this.PassRate = 0.0f;
        this.Status = QuizStatusModel.NotStarted;
        this.creationDate = DateTime.Now;
        this.lastOpened = null;
        this.FileName = FileName;
}
}