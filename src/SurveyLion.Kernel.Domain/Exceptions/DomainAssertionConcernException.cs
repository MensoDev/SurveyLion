namespace SurveyLion.Kernel.Domain.Exceptions;

public sealed class DomainAssertionConcernException : Exception
{
    private DomainAssertionConcernException(string message) : base(message) { }
    
    public static void AssertArgumentNotEmpty(string? stringValue, string message) 
        => ThrowErrorIf(string.IsNullOrEmpty(stringValue), message);
    
    public static void AssertArgumentNotEmpty(Guid? guidValue, string message) 
        => ThrowErrorIf(guidValue == null || guidValue == Guid.Empty, message);

    public static void AssertArgumentIsGreaterThan(int argument, int than, string message) 
        => ThrowErrorIf(argument < than, message);
    
    public static void AssertArgumentIsGreaterThan(string argument, int than, string message) 
        => ThrowErrorIf(argument.Length < than, message);

    private static void ThrowErrorIf(bool mustThrowException, string message)
    {
        if (mustThrowException) { throw new DomainAssertionConcernException(message); }
    }
}