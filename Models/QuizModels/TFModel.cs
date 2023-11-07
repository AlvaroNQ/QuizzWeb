using QuizzWeb.Models.QuizModels;
using System;

namespace QuizzWeb.Models.QuizModels
{
    public sealed record TFModel : QuestionBase, IEquatable<TFModel>
    {
        public string? QuestionText { get; set; }
        public bool Answer { get; set; }

        public bool IsCorrectAnswer(string userAnswer)
        {
            throw new NotImplementedException();
        }

        public bool Equals(TFModel other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return string.Equals(QuestionText, other.QuestionText, StringComparison.OrdinalIgnoreCase) &&
                   Answer == other.Answer;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = StringComparer.OrdinalIgnoreCase.GetHashCode(QuestionText);
                hashCode = (hashCode * 397) ^ Answer.GetHashCode();
                return hashCode;
            }
        }
    }
}
