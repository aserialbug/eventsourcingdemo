using Microsoft.Extensions.DependencyInjection;

namespace EventSourcingDemo.Application;

public static class Inject
{
    public static IServiceCollection AddApplication(this IServiceCollection serviceCollection)
    {
        return serviceCollection;
    }
}