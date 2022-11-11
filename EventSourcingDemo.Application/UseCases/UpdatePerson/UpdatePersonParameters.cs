using EventSourcingDemo.Application.UseCases.AddPerson;

namespace EventSourcingDemo.Application.UseCases.UpdatePerson;

public record UpdatePersonParameters(
    string FirstName,
    string LastName,
    DateTime? Birthday,
    AddressParameters? Address);