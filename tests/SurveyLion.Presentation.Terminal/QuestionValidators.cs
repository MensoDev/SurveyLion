using System.ComponentModel.DataAnnotations;

namespace SurveyLion.Presentation.Terminal;

public static class QuestionValidators
{
    public static Func<object, ValidationResult> Max(int length, string? errorMessage = null) 
        => input => (
            input is int number && number < length ? 
                ValidationResult.Success : 
                new ValidationResult(errorMessage ?? $"Number is greater than {length}.")
            )!;
    
    
    public static Func<object, ValidationResult> Min(int length, string? errorMessage = null) 
        => input => (
            input is int number && number > length ? 
                ValidationResult.Success : 
                new ValidationResult(errorMessage ?? $"Number is less than {length}.")
        )!;
}