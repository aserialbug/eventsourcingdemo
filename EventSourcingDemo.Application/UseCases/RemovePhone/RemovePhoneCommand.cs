using EventSourcingDemo.Domain.ValueObjects;
using MediatR;

namespace EventSourcingDemo.Application.UseCases.RemovePhone;

public record RemovePhoneCommand(
    PersonId PersonId, 
    RemovePhoneParameters Parameters) : IRequest;