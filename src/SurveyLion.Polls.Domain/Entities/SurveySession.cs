namespace SurveyLion.Polls.Domain.Entities;

using Messages = Strings.SurveySessionMessages;

public class SurveySession : Entity, IAggregateRoot
{
    private readonly List<Answer> _answers = new ();

    public SurveySession(Survey survey)
    {
        DomainAssertionConcernException.AssertArgumentNotNull(survey, Messages.SurveyIsRequiredMessage);
        
        SurveyId = survey.Id;
        Survey = survey;
    }

    public IReadOnlyCollection<Answer> Answers => _answers;

    public Guid SurveyId { get; private init; }
    public Survey Survey { get; private init; }
    
    
    public void AddAnswer(Answer answer)
    {
        _answers.Add(answer);
    }

    protected sealed override void Validate()
    {
        throw new NotImplementedException();
    }
}