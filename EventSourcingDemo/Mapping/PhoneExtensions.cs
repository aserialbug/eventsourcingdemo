using EventSourcingDemo.Application.ViewModels;
using EventSourcingDemo.Domain.ValueObjects;

namespace EventSourcingDemo.Mapping;

public static class PhoneExtensions
{
    public static PhoneViewModel ToViewModel(this Phone phone)
    {
        return new PhoneViewModel(
            phone.Type,
            phone.Number);
    }

    public static IEnumerable<PhoneViewModel> ToViewModels(this IEnumerable<Phone> phones)
    {
        return phones.Select(ToViewModel);
    }
}