using EventSourcingDemo.Application.ViewModels;
using EventSourcingDemo.Domain.ValueObjects;

namespace EventSourcingDemo.Application.Interfaces;

public interface IPersonQuerySource
{
    Task<PersonViewModel[]> GetAll();
    Task<PersonViewModel?> FindById(PersonId personId);
    Task Put(PersonViewModel personViewModel);
}