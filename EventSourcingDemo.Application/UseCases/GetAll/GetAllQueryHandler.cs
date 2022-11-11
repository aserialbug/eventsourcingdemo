using EventSourcingDemo.Application.Interfaces;
using EventSourcingDemo.Domain.Entities;
using MediatR;

namespace EventSourcingDemo.Application.UseCases.GetAll;

public class GetAllQueryHandler : IRequestHandler<GetAllQuery, Person[]>
{
    private readonly IPersonRepository _personRepository;

    public GetAllQueryHandler(IPersonRepository personRepository)
    {
        _personRepository = personRepository;
    }

    public async Task<Person[]> Handle(GetAllQuery request, CancellationToken cancellationToken)
    {
        return await _personRepository.GetAll();
    }
}