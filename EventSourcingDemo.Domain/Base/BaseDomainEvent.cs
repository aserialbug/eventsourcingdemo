namespace EventSourcingDemo.Domain.Base;

public abstract class BaseDomainEvent<TEntity> : IDomainEvent<TEntity>
{
    public DateTime OccurredOn { get; }
    protected BaseDomainEvent(DateTime? occurredOn = null)
    {
        OccurredOn = occurredOn ?? DateTime.Now;
    }

    public abstract void Apply(TEntity entity);
}