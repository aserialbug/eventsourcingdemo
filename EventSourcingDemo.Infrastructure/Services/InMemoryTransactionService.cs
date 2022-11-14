using EventSourcingDemo.Application.Interfaces;

namespace EventSourcingDemo.Infrastructure.Services;

public class InMemoryTransactionService : IStorageTransactionService
{
    public Task BeginTransactionAsync()
    {
        return Task.CompletedTask;
    }

    public Task CommitTransactionAsync()
    {
        return Task.CompletedTask;
    }

    public Task RollbackTransactionAsync()
    {
        return Task.CompletedTask;
    }
}