namespace EventSourcingDemo.Domain.Base;

public abstract class BaseId : ValueObject
{
    private string _id;

    protected BaseId(string id)
    {
        _id = id;
    }
    
    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return _id;
    }

    public override string ToString() => _id;
}