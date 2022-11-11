namespace EventSourcingDemo.Application.ViewModels;

public record AddressViewModel(
    string City,
    string Street,
    int House,
    int Apartment);