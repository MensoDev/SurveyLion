using SurveyLion.Kernel.Domain.Exceptions;
using SurveyLion.Polls.Domain.Enums;

namespace SurveyLion.Polls.Domain.Entities;

public class ShortTextQuestion : Question
{
    public ShortTextQuestion(string title, string description, bool isRequired, Guid surveyId, int maxLenght = 100) 
        : base(title, description, isRequired, surveyId, QuestionType.ShortText)
    {
        MaxLenght = maxLenght;
        Validate();
    }

    public int MaxLenght { get; private set; }
    
    protected sealed override void Validate()
    {
        DomainAssertionConcernException.AssertArgumentIsGreaterThan(
            MaxLenght, 
            0,
            Strings.ShortTextQuestionMessages.WhenMaxLenghtIsGreaterThanMessage
        );
    }
}