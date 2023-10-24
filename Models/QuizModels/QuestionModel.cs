public record QuestionModel : IEquatable<QuestionModel>
{
	public string? QuestionText { get; set; }
	public string? CorrectAnswer { get; set; }
	public List<string>? Answers { get; set; }

	public virtual bool Equals(QuestionModel? other)
	{
		if (other == null) return false;

		if (this.QuestionText != other.QuestionText) return false;
		if (this.CorrectAnswer != other.CorrectAnswer) return false;
		return true;
	}
    public override int GetHashCode()
    {
		return (this.QuestionText, this.CorrectAnswer).GetHashCode();
    }
}