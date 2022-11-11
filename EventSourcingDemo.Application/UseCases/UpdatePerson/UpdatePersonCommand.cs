using EventSourcingDemo.Domain.ValueObjects;
using MediatR;

namespace EventSourcingDemo.Application.UseCases.UpdatePerson;

public record UpdatePersonCommand(
    PersonId PersonId,
    UpdatePersonParameters Parameters) : IRequest;