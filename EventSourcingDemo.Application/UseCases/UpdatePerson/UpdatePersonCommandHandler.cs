using EventSourcingDemo.Application.Interfaces;
using EventSourcingDemo.Domain.ValueObjects;
using MediatR;

namespace EventSourcingDemo.Application.UseCases.UpdatePerson;

public class UpdatePersonCommandHandler : IRequestHandler<UpdatePersonCommand, Unit>
{
    private readonly IPersonRepository _personRepository;

    public UpdatePersonCommandHandler(IPersonRepository personRepository)
    {
        _personRepository = personRepository;
    }

    public async Task<Unit> Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
    {
        var person = await _personRepository[request.PersonId];

        if (!string.IsNullOrWhiteSpace(request.Parameters.FirstName))
            person.FirstName = request.Parameters.FirstName;
        
        if (!string.IsNullOrWhiteSpace(request.Parameters.LastName))
            person.LastName = request.Parameters.LastName;
        
        if (request.Parameters.Birthday.HasValue)
            person.BirthDay = request.Parameters.Birthday;

        if (request.Parameters.Address != null)
        {
            Address address = new Address(
                request.Parameters.Address.City,
                request.Parameters.Address.Street,
                request.Parameters.Address.House,
                request.Parameters.Address.Apartment);

            person.Address = address;
        }
        
        return Unit.Value;
    }
}