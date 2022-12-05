namespace SurveyLion.Polls.Domain.Entities;

using Messages = Strings.NumberAnswerMessages;

public sealed class NumberAnswer : Answer
{
    public NumberAnswer(SurveySession surveySession, Question question, int? number) : base(surveySession, question)
    {
        Number = number;
        
        Validate();
    }

    public int? Number { get; private set; }

    protected override void Validate()
    {
        if (Question.IsRequired)
        {
            DomainAssertionConcernException.AssertArgumentNotNull(Number, Messages.NumberIsRequiredMessage);
        }
    }
}