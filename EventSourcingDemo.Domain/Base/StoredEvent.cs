namespace EventSourcingDemo.Domain.Base;

public abstract class StoredEvent
{
    public long SequenceNumber { get; }
    public string FieldName { get; }
    public DateTime OccurredAt { get; }

    protected StoredEvent(long sequenceNumber, string fieldName, DateTime occurredAt)
    {
        SequenceNumber = sequenceNumber;
        FieldName = fieldName ?? throw new ArgumentNullException(nameof(fieldName));
        OccurredAt = occurredAt;
    }
}