namespace EventSourcingDemo.Application.UseCases.AddPerson;

public record AddPersonParameters(
    string FirstName,
    string LastName);