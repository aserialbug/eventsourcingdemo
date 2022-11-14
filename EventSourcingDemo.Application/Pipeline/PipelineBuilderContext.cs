using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace EventSourcingDemo.Application.Pipeline;

public class PipelineBuilderContext<TRequest, TResponce> : IPipelineBuilder<TRequest, TResponce>
    where TRequest : IRequest<TResponce>
{
    private readonly IServiceCollection _services;
    private readonly IServiceCollection _pipelineSteps;

    public PipelineBuilderContext(IServiceCollection services)
    {
        _services = services;
        _pipelineSteps = new ServiceCollection();
    }

    public IPipelineBuilder<TRequest, TResponce> AddStep<TImplementation>()
        where TImplementation : class, IPipelineBehavior<TRequest, TResponce>
    {
        _pipelineSteps.AddScoped<IPipelineBehavior<TRequest, TResponce>, TImplementation>();
        return this;
    }

    public IPipelineBuilder<TRequest, TResponce> AddStep<TImplementation>(
        Func<IServiceProvider, TImplementation> implementationFactory)
        where TImplementation : class, IPipelineBehavior<TRequest, TResponce>
    {
        _pipelineSteps.AddScoped<IPipelineBehavior<TRequest, TResponce>, TImplementation>(implementationFactory);
        return this;
    }

    public void AddRequestHandler<TImplementation>()
        where TImplementation : class, IRequestHandler<TRequest, TResponce>
    {
        foreach (var serviceDescriptor in _pipelineSteps)
        {
            _services.Add(serviceDescriptor);
        }

        _services.AddScoped<IRequestHandler<TRequest, TResponce>, TImplementation>();
    }
}