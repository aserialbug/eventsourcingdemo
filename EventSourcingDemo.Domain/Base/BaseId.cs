using EventSourcingDemo.Domain.Exceptions;

namespace EventSourcingDemo.Domain.Base;

public abstract class BaseId : ValueObject
{
    private readonly string _id;

    protected BaseId(string id)
    {
        if (string.IsNullOrWhiteSpace(id))
            ValidationException.ThrowArgumentNullException(nameof(id));
        
        _id = id;
    }
    
    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return _id;
    }

    public override string ToString() => _id;
}