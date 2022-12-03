namespace SurveyLion.Polls.Domain;

public static class Strings
{
    public static class QuestionMessages
    {
        public const string TitleIsRequiredMessage = "Title is required.";
        public const string TitleIsGreaterThanMessage = "Title must be more than three characters";
        public const string SurveyIdIsRequiredMessage = "SurveyId is required.";
    }
    
    public static class ShortTextQuestionMessages
    {
        public const string WhenMaxLenghtIsGreaterThanMessage = "MaxLenght cannot be less than zero";
    }
    
    public static class AnswerMessages 
    {
        public const string QuestionIdIsRequiredMessage = "QuestionId is required.";
    }
}