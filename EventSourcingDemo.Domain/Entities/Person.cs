using System.Reflection.Metadata.Ecma335;
using EventSourcingDemo.Domain.Base;
using EventSourcingDemo.Domain.Exceptions;
using EventSourcingDemo.Domain.ValueObjects;

namespace EventSourcingDemo.Domain.Entities;

public class Person : Entity<PersonId>
{
    private readonly HashSet<Phone> _phones;

    private string _firstName;
    public string FirstName
    {
        get => _firstName;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new InvalidOperationException("Cannot assign null to FirstName");

            _firstName = value;
        }
    }

    private string _lastName;
    public string LastName
    {
        get => _lastName;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new InvalidOperationException("Cannot assign null to LastName");

            _lastName = value;
        }
    }

    private DateTime? _birthDay;
    public DateTime? BirthDay
    {
        get => _birthDay;
        set => _birthDay = value ?? throw new InvalidOperationException("Cannot assign null to BirthDay");
    }

    private Address? _address;
    public Address? Address
    {
        get => _address;
        set => _address = value ?? throw new InvalidOperationException("Cannot assign null to BirthDay");
    }
    
    public Phone[] Phones => _phones.ToArray();
    
    public Person(PersonId id,
        string firstName,
        string lastName,
        DateTime? birthDay = null,
        Address? address = null) : base(id)
    {
        if (string.IsNullOrWhiteSpace(firstName))
            ValidationException.ThrowArgumentNullException(nameof(firstName));
        _firstName = firstName;
        
        if (string.IsNullOrWhiteSpace(lastName))
            ValidationException.ThrowArgumentNullException(nameof(lastName));
        _lastName = lastName;
        
        BirthDay = birthDay;
        _address = address;
        _phones = new HashSet<Phone>();
    }

    public void AddPhone(Phone phone)
    {
        if (!_phones.Add(phone))
            throw new InvalidOperationException($"Person with id {Id} already has the phone {phone}");
    }

    public void RemovePhone(Phone phone)
    {
        if(!_phones.Remove(phone))
            throw new InvalidOperationException($"Person with id {Id} does not have the phone {phone}");
    }
}