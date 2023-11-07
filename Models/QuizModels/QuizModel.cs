using QuizzWeb.Models.QuizModels;
using System;
using System.Collections.Generic;

public class QuizModel: QuestionnaireModel
{
	public QuizMetadataModel? Metadata { get; set; }
    
    public QuizModel()
	{
		this.Metadata = new QuizMetadataModel();
	}
	
    public void RemoveDuplicates()
    {
		Metadata.edited();
        //this.MCQuestions.RemoveDuplicates();
        this.TFQuestions.RemoveDuplicates();

    }
    public void AddQuestion<T>(T question) where T : QuestionBase
    {
        if (question is MCModel mcQuestion)
        {
            MCQuestions?.Add(mcQuestion);
        }
        else if (question is TFModel tfQuestion)
        {
            TFQuestions?.Add(tfQuestion);
        }
    }

    public void RemoveQuestion<T>(T question) where T : QuestionBase
    {
        if (question is MCModel mcQuestion)
        {
            MCQuestions?.Remove(mcQuestion);
        }
        else if (question is TFModel tfQuestion)
        {
            TFQuestions?.Remove(tfQuestion);
        }
    }


}
