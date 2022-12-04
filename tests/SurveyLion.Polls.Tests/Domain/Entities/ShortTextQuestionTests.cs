using SurveyLion.Kernel.Domain.Exceptions;
using SurveyLion.Polls.Domain;

namespace SurveyLion.Polls.Tests.Domain.Entities;

public class ShortTextQuestionTests
{
    private readonly Survey _survey = new("Title", "description");

    [Fact]
    public void ShouldReturnESuccessWhenCreatingShortTextQuestion()
    {
        
        var creatingAnswer = () 
            => new ShortTextQuestion("Title is here", "desc", true, _survey, 20);

        _ = creatingAnswer.Should().NotThrow();
    }
    
    [Fact]
    public void ShouldReturnExceptionWhenCreatingShortTextQuestionWithInvalidTitle()
    {
        var title = string.Empty;

        var creatingAnswer = () 
            => new ShortTextQuestion(title, "desc", true, _survey, 20);

        _ = creatingAnswer
            .Should()
            .Throw<DomainAssertionConcernException>()
            .WithMessage(Strings.QuestionMessages.TitleIsRequiredMessage);
    }
    
    [Fact]
    public void ShouldReturnExceptionWhenCreatingShortTextQuestionWithInvalidSurveyId()
    {
        Survey? survey = null;

        var creatingAnswer = () 
            => new ShortTextQuestion("Title is here", "desc", true, survey!, 20);

        _ = creatingAnswer
            .Should()
            .Throw<DomainAssertionConcernException>()
            .WithMessage(Strings.QuestionMessages.SurveyIsRequiredMessage);
    }
    
    [Fact]
    public void ShouldReturnExceptionWhenCreatingShortTextQuestionWithInvalidDescription()
    {
        var description = string.Empty;

        var creatingAnswer = () 
            => new ShortTextQuestion("Title is here", description, true, _survey, 50);

        _ = creatingAnswer
            .Should()
            .Throw<DomainAssertionConcernException>()
            .WithMessage(Strings.QuestionMessages.DescriptionRequiredMessage);
    }
    
    [Fact]
    public void ShouldReturnExceptionWhenCreatingShortTextQuestionWithInvalidMaxLenght()
    {
        const int maxLenght = -1;

        var creatingAnswer = () 
            => new ShortTextQuestion("Title is here", "desc", true, _survey, maxLenght);

        _ = creatingAnswer
            .Should()
            .Throw<DomainAssertionConcernException>()
            .WithMessage(Strings.ShortTextQuestionMessages.WhenMaxLenghtIsGreaterThanMessage);
    }
    
}