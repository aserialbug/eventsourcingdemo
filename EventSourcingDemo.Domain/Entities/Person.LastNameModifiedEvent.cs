using EventSourcingDemo.Domain.Base;

namespace EventSourcingDemo.Domain.Entities;

public partial class Person
{
    public class LastNameModifiedEvent : BaseDomainEvent<Person>
    {
        public string Value { get; }

        public LastNameModifiedEvent(string value)
        {
            Value = value;
        }

        public override void Apply(Person person)
        {
            person._lastName = Value;
        }
    }
}