namespace EventSourcingDemo.Domain.Exceptions;

public abstract class DomainBaseException : Exception
{
    protected DomainBaseException()
    {
    }

    protected DomainBaseException(string? message) : base(message)
    {
    }

    protected DomainBaseException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}