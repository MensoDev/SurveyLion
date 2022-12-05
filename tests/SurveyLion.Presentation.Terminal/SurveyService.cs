
namespace SurveyLion.Presentation.Terminal;

public class SurveyService
{
    public SurveyService(Survey survey) => Survey = survey;
    private Survey Survey { get; }

    private void SetupTerminal()
    {
        Console.Clear();
        Console.InputEncoding = Encoding.UTF8;
        Console.OutputEncoding = Encoding.UTF8;
        
        Prompt.Symbols.Prompt = new Symbol("🤔", "?");
        Prompt.Symbols.Done = new Symbol("✅", "V");
        Prompt.Symbols.Error = new Symbol("❌", ">>");
        Prompt.Symbols.NotSelect = new Symbol("⬛", "[ ]");
        Prompt.Symbols.Selected = new Symbol("🟩", "[x]");
        Prompt.Symbols.Selector = new Symbol("🟪", "[?]");
        
        Prompt.ColorSchema.Answer = ConsoleColor.Green;
        Prompt.ColorSchema.Select = ConsoleColor.Green;
        Prompt.ColorSchema.Hint = ConsoleColor.DarkCyan;
        
        Console.WriteLine("\n=============================================================");
        Console.WriteLine("=========================Survey Lion=========================");
        Console.WriteLine("=============================================================\n\n");
        Console.WriteLine($"📝 Title: {Survey.Title}");
        Console.WriteLine($"💬 Description: {Survey.Description}");
        Console.WriteLine($"🔗 Link: {Survey.Link}\n\n");
    }

    public SurveySession CreateSurveySession()
    {
        SetupTerminal();

        var session = new SurveySession(Survey);
        
        var count = 0;
        foreach (var question in Survey.Questions)
        {
            Console.WriteLine($"Q: {++count}");
            var controller = ResolverQuestionController(question);
            session.AddAnswer(controller.AnswerQuestion(session));
            Console.WriteLine();
        }

        return session;
    }

    private static IQuestionController ResolverQuestionController(Question question)
    {
        return question switch
        {
            ShortTextQuestion shortTextQuestion => ShortTextQuestionController.CreateController(shortTextQuestion),
            NumberQuestion numberQuestion => NumberQuestionController.CreateController(numberQuestion),
            _ => throw new InvalidOperationException("Error: Question is not identified.")
        };
    }
}