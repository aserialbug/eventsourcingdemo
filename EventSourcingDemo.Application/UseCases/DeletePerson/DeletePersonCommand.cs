using EventSourcingDemo.Domain.ValueObjects;
using MediatR;

namespace EventSourcingDemo.Application.UseCases.DeletePerson;

public record DeletePersonCommand(PersonId PersonId) : IRequest;