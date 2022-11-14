namespace EventSourcingDemo.Domain.Exceptions;

public class OperationException : DomainBaseException
{
    public OperationException(string? message) : base(message)
    {
    }

    public static void ThrowCannotAssignValue()
    {
        throw new OperationException("CannotAssignValue");
    }
    
    public static void ThrowCannotPerformAction()
    {
        throw new OperationException("CannotPerformAction");
    }
}