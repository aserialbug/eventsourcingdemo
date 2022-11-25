using EventSourcingDemo.Domain.Base;
using EventSourcingDemo.Domain.ValueObjects;

namespace EventSourcingDemo.Domain.Entities;

public partial class Person
{
    public class PhoneAddedModifiedEvent : BaseDomainEvent<Person>
    {
        public Phone Value { get; }

        public PhoneAddedModifiedEvent(Phone value)
        {
            Value = value;
        }
        
        public override void Apply(Person person)
        {
            person._phones.Add(Value);
        }
    }
}