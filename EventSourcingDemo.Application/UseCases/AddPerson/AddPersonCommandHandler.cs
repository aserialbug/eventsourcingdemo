using EventSourcingDemo.Application.Interfaces;
using EventSourcingDemo.Domain.Entities;
using EventSourcingDemo.Domain.ValueObjects;
using MediatR;

namespace EventSourcingDemo.Application.UseCases.AddPerson;

public class AddPersonCommandHandler : IRequestHandler<AddPersonCommand, PersonId>
{
    private readonly IPersonRepository _personRepository;

    public AddPersonCommandHandler(IPersonRepository personRepository)
    {
        _personRepository = personRepository;
    }

    public async Task<PersonId> Handle(AddPersonCommand request, CancellationToken cancellationToken)
    {
        Address? address = null;
        if (request.Parameters.Address != null)
        {
            address = new Address(
                request.Parameters.Address.City,
                request.Parameters.Address.Street,
                request.Parameters.Address.House,
                request.Parameters.Address.Apartment);
        }

        var person = new Person(
            PersonId.New(),
            request.Parameters.FirstName,
            request.Parameters.LastName,
            request.Parameters.BirthDay,
            address);

        if (request.Parameters.Phones != null)
        {
            foreach (var phoneParameter in request.Parameters.Phones)
            {
                person.AddPhone(new Phone(
                    phoneParameter.Type, 
                    phoneParameter.Number));
            }
        }

        await _personRepository.Add(person);

        return person.Id;
    }
}