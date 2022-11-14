namespace EventSourcingDemo.Domain.Base;

public class CollectionEvent<TValue> : AttributeEvent<TValue>
{
    public ChangeType Change { get; }
    
    public CollectionEvent(long sequenceNumber, string fieldName, TValue value, DateTime occurredAt, ChangeType change) : base(sequenceNumber, fieldName, occurredAt, value)
    {
        Change = change;
    }
}