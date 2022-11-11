using EventSourcingDemo.Application.ViewModels;
using EventSourcingDemo.Domain.ValueObjects;

namespace EventSourcingDemo.Mapping;

public static class AddressExtensions
{
    public static AddressViewModel? ToViewModel(this Address address)
    {
        if (ReferenceEquals(address, null))
            return null;
        
        return new AddressViewModel(
            address.City,
            address.Street,
            address.House,
            address.Apartment);
    }
}