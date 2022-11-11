using EventSourcingDemo.Application.ViewModels;
using EventSourcingDemo.Domain.Entities;

namespace EventSourcingDemo.Mapping;

public static class PersonExtensions
{
    public static PersonViewModel ToViewModel(this Person person)
    {
        return new PersonViewModel(
            person.Id.ToString(),
            person.FirstName,
            person.LastName,
            person.BirthDay,
            person.Address?.ToViewModel(),
            person.Phones.ToViewModels().ToArray());
    }

    public static IEnumerable<PersonViewModel> ToViewModels(this IEnumerable<Person> persons)
    {
        return persons.Select(ToViewModel);
    }
}