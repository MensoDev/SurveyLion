
namespace SurveyLion.Presentation.Terminal;

public static class SurveySessionPrinter
{
    private static void SetupTerminal(SurveySession session)
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
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine($"📝 Title: {session.Survey.Title}");
        Console.WriteLine($"💬 Description: {session.Survey.Description}");
        Console.WriteLine($"🔗 Link: {session.Survey.Link}\n\n");
        Console.ForegroundColor = ConsoleColor.White;
    }
    
    public static void Print(SurveySession session)
    {
        SetupTerminal(session);
        
        var count = 0;
        foreach (var answer in session.Answers)
        {
            Console.WriteLine($"Q: {++count}");
            PrintAnswer(answer);
            Console.WriteLine("\n");
        }
    }
    
    public static void PrintShort(SurveySession session)
    {
        SetupTerminal(session);
        
        var count = 0;
        foreach (var answer in session.Answers)
        {
            Console.WriteLine($"Q: {++count}");
            PrintAnswerShort(answer);
            Console.WriteLine("\n");
        }
    }

    private static void PrintAnswer(Answer answer)
    {
        switch (answer)
        {
            case ShortTextAnswer shortTextAnswer: PrintShortAnswer(shortTextAnswer);
                break;
            case NumberAnswer numberAnswer: PrintShortAnswer(numberAnswer);
                break;
        }
    }

    private static void PrintShortAnswer(ShortTextAnswer answer)
    {
        Console.WriteLine($"📝 Question Title: {answer.Question.Title}");
        Console.WriteLine($"💬 Question Description: {answer.Question.Description}");
        Console.WriteLine($"🔒 Question Type: {answer.Question.Type}");
        Console.WriteLine($"🔒 Question Is Required: {answer.Question.IsRequired}");
        Console.WriteLine($"📅 Answered In: {answer.AnsweredIn:f}");
        Console.Write("✏️ Answer:");
        Console.ForegroundColor = answer.Question.IsRequired ? ConsoleColor.Green : ConsoleColor.Yellow;
        Console.Write($" {answer.Text}");
        Console.ForegroundColor = ConsoleColor.White;
    }
    
    private static void PrintShortAnswer(NumberAnswer answer)
    {
        Console.WriteLine($"📝 Question Title: {answer.Question.Title}");
        Console.WriteLine($"💬 Question Description: {answer.Question.Description}");
        Console.WriteLine($"🔒 Question Type: {answer.Question.Type}");
        Console.WriteLine($"🔒 Question Is Required: {answer.Question.IsRequired}");
        Console.WriteLine($"🔒 Range: {((NumberQuestion)answer.Question).Min} at {((NumberQuestion)answer.Question).Max}");
        Console.WriteLine($"📅 Answered In: {answer.AnsweredIn:f}");
        Console.Write("✏️ Answer:");
        Console.ForegroundColor = answer.Question.IsRequired ? ConsoleColor.Green : ConsoleColor.Yellow;
        Console.Write($" {answer.Number}");
        Console.ForegroundColor = ConsoleColor.White;
    }
    
    private static void PrintAnswerShort(Answer answer)
    {
        switch (answer)
        {
            case ShortTextAnswer shortTextAnswer: PrintShortAnswerShort(shortTextAnswer);
                break;
            case NumberAnswer numberAnswer: PrintShortAnswerShort(numberAnswer);
                break;
        }
    }
    
    private static void PrintShortAnswerShort(ShortTextAnswer answer)
    {
        Console.WriteLine($"📝 Question Title: {answer.Question.Title}");
        Console.WriteLine($"🔒 Question Type: {answer.Question.Type}");
        Console.Write("✏️ Answer:");
        Console.ForegroundColor = answer.Question.IsRequired ? ConsoleColor.Green : ConsoleColor.Yellow;
        Console.Write($" {answer.Text}");
        Console.ForegroundColor = ConsoleColor.White;
    }
    
    private static void PrintShortAnswerShort(NumberAnswer answer)
    {
        Console.WriteLine($"📝 Question Title: {answer.Question.Title}");
        Console.WriteLine($"🔒 Question Type: {answer.Question.Type}");
        Console.Write("✏️ Answer:");
        Console.ForegroundColor = answer.Question.IsRequired ? ConsoleColor.Green : ConsoleColor.Yellow;
        Console.Write($" {answer.Number}");
        Console.ForegroundColor = ConsoleColor.White;
    }
}