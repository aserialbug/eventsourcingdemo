namespace EventSourcingDemo.Application.UseCases.AddPerson;

public record AddressParameters(
    string City,
    string Street,
    int House,
    int Apartment);