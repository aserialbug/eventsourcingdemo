using EventSourcingDemo.Domain.Base;

namespace EventSourcingDemo.Domain.Entities;

public partial class Person
{
    public class BirthDayModifiedEvent : BaseDomainEvent<Person>
    {
        public DateTime Value { get; }

        public BirthDayModifiedEvent(DateTime value)
        {
            Value = value;
        }

        public override void Apply(Person person)
        {
            person._birthDay = Value;
        }
    }
}