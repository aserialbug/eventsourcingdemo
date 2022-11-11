using EventSourcingDemo.Domain.Enums;
using EventSourcingDemo.Domain.ValueObjects;

namespace EventSourcingDemo.Application.UseCases.AddPhone;

public record AddPhoneParameters(
    PhoneNumberType Type, 
    string Number);