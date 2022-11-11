using System.Text;
using EventSourcingDemo.Domain.Base;

namespace EventSourcingDemo.Domain.Exceptions;

public class NotFoundException : DomainBaseException
{
    public NotFoundException(string? message) : base(message)
    {
    }

    public static void ThrowEntityNotFound<TEntity, TId>(TId? id = null)
        where TEntity : Entity<TId> where TId : BaseId
    {
        var builder = new StringBuilder();
        builder.Append("Entity of type ");
        builder.Append('\"');
        builder.Append(typeof(TEntity).Name);
        builder.Append('\"');
        if (id != null)
        {
            builder.Append(" with id ");
            builder.Append('\"');
            builder.Append(id);
            builder.Append('\"');
        }
        builder.Append(" was not found");
        
        throw new NotFoundException(builder.ToString());
    }
}