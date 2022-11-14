using EventSourcingDemo.Application.Interfaces;
using EventSourcingDemo.Application.ViewModels;
using EventSourcingDemo.Domain.ValueObjects;

namespace EventSourcingDemo.Infrastructure.QuerySources;

public class PersonQueryInMemoryStorage : IPersonQuerySource
{
    private readonly Dictionary<PersonId, PersonViewModel> _personViewModels = new ();

    public Task<PersonViewModel[]> GetAll()
    {
        return Task.FromResult(_personViewModels.Values.ToArray());
    }

    public Task<PersonViewModel?> FindById(PersonId personId)
    {
        _ = _personViewModels.TryGetValue(personId, out var personViewModel);
        return Task.FromResult(personViewModel);
    }

    public Task Put(PersonViewModel personViewModel)
    {
        _personViewModels.Add(PersonId.FromString(personViewModel.Id), personViewModel);
        return Task.CompletedTask;
    }
}