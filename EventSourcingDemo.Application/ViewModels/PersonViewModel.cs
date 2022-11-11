using EventSourcingDemo.Domain.ValueObjects;

namespace EventSourcingDemo.Application.ViewModels;

public record PersonViewModel(
    string Id,
    string FirstName,
    string LastName,
    DateTime? Birthday,
    AddressViewModel? Address,
    PhoneViewModel[]? Phones);