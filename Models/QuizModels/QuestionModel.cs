public record QuestionModel : IComparable<QuestionModel>
{
    public string? QuestionText { get; set; }
    public string? CorrectAnswer { get; set; }
    public List<string>? Answers { get; set; }

    public int CompareTo(QuestionModel other)
    {
        if (other == null) return 1;

        int textComparison = string.Compare(QuestionText, other.QuestionText, StringComparison.Ordinal);
        if (textComparison != 0)
        {
            return textComparison;
        }

        return string.Compare(CorrectAnswer, other.CorrectAnswer, StringComparison.Ordinal);
    }
}