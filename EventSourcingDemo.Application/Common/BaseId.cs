namespace EventSourcingDemo.Application.Common;

public abstract class BaseId : IEquatable<BaseId>
{
    protected readonly string _id;

    protected BaseId(string id)
    {
        _id = id;
    }
    public bool Equals(BaseId? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return _id == other._id;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((BaseId)obj);
    }

    public override int GetHashCode()
    {
        return _id.GetHashCode();
    }

    public static bool operator ==(BaseId? left, BaseId? right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(BaseId? left, BaseId? right)
    {
        return !Equals(left, right);
    }
}