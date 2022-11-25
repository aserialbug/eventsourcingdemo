using System.Collections.Concurrent;
using EventSourcingDemo.Domain.Exceptions;

namespace EventSourcingDemo.Domain.Base;

public abstract class EventEntity<TEntity, TId> : Entity<TId>
    where TId : BaseId
    where TEntity : Entity<TId>
{
    private readonly ConcurrentStack<BaseDomainEvent<TEntity>> _events = new();
    public BaseDomainEvent<TEntity>[] Events => _events.ToArray(); 

    protected EventEntity(TId id) : base(id)
    {
    }

    protected void RegisterDomainEvent(BaseDomainEvent<TEntity> @event)
    {
        ValidationException.ThrowArgumentNullException(nameof(@event));
        _events.Push(@event);
    }
}