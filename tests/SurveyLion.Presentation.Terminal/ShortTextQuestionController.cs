namespace SurveyLion.Presentation.Terminal;

public sealed class ShortTextQuestionController : IQuestionController
{
    private static ShortTextQuestionController? _controller;
    private ShortTextQuestion _shortTextQuestion;
    
    private ShortTextQuestionController(ShortTextQuestion question) => _shortTextQuestion = question;
    private void ChangeQuestion(ShortTextQuestion question) => _shortTextQuestion = question;

    public Answer AnswerQuestion(SurveySession surveySession)
    {
        var validators = new[] { Validators.MaxLength(_shortTextQuestion.MaxLenght)  }.ToList();

        if (_shortTextQuestion.IsRequired) { validators.Add(Validators.Required()); }
        
        var text = Prompt.Input<string>(
            message: _shortTextQuestion.Title, 
            placeholder: _shortTextQuestion.Description, 
            validators: validators);

        return new ShortTextAnswer(surveySession, _shortTextQuestion, text);
    }

    public static ShortTextQuestionController CreateController(ShortTextQuestion question)
    {
        if (_controller is null)
        {
            _controller = new ShortTextQuestionController(question);
        }
        else
        {
            _controller.ChangeQuestion(question);
        }

        return _controller;
    }
}