using System.Runtime.CompilerServices;
using System.Text;

namespace EventSourcingDemo.Domain.Exceptions;

public class ValidationException : DomainBaseException
{
    public ValidationException(string? message) : base(message)
    {
    }

    public static void ThrowArgumentNullException(string? argumentName = null,
        [CallerMemberName] string? methodName = null)
    {
        var builder = new StringBuilder();
        builder.Append("Argument ");

        if (!string.IsNullOrWhiteSpace(argumentName))
        {
            builder.Append('\"');
            builder.Append(argumentName);
            builder.Append('\"');
        }

        if (!string.IsNullOrWhiteSpace(methodName))
        {
            builder.Append(" of method ");
            builder.Append('\"');
            builder.Append(methodName);
            builder.Append('\"');
            builder.Append(' ');
        }

        builder.Append("cannot be null");
        throw new ValidationException(builder.ToString());
    }
}