using System;
using System.Collections.Generic;

public class QuizModel : QuestionnaireModel, IEquatable<QuizModel>
{
	public QuizMetadataModel? Metadata { get; set; }

	public QuizModel()
	{
		this.Metadata = new QuizMetadataModel();
	}

	public bool Equals(QuizModel other)
	{
		if (other == null) return false;
		if (this.Title != other.Title) return false;
		if (other.Questions == null && this.Questions == null) return true;
		if (other.Questions == null || this.Questions == null) return false;
		if (this.Questions.Count != other.Questions.Count) return false;

		foreach (QuestionModel question in this.Questions)
		{
			bool sameQuestion = false;
			foreach (QuestionModel question2 in other.Questions)
			{
				if (question.Equals(question2)) 
				{
                    sameQuestion = true;
					break;
                }
			}
			if (sameQuestion == false) return false;
		}
		// every question has an equivalent question since it never returned false at the previous line
		return true;
	}
}

public static class QuizListExtensions
{
	// This method will extend standard class List<QuizModel>
	public static string Summarize(this List<QuizModel> quizList)
	{
		int totalQuizzes = quizList.Count;
		int totalQuestions = quizList.Sum(q => q.Questions?.Count ?? 0);
		float averagePassRate = quizList.Average(q => q.Metadata?.PassRate ?? 0.0f);

		return $"Total quizzes: {totalQuizzes}, Total questions: {totalQuestions}, Average pass rate: {averagePassRate}";
	}
}