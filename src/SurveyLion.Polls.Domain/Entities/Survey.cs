namespace SurveyLion.Polls.Domain.Entities;

public class Survey : Entity, IAggregateRoot
{
    public Survey(string title, string description, string link)
    {
        Title = title;
        Description = description;
        Link = link;
        
        Validate();
    }
    
    public string Title { get; private set; }
    public string Description { get; private set; }
    public string Link { get; private set; }
    
    protected sealed override void Validate()
    {
        throw new NotImplementedException();
    }
}