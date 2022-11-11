using EventSourcingDemo.Domain.ValueObjects;
using MediatR;

namespace EventSourcingDemo.Application.UseCases.AddPerson;

public record AddPersonCommand(
    AddPersonParameters Parameters) : IRequest<PersonId>;