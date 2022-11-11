using EventSourcingDemo.Domain.Enums;

namespace EventSourcingDemo.Application.UseCases.AddPerson;

public record PhoneParameters(
                        PhoneNumberType Type,
                        string Number);