using System;
using System.Collections.Generic;

public class QuizModel : QuestionnaireModel, IComparable<QuizModel>
{
    public QuizMetadataModel? Metadata { get; set; }

    public QuizModel()
    {
        this.Metadata = new QuizMetadataModel();
    }


    public int CompareTo(QuizModel other)
    {
        if (other == null) return 1;

        for (int i = 0; i < Questions.Count; i++)
        {
            int questionComparison = Questions[i].CompareTo(other.Questions[i]);
            if (questionComparison != 0)
            {
                return questionComparison;
            }
        }

        return 0;
    }
}