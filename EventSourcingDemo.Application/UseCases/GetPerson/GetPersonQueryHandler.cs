using EventSourcingDemo.Application.Interfaces;
using EventSourcingDemo.Domain.Entities;
using MediatR;

namespace EventSourcingDemo.Application.UseCases.GetPerson;

public class GetPersonQueryHandler : IRequestHandler<GetPersonQuery, Person>
{
    private readonly IPersonRepository _personRepository;

    public GetPersonQueryHandler(IPersonRepository personRepository)
    {
        _personRepository = personRepository;
    }

    public async Task<Person> Handle(GetPersonQuery request, CancellationToken cancellationToken)
    {
        return await _personRepository[request.PersonId];
    }
}