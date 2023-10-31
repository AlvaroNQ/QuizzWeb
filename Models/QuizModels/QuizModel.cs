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
	
    public void AddQuestion<T>(T newQuestion)
    {
		Metadata.edited();
        this.AddQuestion(newQuestion);
    }

	public void RemoveQuestion<T>(T newQuestion)
    {
		Metadata.edited();
        this.AddQuestion(newQuestion);
    }


}
