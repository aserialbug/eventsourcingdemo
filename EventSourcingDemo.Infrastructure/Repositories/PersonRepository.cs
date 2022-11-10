using EventSourcingDemo.Application.Interfaces;
using EventSourcingDemo.Domain.Entities;
using EventSourcingDemo.Domain.ValueObjects;

namespace EventSourcingDemo.Infrastructure.Repositories;

public class PersonRepository : IPersonRepository
{
    public Task<Person> this[PersonId id] => throw new NotImplementedException();

    public Task Add(Person entity)
    {
        throw new NotImplementedException();
    }

    public Task Remove(Person entity)
    {
        throw new NotImplementedException();
    }
}