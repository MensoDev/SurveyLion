namespace SurveyLion.Polls.Domain.Entities;

public abstract class Question : Entity, IAggregateRoot
{
    public Question(string title, string description, bool isRequired)
    {
        Title = title;
        Description = description;
        IsRequired = isRequired;
    }

    public string Title { get; protected set; }
    public string Description { get; protected set; }
    public bool IsRequired { get; protected set; }
    
}