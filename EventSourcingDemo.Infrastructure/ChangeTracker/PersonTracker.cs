using EventSourcingDemo.Domain.Base;
using EventSourcingDemo.Domain.Entities;
using EventSourcingDemo.Domain.ValueObjects;

namespace EventSourcingDemo.Infrastructure.ChangeTracker;

public class PersonTracker
{
    private readonly SortedList<ulong, BaseDomainEvent<Person>> _sequence = new ();
    public PersonId PersonId { get; }

    public PersonTracker(Person person)
    {
        PersonId = person.Id;
    }

    public Person Materialize()
    {
        return null;
    }
}