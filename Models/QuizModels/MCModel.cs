using Microsoft.AspNetCore.Server.IIS.Core;
using QuizzWeb.Models.QuizModels;
using System;
using System.Collections.Generic;

public sealed record MCModel : QuestionBase, IEquatable<MCModel>
{
    public string QuestionText { get; set; }
    public string CorrectAnswer { get; set; }
    public List<string>? Answers { get; set; }

    public bool IsCorrectAnswer(string userAnswer)
    {
        throw new NotImplementedException();
    }

    public bool Equals(MCModel other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;

        return string.Equals(QuestionText, other.QuestionText, StringComparison.OrdinalIgnoreCase) &&
               string.Equals(CorrectAnswer, other.CorrectAnswer, StringComparison.OrdinalIgnoreCase) &&
               (Answers?.SequenceEqual(other.Answers, StringComparer.OrdinalIgnoreCase) ?? other.Answers == null);
    }
}
