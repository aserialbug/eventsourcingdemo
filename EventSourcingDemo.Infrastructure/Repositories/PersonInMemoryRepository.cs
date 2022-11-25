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
    private readonly Dictionary<PersonId, PersonTracker> _personTrackers = new ();

    public Task<Person> this[PersonId id] => Task.FromResult(GetById(id));

    public Task Add(Person entity)
    {
        if(_personTrackers.ContainsKey(entity.Id))
            OperationException.ThrowCannotPerformAction();
        
        var tracker = new PersonTracker(entity);
        _personTrackers.Add(tracker.PersonId, tracker);
        
        return Task.CompletedTask;
    }

    public Task Remove(Person entity)
    {
        if(!_personTrackers.ContainsKey(entity.Id))
            OperationException.ThrowCannotPerformAction();
        
        _personTrackers.Remove(entity.Id);
        return Task.CompletedTask;
    }

    public Task<Person[]> GetAll()
    {
        var result = new List<Person>(_personTrackers.Count);
        foreach (var (_, tracker) in _personTrackers)
        {
            result.Add(tracker.Materialize());
        }
        return Task.FromResult(result.ToArray());
    }

    private Person GetById(PersonId personId)
    {
        if(!_personTrackers.ContainsKey(personId))
            OperationException.ThrowCannotPerformAction();
        
        return _personTrackers[personId].Materialize();
    }
}