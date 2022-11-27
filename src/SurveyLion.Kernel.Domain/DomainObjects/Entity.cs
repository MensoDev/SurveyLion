namespace SurveyLion.Kernel.Domain.DomainObjects;

public abstract class  Entity
{
    public Guid Id { get; protected init; } = Guid.NewGuid();

    protected abstract void Validate();
}