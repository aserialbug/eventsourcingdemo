using EventSourcingDemo.Application.Interfaces;
using EventSourcingDemo.Domain.ValueObjects;
using MediatR;

namespace EventSourcingDemo.Application.UseCases.AddPhone;

public class AddPhoneCommandHandler : IRequestHandler<AddPhoneCommand, Unit>
{
    private readonly IPersonRepository _personRepository;

    public AddPhoneCommandHandler(IPersonRepository personRepository)
    {
        _personRepository = personRepository;
    }

    public async Task<Unit> Handle(AddPhoneCommand request, CancellationToken cancellationToken)
    {
        var person = await _personRepository[request.PersonId];
        var phone = new Phone(
            request.Parameters.Type,
            request.Parameters.Number);
        
        person.AddPhone(phone);
        
        return Unit.Value;
    }
}