using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace EventSourcingDemo.Application.Pipeline;

public static class Inject
{
    public static IPipelineBuilder<TRequest, TResponce> AddMediatorPipeline<TRequest, TResponce>(this IServiceCollection serviceCollection) 
        where TRequest : IRequest<TResponce>
    {
        serviceCollection.TryAddTransient<IMediator, Mediator>();
        serviceCollection.TryAddTransient<ServiceFactory>(provider => provider.GetService);
            
        return new PipelineBuilderContext<TRequest, TResponce>(serviceCollection);
    }
}