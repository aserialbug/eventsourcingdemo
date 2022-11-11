using EventSourcingDemo.Application.Interfaces;
using EventSourcingDemo.Domain.Entities;
using EventSourcingDemo.Domain.Exceptions;
using EventSourcingDemo.Domain.ValueObjects;

namespace EventSourcingDemo.Infrastructure.Repositories;

public class PersonRepository : IPersonRepository
{
    private readonly Dictionary<PersonId, Person> _persons = new Dictionary<PersonId, Person>();

    public Task<Person> this[PersonId id] => GetById(id);

    private Task<Person> GetById(PersonId id)
    {
        if (!_persons.TryGetValue(id, out var person))
            NotFoundException.ThrowEntityNotFound<Person,PersonId>(id);

        return Task.FromResult(person);
    }

    public Task Add(Person entity)
    {
        _persons.Add(entity.Id, entity);
        return Task.CompletedTask;
    }

    public Task Remove(Person entity)
    {
        _persons.Remove(entity.Id);
        return Task.CompletedTask;
    }

    public Task<Person[]> GetAll()
    {
        return Task.FromResult(_persons.Values.ToArray());
    }
}