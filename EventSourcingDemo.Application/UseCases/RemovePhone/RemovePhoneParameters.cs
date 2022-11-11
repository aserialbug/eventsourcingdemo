using EventSourcingDemo.Domain.Enums;

namespace EventSourcingDemo.Application.UseCases.RemovePhone;

public record RemovePhoneParameters(
    PhoneNumberType Type, 
    string Number);