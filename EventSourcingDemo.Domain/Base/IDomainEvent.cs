namespace EventSourcingDemo.Domain.Base;

public interface IDomainEvent<in TEntity>
{
    DateTime OccurredOn { get; }
    void Apply(TEntity entity);
}