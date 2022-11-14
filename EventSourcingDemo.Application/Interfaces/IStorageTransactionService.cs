namespace EventSourcingDemo.Application.Interfaces;

public interface IStorageTransactionService
{
    Task BeginTransactionAsync();
    Task CommitTransactionAsync();
    Task RollbackTransactionAsync();
}