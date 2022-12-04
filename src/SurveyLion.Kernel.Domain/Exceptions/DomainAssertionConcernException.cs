using System.Diagnostics.CodeAnalysis;

namespace SurveyLion.Kernel.Domain.Exceptions;

public sealed class DomainAssertionConcernException : Exception
{
    private DomainAssertionConcernException(string message) : base(message) { }

    public static void AssertArgumentNotNull<T>([NotNull] T? argument, string message)
    {
        if (argument is null) { throw new DomainAssertionConcernException(message); }
    }
    
    public static void AssertArgumentNotEmpty([NotNull] string? stringValue, string message)
    {
        if (string.IsNullOrEmpty(stringValue)) { throw new DomainAssertionConcernException(message); }
    }
    public static void AssertArgumentNotEmpty([NotNull] Guid? guidValue, string message)
    {
        if (guidValue == null || guidValue == Guid.Empty) { throw new DomainAssertionConcernException(message); }
    }

    public static void AssertArgumentEquals<TObject>(TObject argument, TObject to, string message) 
        => ThrowErrorIf(!argument?.Equals(to) ?? true, message);

    public static void AssertArgumentIsGreaterThan(int argument, int than, string message) 
        => ThrowErrorIf(argument < than, message);

    public static void AssertArgumentIsGreaterThan(string argument, int than, string message) 
        => ThrowErrorIf(argument.Length < than, message);
    
    public static void AssertArgumentIsTrue(bool argument, string message) 
        => ThrowErrorIf(!argument, message);
    public static void AssertArgumentIsFalse(bool argument, string message) 
        => ThrowErrorIf(argument, message);
    

    private static void ThrowErrorIf(bool mustThrowException, string message)
    {
        if (mustThrowException) { throw new DomainAssertionConcernException(message); }
    }
    
}