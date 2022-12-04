using SurveyLion.Polls.Domain.Enums;

using Messages = SurveyLion.Polls.Domain.Strings.QuestionMessages;
using AssertionConcern = SurveyLion.Kernel.Domain.Exceptions.DomainAssertionConcernException;

namespace SurveyLion.Polls.Domain.Entities;

public abstract class Question : Entity, IAggregateRoot
{
    protected Question(string title, string description, bool isRequired, QuestionType type, Survey survey)
    {
        AssertionConcern.AssertArgumentNotNull(survey, Messages.SurveyIsRequiredMessage);
        
        Title = title;
        
        Description = description;
        IsRequired = isRequired;
        Type = type;
        
        SurveyId = survey.Id;
        Survey = survey;

        ValidateInternal();
    }

    public string Title { get; protected set; }
    public string Description { get; protected set; }
    public bool IsRequired { get; protected set; }
    public QuestionType Type { get; private init; }

    public Guid SurveyId { get; private init; }
    public Survey Survey { get; private init; }

    private void ValidateInternal()
    {
        AssertionConcern.AssertArgumentNotEmpty(Title, Messages.TitleIsRequiredMessage);
        AssertionConcern.AssertArgumentIsGreaterThan(Title, 3, Messages.TitleIsGreaterThanMessage);
        AssertionConcern.AssertArgumentNotEmpty(SurveyId, Messages.SurveyIdIsRequiredMessage);
        AssertionConcern.AssertArgumentNotEmpty(Description, Messages.DescriptionRequiredMessage);
    }
}