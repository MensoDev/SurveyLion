namespace SurveyLion.Polls.Domain.Entities;

public class ShortTextAnswer : Answer
{
    public ShortTextAnswer(SurveySession surveySession, Question question, string text) : base(surveySession, question)
    {
        Text = text;
        Validate();
    }

    public string Text { get; private init; }

    protected sealed override void Validate()
    {
        if (Question.IsRequired)
        {
            DomainAssertionConcernException.AssertArgumentNotEmpty(
                Text,
                Strings.AnswerMessages.TextIsRequiredMessage);
        }
    }
}