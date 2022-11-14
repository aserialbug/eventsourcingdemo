namespace EventSourcingDemo.Domain.Base;

public interface IDomainEvent
{
    DateTime OccurredOn { get; }
}