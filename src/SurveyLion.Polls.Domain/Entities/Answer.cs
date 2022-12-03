using SurveyLion.Kernel.Domain.Exceptions;

using Messages = SurveyLion.Polls.Domain.Strings.AnswerMessages;

namespace SurveyLion.Polls.Domain.Entities;

public abstract class Answer : Entity, IAggregateRoot
{
    protected Answer(Guid questionId)
    {
        QuestionId = questionId;
        AnsweredIn = DateTime.Now;

        ValidationInternal();
    }

    public Guid QuestionId { get; private init; }
    public DateTime AnsweredIn { get; private init; }

    private void ValidationInternal()
    {
        DomainAssertionConcernException.AssertArgumentNotEmpty(QuestionId, Messages.QuestionIdIsRequiredMessage);
    }
}