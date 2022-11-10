using EventSourcingDemo.Domain.ValueObjects;

namespace EventSourcingDemo.Application.UseCases.AddPerson;

public record AddPersonCommand(
    AddPersonParameters Parameters);