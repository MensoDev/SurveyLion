namespace SurveyLion.Presentation.Terminal;

public class NumberQuestionController : IQuestionController
{
    private static NumberQuestionController? _controller;
    private NumberQuestion _numberQuestion;
    
    private NumberQuestionController(NumberQuestion question) => _numberQuestion = question;
    private void ChangeQuestion(NumberQuestion question) => _numberQuestion = question;

    public Answer AnswerQuestion(SurveySession surveySession)
    {
        var validators = new[]
        {
            QuestionValidators.Max(_numberQuestion.Max), 
            QuestionValidators.Min(_numberQuestion.Min)
        }.ToList();

        if (_numberQuestion.IsRequired) { validators.Add(Validators.Required()); }
        
        var number = Prompt.Input<int>(
            message: _numberQuestion.Title, 
            placeholder: _numberQuestion.Description, 
            validators: validators);

        return _numberQuestion.AnswerQuestion(surveySession, number);
    }

    public static NumberQuestionController CreateController(NumberQuestion question)
    {
        if (_controller is null)
        {
            _controller = new NumberQuestionController(question);
        }
        else
        {
            _controller.ChangeQuestion(question);
        }

        return _controller;
    }
}