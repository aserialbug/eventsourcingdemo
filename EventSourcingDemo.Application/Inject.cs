using EventSourcingDemo.Application.Behaviours;
using EventSourcingDemo.Application.Common;
using EventSourcingDemo.Application.Pipeline;
using EventSourcingDemo.Application.UseCases.AddPerson;
using EventSourcingDemo.Application.UseCases.AddPhone;
using EventSourcingDemo.Application.UseCases.DeletePerson;
using EventSourcingDemo.Application.UseCases.GetAll;
using EventSourcingDemo.Application.UseCases.GetPerson;
using EventSourcingDemo.Application.UseCases.RemovePhone;
using EventSourcingDemo.Application.UseCases.UpdatePerson;
using EventSourcingDemo.Domain.Entities;
using EventSourcingDemo.Domain.ValueObjects;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace EventSourcingDemo.Application;

public static class Inject
{
    public static IServiceCollection AddApplication(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddMediatorPipeline<AddPersonCommand, PersonId>()
            .AddStep<TransactionBehaviour<AddPersonCommand, PersonId>>()
            .AddRequestHandler<AddPersonCommandHandler>();
        
        serviceCollection.AddMediatorPipeline<AddPhoneCommand, Unit>()
            .AddStep<TransactionBehaviour<AddPhoneCommand, Unit>>()
            .AddRequestHandler<AddPhoneCommandHandler>();
        
        serviceCollection.AddMediatorPipeline<DeletePersonCommand, Unit>()
            .AddStep<TransactionBehaviour<DeletePersonCommand, Unit>>()
            .AddRequestHandler<DeletePersonCommandHandler>();
        
        serviceCollection.AddMediatorPipeline<GetAllQuery, Person[]>()
            .AddRequestHandler<GetAllQueryHandler>();
        
        serviceCollection.AddMediatorPipeline<GetPersonQuery, Person>()
            .AddRequestHandler<GetPersonQueryHandler>();
        
        serviceCollection.AddMediatorPipeline<RemovePhoneCommand, Unit>()
            .AddStep<TransactionBehaviour<RemovePhoneCommand, Unit>>()
            .AddRequestHandler<RemovePhoneCommandHandler>();
        
        serviceCollection.AddMediatorPipeline<UpdatePersonCommand, Unit>()
            .AddStep<TransactionBehaviour<UpdatePersonCommand, Unit>>()
            .AddRequestHandler<UpdatePersonCommandHandler>();

        serviceCollection.AddScoped<RequestContext>();
        
        return serviceCollection;
    }
}