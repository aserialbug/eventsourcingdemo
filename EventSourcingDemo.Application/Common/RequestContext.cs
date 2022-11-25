namespace EventSourcingDemo.Application.Common;

public class RequestContext
{
    public UserId? UserId { get; private set; }
    public ContextId ContextId { get; }

    public RequestContext()
    {
        ContextId = ContextId.New();
    }

    public void AddUserContext(UserId userId)
    {
        if (UserId != null)
            throw new InvalidOperationException($"UserId for request {ContextId} has already been initialized");

        UserId = userId ?? throw new ArgumentNullException(nameof(userId));
    }
}