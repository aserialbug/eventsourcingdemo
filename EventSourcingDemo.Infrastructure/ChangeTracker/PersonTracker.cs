using EventSourcingDemo.Domain.Entities;

namespace EventSourcingDemo.Infrastructure.ChangeTracker;

public class PersonTracker
{
    private readonly Person _person;
    public Person Person => _person;

    public PersonTracker(Person person)
    {
        _person = person;
    }
}