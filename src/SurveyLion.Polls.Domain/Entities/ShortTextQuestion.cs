using SurveyLion.Polls.Domain.Enums;

namespace SurveyLion.Polls.Domain.Entities;

public class ShortTextQuestion : Question
{
    public ShortTextQuestion(string title, string description, bool isRequired, Survey survey, int maxLenght = 100) 
        : base(title, description, isRequired, QuestionType.ShortText, survey)
    {
        MaxLenght = maxLenght;
        Validate();
    }

    public int MaxLenght { get; private set; }

    public ShortTextAnswer AnswerQuestion(SurveySession surveySession, string text)
    {
        DomainAssertionConcernException.AssertArgumentIsGreaterThan(
            text, 
            MaxLenght, 
            string.Format(Strings.AnswerMessages.TextIsLessThanMessage, MaxLenght));

        return new ShortTextAnswer(surveySession, this, text);
    }
    
    protected sealed override void Validate()
    {
        DomainAssertionConcernException.AssertArgumentIsGreaterThan(
            MaxLenght, 
            0,
            Strings.ShortTextQuestionMessages.WhenMaxLenghtIsGreaterThanMessage
        );
        
        DomainAssertionConcernException.AssertArgumentEquals(
            Type, 
            QuestionType.ShortText,
            Strings.ShortTextQuestionMessages.WhenMaxLenghtIsGreaterThanMessage
        );
    }
}