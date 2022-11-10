using EventSourcingDemo.Domain.Base;

namespace EventSourcingDemo.Domain.ValueObjects;

public class PersonId : BaseId
{
    private PersonId(string id) : base(id)
    {
    }

    public static PersonId New() => new ($"{nameof(PersonId)}_{Guid.NewGuid():N}");

    public static PersonId FromString(string id)
    {
        if (string.IsNullOrWhiteSpace(id))
        {
            throw new ArgumentNullException(nameof(id));
        }

        var idTmp = id.Split('_');

        if (idTmp.Length != 2 || !idTmp.First().Equals(nameof(PersonId)) || !Guid.TryParse(idTmp.Last(), out _))
        {
            throw new ArgumentException($"value {id} is invalid PersonId");
        }

        return new PersonId(id);
    }
}