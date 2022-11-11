using EventSourcingDemo.Application.Interfaces;
using EventSourcingDemo.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace EventSourcingDemo.Infrastructure;

public static class Inject
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddSingleton<IPersonRepository, PersonRepository>();
        return serviceCollection;
    }
}