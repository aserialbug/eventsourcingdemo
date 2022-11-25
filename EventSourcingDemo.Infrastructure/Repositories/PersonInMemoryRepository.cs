using EventSourcingDemo.Application.Interfaces;
using EventSourcingDemo.Domain.Base;
using EventSourcingDemo.Domain.Entities;
using EventSourcingDemo.Domain.Exceptions;
using EventSourcingDemo.Domain.ValueObjects;
using EventSourcingDemo.Infrastructure.ChangeTracker;

namespace EventSourcingDemo.Infrastructure.Repositories;

public class PersonInMemoryRepository : IPersonRepository
{
    private readonly Dictionary<PersonId, SortedList<ulong, BaseDomainEvent<Person>>> _sequences = new ();
    private readonly List<PersonTracker> _personTrackers = new ();

    public Task<Person> this[PersonId id] => Task.FromResult(GetById(id));

    public Task Add(Person entity)
    {
        if(!_sequences.TryGetValue(entity.Id, out var sequence))
        {
            sequence = new SortedList<ulong, BaseDomainEvent<Person>>();
            _sequences.Add(entity.Id, sequence);
        }
        foreach (var entityEvent in entity.Events)
        {
            sequence.Add(, entityEvent);
        }
        _personTrackers.Add(new PersonTracker(entity));
        return Task.CompletedTask;
    }

    public Task Remove(Person entity)
    {
        _sequences.Remove(entity.Id);
        _personTrackers.RemoveAll(t => t.Person.Id == entity.Id);
        return Task.CompletedTask;
    }

    public Task<Person[]> GetAll()
    {
        var result = new List<Person>(_sequences.Count);
        foreach (var keyValuePair in _sequences)
        {
            result.Add(GetById(keyValuePair.Key));
        }
        _personTrackers.AddRange(result.Select(p => new PersonTracker(p)));
        return Task.FromResult(result.ToArray());
    }

    private Person GetById(PersonId personId)
    {
        if(!_sequences.TryGetValue(personId, out var sequence))
            NotFoundException.ThrowEntityNotFound<Person,PersonId>(personId);
        
        var person = new Person(personId);
        foreach (var keyValuePair in sequence)
        {
            keyValuePair.Value.Apply(person);
        }

        return person;
    }
}