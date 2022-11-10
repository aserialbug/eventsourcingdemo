using EventSourcingDemo.Domain.Base;
using EventSourcingDemo.Domain.Enums;

namespace EventSourcingDemo.Domain.ValueObjects;

public class Phone : ValueObject
{
    public PhoneNumberType Type { get; }
    public string Number { get; }
    
    public Phone(PhoneNumberType type, string number)
    {
        Type = type;

        if (string.IsNullOrWhiteSpace(number))
            throw new ArgumentNullException(nameof(number));
        Number = number;
    }
    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Type;
        yield return Number;
    }
}