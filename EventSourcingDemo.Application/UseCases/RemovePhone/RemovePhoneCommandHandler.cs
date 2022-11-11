using EventSourcingDemo.Application.Interfaces;
using EventSourcingDemo.Domain.ValueObjects;
using MediatR;

namespace EventSourcingDemo.Application.UseCases.RemovePhone;

public class RemovePhoneCommandHandler : IRequestHandler<RemovePhoneCommand, Unit>
{
    private readonly IPersonRepository _personRepository;

    public RemovePhoneCommandHandler(IPersonRepository personRepository)
    {
        _personRepository = personRepository;
    }

    public async Task<Unit> Handle(RemovePhoneCommand request, CancellationToken cancellationToken)
    {
        var person = await _personRepository[request.PersonId];
        var phone = new Phone(
            request.Parameters.Type,
            request.Parameters.Number);
        
        person.RemovePhone(phone);
        
        return Unit.Value;
    }
}