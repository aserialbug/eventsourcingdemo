using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace EventSourcingDemo.Application;

public static class Inject
{
    public static IServiceCollection AddApplication(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddMediatR(new[] { typeof(Inject).Assembly });
        return serviceCollection;
    }
}