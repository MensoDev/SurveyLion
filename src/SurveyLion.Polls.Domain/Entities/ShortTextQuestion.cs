namespace SurveyLion.Polls.Domain.Entities;

public class ShortTextQuestion : Question
{
    public ShortTextQuestion(string title, string description, bool isRequired) 
        : base(title, description, isRequired)
    {
        Validate();
    }

    public string Answer { get; private set; }
    
    protected sealed override void Validate()
    {
        throw new NotImplementedException();
    }
}