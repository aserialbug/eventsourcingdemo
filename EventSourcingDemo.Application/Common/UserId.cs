namespace EventSourcingDemo.Application.Common;

public class UserId : BaseId
{
    public static UserId TestUser { get; } = new("68f2ab7aef64462a8ef87c61cf7e427a");
    
    public UserId(string id) : base(id)
    {
    }
    
    public override string ToString() => $"{nameof(UserId)}_{_id}";

    public static UserId New() => new (Guid.NewGuid().ToString("N"));
}