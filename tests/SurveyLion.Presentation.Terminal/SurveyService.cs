using System.Text;

namespace SurveyLion.Presentation.Terminal;

public class SurveyService
{
    public SurveyService(Survey survey) => Survey = survey;
    private Survey Survey { get; }

    public SurveySession CreateSurveySession()
    {
        Console.Clear();
        Console.InputEncoding = Encoding.UTF8;
        Console.OutputEncoding = Encoding.UTF8;
        
        Console.WriteLine("=============================================================");
        Console.WriteLine("=========================Survey Lion=========================");
        Console.WriteLine("=============================================================\n\n");
        Console.WriteLine($"==> Title: {Survey.Title}");
        Console.WriteLine($"==> Description: {Survey.Description}");
        Console.WriteLine($"==> Link: {Survey.Link}\n\n");

        var session = new SurveySession(Survey);
        
        var count = 0;
        foreach (var question in Survey.Questions)
        {
            Console.WriteLine($"Q: {++count}");
            var controller = ResolverQuestionController(question);
            session.AddAnswer(controller.AnswerQuestion(session));
            Console.WriteLine("\n");
        }

        return session;
    }

    private static IQuestionController ResolverQuestionController(Question question)
    {
        return question switch
        {
            ShortTextQuestion shortTextQuestion => ShortTextQuestionController.CreateController(shortTextQuestion),
            _ => throw new InvalidOperationException("Error: Question is not identified.")
        };
    }
}