using EventSourcingDemo.Application.Interfaces;
using MediatR;

namespace EventSourcingDemo.Application.Behaviours;

public class TransactionBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly IStorageTransactionService _transaction;

    public TransactionBehaviour(IStorageTransactionService transaction)
    {
        _transaction = transaction;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        try
        {
            await _transaction.BeginTransactionAsync();
            
            TResponse response = await next();
            
            await _transaction.CommitTransactionAsync();
            return response;
        }
        catch (Exception)
        {
            await _transaction.RollbackTransactionAsync();
            throw;
        }
    }
}