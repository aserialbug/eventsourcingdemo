using System.Collections.Concurrent;
using EventSourcingDemo.Domain.Exceptions;

namespace EventSourcingDemo.Domain.Base;

public abstract class Entity<TId> : IEquatable<Entity<TId>> where TId : BaseId
{

    public TId Id { get; }
    
    protected Entity(TId id)
    {
        if (id == null)
            ValidationException.ThrowArgumentNullException(nameof(id));
            
        Id = id;
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