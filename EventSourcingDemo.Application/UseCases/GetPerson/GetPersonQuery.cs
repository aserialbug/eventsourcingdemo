using EventSourcingDemo.Domain.Entities;
using EventSourcingDemo.Domain.ValueObjects;
using MediatR;

namespace EventSourcingDemo.Application.UseCases.GetPerson;

public record GetPersonQuery(PersonId PersonId) : IRequest<Person>;