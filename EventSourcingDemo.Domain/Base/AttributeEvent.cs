namespace EventSourcingDemo.Domain.Base;

public class AttributeEvent<TValue> : StoredEvent
{
    public TValue Value { get; }

    public AttributeEvent(long sequenceNumber, string fieldName, DateTime occurredAt, TValue value) : base(sequenceNumber, fieldName, occurredAt)
    {
        Value = value;
    }
}