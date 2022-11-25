using EventSourcingDemo.Domain.Base;
using EventSourcingDemo.Domain.ValueObjects;

namespace EventSourcingDemo.Domain.Entities;

public partial class Person
{
    public class FirstNameModifiedEvent : BaseDomainEvent<Person>
    {
        public string Value { get; }
        public FirstNameModifiedEvent(string value)
        {
            Value = value;
        }

        public override void Apply(Person person)
        {
            person._firstName = Value;
        }
    }
}