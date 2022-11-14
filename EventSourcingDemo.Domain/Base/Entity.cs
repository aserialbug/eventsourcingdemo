using System.Collections.Concurrent;
using System.Linq.Expressions;
using EventSourcingDemo.Domain.Exceptions;

namespace EventSourcingDemo.Domain.Base;

public abstract class Entity<TId> : IEquatable<Entity<TId>> where TId : BaseId
{
    private readonly ConcurrentQueue<StoredEvent> _events;
    private long _version;

    public TId Id { get; }
    
    protected Entity(TId id)
    {
        if (id == null)
            ValidationException.ThrowArgumentNullException(nameof(id));
            
        Id = id;
        _events = new ConcurrentQueue<StoredEvent>();
        _version = 0;
    }

    protected void RegisterSetAttributeEvent<TEntity, TValue>(Expression<Func<TEntity, TValue>> propertySelector, TValue value)
        where TEntity : Entity<TId>
    {
        if(propertySelector.Body is not MemberExpression)
            OperationException.ThrowCannotPerformAction();

        _version++;
        var memberExpression = propertySelector.Body as MemberExpression;
        _events.Enqueue(new AttributeEvent<TValue>(
            _version,
            memberExpression.Member.Name,
            DateTime.Now,
            value));
    }

    protected void RegisterChangeCollectionEvent<TEntity, TValue>(
        Expression<Func<TEntity, ICollection<TValue>>> collectionSelector,
        TValue value, ChangeType changeType)
        where TEntity : Entity<TId>
    {
        if(collectionSelector.Body is not MemberExpression)
            OperationException.ThrowCannotPerformAction();

        var memberExpression = collectionSelector.Body as MemberExpression;
        _version++;
        _events.Enqueue(new CollectionEvent<TValue>(
            _version,
            memberExpression.Member.Name,
            value,
            DateTime.Now,
            changeType));
    }

    public bool Equals(Entity<TId>? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return Id.Equals(other.Id);
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((Entity<TId>)obj);
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
    
    private static bool EqualOperator(Entity<TId>? left, Entity<TId>? right)
    {
        if (ReferenceEquals(left, null) ^ ReferenceEquals(right, null))
        {
            return false;
        }
        return ReferenceEquals(left, right) || left.Equals(right);
    }

    public static bool operator ==(Entity<TId>? left, Entity<TId>? right) => EqualOperator(left, right);

    public static bool operator !=(Entity<TId>? left, Entity<TId>? right) => !EqualOperator(left, right);
}