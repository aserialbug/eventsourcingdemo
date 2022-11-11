using EventSourcingDemo.Domain.Enums;

namespace EventSourcingDemo.Application.ViewModels;

public record PhoneViewModel(
    PhoneNumberType Type,
    string Number);