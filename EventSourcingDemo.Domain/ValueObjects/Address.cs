using EventSourcingDemo.Domain.Base;

namespace EventSourcingDemo.Domain.ValueObjects;

public class Address : ValueObject
{
    public string City { get; }
    public string Street { get; }
    public int House { get; }
    public int Apartment { get; }
    
    public Address(string city, string street, int house, int apartment)
    {
        if (string.IsNullOrWhiteSpace(city))
            throw new ArgumentNullException(nameof(city));
        City = city;
        
        if (string.IsNullOrWhiteSpace(street))
            throw new ArgumentNullException(nameof(street));
        Street = street;

        if (house <= 0)
            throw new ArgumentOutOfRangeException("house cannot be zero or less");
        House = house;
        
        if (apartment <= 0)
            throw new ArgumentOutOfRangeException("apartment cannot be zero or less");
        Apartment = apartment;
    }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return City;
        yield return Street;
        yield return House;
        yield return Apartment;
    }
}