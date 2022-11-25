namespace EventSourcingDemo.Application.Common;

public class ContextId : BaseId
{
    private ContextId(string id) : base(id)
    {
    }

    public override string ToString() => $"{nameof(ContextId)}_{_id}";

    public static ContextId New() => new (Guid.NewGuid().ToString("N"));
}