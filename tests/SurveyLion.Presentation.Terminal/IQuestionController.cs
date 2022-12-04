namespace SurveyLion.Presentation.Terminal;

public interface IQuestionController
{
    public Answer AnswerQuestion(SurveySession surveySession);
}