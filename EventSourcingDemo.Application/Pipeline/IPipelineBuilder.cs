using MediatR;

namespace EventSourcingDemo.Application.Pipeline;

public interface IPipelineBuilder<out TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    IPipelineBuilder<TRequest, TResponse> AddStep<TImplementation>()
        where TImplementation : class, IPipelineBehavior<TRequest, TResponse>;

    IPipelineBuilder<TRequest, TResponse> AddStep<TImplementation>(Func<IServiceProvider, TImplementation> implementationFactory)
        where TImplementation : class, IPipelineBehavior<TRequest, TResponse>;

    public void AddRequestHandler<TImplementation>()
        where TImplementation : class, IRequestHandler<TRequest, TResponse>;
}