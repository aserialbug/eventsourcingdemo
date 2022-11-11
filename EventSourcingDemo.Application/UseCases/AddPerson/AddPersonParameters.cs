namespace EventSourcingDemo.Application.UseCases.AddPerson;

public record AddPersonParameters(
    string FirstName,
    string LastName,
    DateTime BirthDay,
    AddressParameters? Address,
    PhoneParameters[]? Phones);