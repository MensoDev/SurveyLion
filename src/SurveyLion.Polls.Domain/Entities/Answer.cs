using Messages = SurveyLion.Polls.Domain.Strings.AnswerMessages;

namespace SurveyLion.Polls.Domain.Entities;

public abstract class Answer : Entity, IAggregateRoot
{
    protected Answer(SurveySession surveySession, Question question)
    {
        DomainAssertionConcernException.AssertArgumentNotNull(question, Messages.QuestionIdIsRequiredMessage);
        DomainAssertionConcernException.AssertArgumentNotNull(surveySession, Messages.SurveySessionIsRequiredMessage);
        
        QuestionId = question.Id;
        Question = question;
        
        SurveySession = surveySession;
        SurveySessionId = surveySession.Id;

        AnsweredIn = DateTime.Now;

        ValidationInternal();
    }
    
    public DateTime AnsweredIn { get; private init; }

    public Guid QuestionId { get; private init; }
    public Question Question { get; private init; }
    
    public Guid SurveySessionId { get; private init; }
    public SurveySession SurveySession { get; private init; }

    private void ValidationInternal()
    {
        DomainAssertionConcernException.AssertArgumentNotEmpty(QuestionId, Messages.QuestionIdIsRequiredMessage);
    }
}