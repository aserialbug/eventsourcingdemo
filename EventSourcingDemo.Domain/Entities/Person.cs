using EventSourcingDemo.Domain.Base;
using EventSourcingDemo.Domain.ValueObjects;

namespace EventSourcingDemo.Domain.Entities;

public partial class Person : EventEntity<Person, PersonId>
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

            if(_firstName == value)
                return;
            
            _firstName = value;
            RegisterDomainEvent(new FirstNameModifiedEvent(_firstName));
            
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

            if(_lastName == value)
                return;
            
            _lastName = value;
            RegisterDomainEvent(new LastNameModifiedEvent(_lastName));
        }
    }

    private DateTime? _birthDay;
    public DateTime? BirthDay
    {
        get => _birthDay;
        set
        {
            if(!value.HasValue)
                throw new InvalidOperationException("Cannot assign null to BirthDay");
            
            if(_birthDay == value)
                return;

            _birthDay = value;
            RegisterDomainEvent(new BirthDayModifiedEvent(_birthDay.Value));
        }
    }

    private Address? _address;
    public Address? Address
    {
        get => _address;
        set
        {
            if(value == null)
                throw new InvalidOperationException("Cannot assign null to Address");
            
            if(_address == value)
                return;

            _address = value;
            RegisterDomainEvent(new AddressModifiedEvent(_address));
        }
    }
    
    public Phone[] Phones => _phones.ToArray();

    public Person(PersonId id) : base(id)
    {
        _phones = new HashSet<Phone>();
    }
    
    public Person(PersonId id,
        string firstName,
        string lastName,
        DateTime? birthDay = null,
        Address? address = null) : base(id)
    {
        FirstName = firstName;
        LastName = lastName;
        
        if(birthDay.HasValue)
            BirthDay = birthDay;
        
        if(address != null)
            Address = address;
        
        _phones = new HashSet<Phone>();
    }

    public void AddPhone(Phone phone)
    {
        if (!_phones.Add(phone))
            throw new InvalidOperationException($"Person with id {Id} already has the phone {phone}");
        
        RegisterDomainEvent(new PhoneAddedModifiedEvent(phone));
    }

    public void RemovePhone(Phone phone)
    {
        if (!_phones.Remove(phone))
            throw new InvalidOperationException($"Person with id {Id} does not have the phone {phone}");

        RegisterDomainEvent(new PhoneRemovedModifiedEvent(phone));
    }
}