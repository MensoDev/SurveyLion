using SurveyLion.Polls.Domain.Enums;

using Messages = SurveyLion.Polls.Domain.Strings.NumberQuestionMessages;

namespace SurveyLion.Polls.Domain.Entities;

public sealed class NumberQuestion : Question
{
    public NumberQuestion(string title, string description, bool isRequired, int min, int max, Survey survey) 
        : base(title, description, isRequired, QuestionType.Number, survey)
    {
        Min = min;
        Max = max;
        Validate();
    }

    public int Min { get; private set; }
    public int Max { get; private set; }
    
    public NumberAnswer AnswerQuestion(SurveySession surveySession, int? number)
    {
        if (!number.HasValue) return new NumberAnswer(surveySession, this, number);
        
        DomainAssertionConcernException.AssertArgumentIsGreaterThan(
            number.Value, 
            Min, 
            Messages.NumberMustBeGreaterThanMessage);
        
        DomainAssertionConcernException.AssertArgumentIsLessThan(
            number.Value, 
            Max, 
            Messages.NumberMustBeLessThanMessage);

        return new NumberAnswer(surveySession, this, number);
    }

    protected override void Validate() { }
}