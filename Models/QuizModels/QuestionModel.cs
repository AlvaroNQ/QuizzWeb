public record QuestionModel
{
    public string? QuestionText { get; set; }
    public string? CorrectAnswer { get; set; }
    public List<string>? Answers { get; set; }
}