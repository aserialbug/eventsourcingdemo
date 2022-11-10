using EventSourcingDemo.Domain.Entities;
using EventSourcingDemo.Domain.ValueObjects;

namespace EventSourcingDemo.Application.Interfaces;

public interface IPersonRepository : IRepository<Person, PersonId>
{
}