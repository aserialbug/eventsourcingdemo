using EventSourcingDemo.Domain.Entities;
using EventSourcingDemo.Domain.ValueObjects;

namespace EventSourcingDemo.Infrastructure.ChangeTracker;

public class PersonTracker
{
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