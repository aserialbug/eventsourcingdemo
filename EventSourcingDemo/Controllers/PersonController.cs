using EventSourcingDemo.Application.UseCases.AddPerson;
using EventSourcingDemo.Application.UseCases.AddPhone;
using EventSourcingDemo.Application.UseCases.DeletePerson;
using EventSourcingDemo.Application.UseCases.GetAll;
using EventSourcingDemo.Application.UseCases.GetPerson;
using EventSourcingDemo.Application.UseCases.RemovePhone;
using EventSourcingDemo.Application.UseCases.UpdatePerson;
using EventSourcingDemo.Application.ViewModels;
using EventSourcingDemo.Domain.ValueObjects;
using EventSourcingDemo.Mapping;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EventSourcingDemo.Controllers;

/// <summary>
/// REST API для сущности Person
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class PersonController : ControllerBase
{
    private IMediator Mediator => HttpContext.RequestServices.GetRequiredService<IMediator>();
    
    /// <summary>
    /// Получить список людей
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<PersonViewModel[]> GetAll()
    {
        var people = await Mediator.Send(new GetAllQuery());
        return people.ToViewModels().ToArray();
        
    }

    /// <summary>
    /// Получить одного человека
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<PersonViewModel> GetPerson([FromRoute]string id)
    {
        var personId = PersonId.FromString(id);
        var person = await Mediator.Send(new GetPersonQuery(personId));
        return person.ToViewModel();
    }

    /// <summary>
    /// Создать человека
    /// </summary>
    /// <param name="parameters"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<string> AddPerson(AddPersonParameters parameters)
    {
        var personId = await Mediator.Send(new AddPersonCommand(parameters));
        return personId.ToString();
    }

    /// <summary>
    /// Изменить атрибуты человека
    /// </summary>
    /// <param name="id"></param>
    /// <param name="parameters"></param>
    [HttpPost("{id}")]
    public async Task UpdatePerson([FromRoute]string id, [FromBody] UpdatePersonParameters parameters)
    {
        var personId = PersonId.FromString(id);
        _ = await Mediator.Send(new UpdatePersonCommand(personId, parameters));
    }

    /// <summary>
    /// Добавить номер телефона
    /// </summary>
    /// <param name="id"></param>
    /// <param name="parameters"></param>
    [HttpPost("{id}/AddPhone")]
    public async Task AddPhone([FromRoute]string id, [FromBody] AddPhoneParameters parameters)
    {
        var personId = PersonId.FromString(id);
        _ = await Mediator.Send(new AddPhoneCommand(personId, parameters));
    }
    
    /// <summary>
    /// Удалить номер телефона
    /// </summary>
    /// <param name="id"></param>
    /// <param name="parameters"></param>
    [HttpPost("{id}/RemovePhone")]
    public async Task RemovePhone([FromRoute]string id, [FromBody] RemovePhoneParameters parameters)
    {
        var personId = PersonId.FromString(id);
        _ = await Mediator.Send(new RemovePhoneCommand(personId, parameters));
    }

    /// <summary>
    /// Удалить человека
    /// </summary>
    /// <param name="id"></param>
    [HttpDelete("{id}")]
    public async Task DeletePerson([FromRoute]string id)
    {
        var personId = PersonId.FromString(id);
        _ = await Mediator.Send(new DeletePersonCommand(personId));
    }
}