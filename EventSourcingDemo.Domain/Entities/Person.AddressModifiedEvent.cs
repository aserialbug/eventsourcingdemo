using EventSourcingDemo.Domain.Base;
using EventSourcingDemo.Domain.ValueObjects;

namespace EventSourcingDemo.Domain.Entities;

public partial class Person
{
    public class AddressModifiedEvent : BaseDomainEvent<Person>
    {
        public Address Value { get; }
        public DateTime OccurredOn { get; }

        public AddressModifiedEvent(Address value, DateTime? occurredOn = null) : base(occurredOn)
        {
            Value = value;
        }
        
        public override void Apply(Person entity)
        {
            entity._address = Value;
        }
    }
}