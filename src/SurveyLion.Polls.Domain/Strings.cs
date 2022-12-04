namespace SurveyLion.Polls.Domain;

public static class Strings
{
    public static class QuestionMessages
    {
        public const string TitleIsRequiredMessage = "Title is required.";
        public const string TitleIsGreaterThanMessage = "Title must be more than three characters";
        public const string SurveyIdIsRequiredMessage = "SurveyId is required.";
        public const string SurveyIsRequiredMessage = "Survey is required.";
        public const string DescriptionRequiredMessage = "Description is required.";
    }
    
    public static class ShortTextQuestionMessages
    {
        public const string WhenMaxLenghtIsGreaterThanMessage = "MaxLenght cannot be less than zero";
    }
    
    public static class AnswerMessages 
    {
        public const string QuestionIdIsRequiredMessage = "QuestionId is required.";
        public const string TextIsRequiredMessage = "Text is required.";
        public const string TextIsLessThanMessage = "Text cannot be less than {0}";
        public const string SurveySessionIsRequiredMessage = "SurveySession is required.";
    }
    
    public static class SurveyMessages 
    {
        public const string TitleIsRequiredMessage = "Title is required.";
        public const string TitleIsCannotBeLessThanMessage = "Title cannot be less than 3";
        public const string DescriptionIsRequiredMessage = "Description is required.";
        public const string LinkIsRequiredMessage = "Link is required.";
    }
    
    public static class SurveySessionMessages 
    {
        public const string SurveyIsRequiredMessage = "Survey is required.";
        public const string SurveyIdIsRequiredMessage = "SurveyId is required.";
    }
}