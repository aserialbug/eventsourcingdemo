namespace EventSourcingDemo.Domain.Base;

public abstract class Entity<TId> where TId : BaseId
{
    public TId Id { get; }
    
    protected Entity(TId id)
    {
        Id = id ?? throw new ArgumentNullException(nameof(id));
    }
}