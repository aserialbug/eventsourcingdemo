using EventSourcingDemo.Domain.Base;
using EventSourcingDemo.Domain.ValueObjects;

namespace EventSourcingDemo.Domain.Entities;

public partial class Person
{
    public class PhoneRemovedModifiedEvent : BaseDomainEvent<Person>
    {
        public Phone Value { get; }

        public PhoneRemovedModifiedEvent(Phone value)
        {
            Value = value;
        }
        
        public override void Apply(Person person)
        {
            person._phones.Remove(Value);
        }
    }
}