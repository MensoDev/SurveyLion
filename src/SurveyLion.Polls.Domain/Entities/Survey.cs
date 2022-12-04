namespace SurveyLion.Polls.Domain.Entities;

using Messages = Strings.SurveyMessages;

public class Survey : Entity, IAggregateRoot
{
    private readonly List<Question> _questions = new ();
    private readonly List<SurveySession> _surveySessions = new ();
    
    public Survey(string title, string description)
    {
        Title = title;
        Description = description;
        Link = $"survey/{Id}/answer";
        
        Validate();
    }
    
    public string Title { get; private set; }
    public string Description { get; private set; }
    public string Link { get; private set; }

    public IReadOnlyCollection<Question> Questions => _questions;
    public IReadOnlyCollection<SurveySession> SurveySessions => _surveySessions;

    public void AddQuestion(Question question)
    {
        _questions.Add(question);
    }
    
    public void AddSurveySession(SurveySession surveySession)
    {
        _surveySessions.Add(surveySession);
    }
    
    protected sealed override void Validate()
    {
        DomainAssertionConcernException.AssertArgumentNotEmpty(Title, Messages.TitleIsRequiredMessage);
        DomainAssertionConcernException.AssertArgumentIsGreaterThan(Title, 3, Messages.TitleIsCannotBeLessThanMessage);
        DomainAssertionConcernException.AssertArgumentNotEmpty(Description, Messages.DescriptionIsRequiredMessage);
        DomainAssertionConcernException.AssertArgumentNotEmpty(Link, Messages.LinkIsRequiredMessage);
    }
}