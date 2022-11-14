using EventSourcingDemo.Application.Interfaces;
using EventSourcingDemo.Infrastructure.QuerySources;
using EventSourcingDemo.Infrastructure.Repositories;
using EventSourcingDemo.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace EventSourcingDemo.Infrastructure;

public static class Inject
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddSingleton<IPersonRepository, PersonInMemoryRepository>();
        serviceCollection.AddSingleton<IPersonQuerySource, PersonQueryInMemoryStorage>();
        serviceCollection.AddScoped<IStorageTransactionService, InMemoryTransactionService>();
        return serviceCollection;
    }
}