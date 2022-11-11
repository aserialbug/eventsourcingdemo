using EventSourcingDemo.Domain.ValueObjects;
using MediatR;

namespace EventSourcingDemo.Application.UseCases.AddPhone;

public record AddPhoneCommand(
    PersonId PersonId,
    AddPhoneParameters Parameters) : IRequest;