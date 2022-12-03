using SurveyLion.Kernel.Domain.Exceptions;
using SurveyLion.Polls.Domain.Enums;

using Messages = SurveyLion.Polls.Domain.Strings.QuestionMessages;

namespace SurveyLion.Polls.Domain.Entities;

public abstract class Question : Entity, IAggregateRoot
{
    protected Question(string title, string description, bool isRequired, Guid surveyId, QuestionType type)
    {
        Title = title;
        Description = description;
        IsRequired = isRequired;
        SurveyId = surveyId;
        Type = type;

        ValidateInternal();
    }

    public string Title { get; protected set; }
    public string Description { get; protected set; }
    public bool IsRequired { get; protected set; }
    public Guid SurveyId { get; protected init; }
    public QuestionType Type { get; private init; }

    private void ValidateInternal()
    {
        DomainAssertionConcernException.AssertArgumentNotEmpty(Title, Messages.TitleIsRequiredMessage);
        DomainAssertionConcernException.AssertArgumentIsGreaterThan(Title, 3, Messages.TitleIsGreaterThanMessage);
        DomainAssertionConcernException.AssertArgumentNotEmpty(SurveyId, Messages.SurveyIdIsRequiredMessage);
    }
}