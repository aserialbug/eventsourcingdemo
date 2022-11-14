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
public class PersonsController : ControllerBase
{
    private IMediator Mediator => HttpContext.RequestServices.GetRequiredService<IMediator>();
    
    /// <summary>
    /// Получить список людей
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [ProducesResponseType(typeof(PersonViewModel[]),StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll()
    {
        var people = await Mediator.Send(new GetAllQuery());
        return Ok(people.ToViewModels().ToArray());
    }

    /// <summary>
    /// Получить одного человека
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(PersonViewModel),StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetPerson([FromRoute]string id)
    {
        var personId = PersonId.FromString(id);
        var person = await Mediator.Send(new GetPersonQuery(personId));
        return Ok(person.ToViewModel());
    }

    /// <summary>
    /// Создать человека
    /// </summary>
    /// <param name="parameters"></param>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType(typeof(string),StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> AddPerson(AddPersonParameters parameters)
    {
        var personId = await Mediator.Send(new AddPersonCommand(parameters));
        return Created(string.Empty, personId.ToString());
    }

    /// <summary>
    /// Изменить атрибуты человека
    /// </summary>
    /// <param name="id"></param>
    /// <param name="parameters"></param>
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<IActionResult> UpdatePerson([FromRoute]string id, [FromBody] UpdatePersonParameters parameters)
    {
        var personId = PersonId.FromString(id);
        _ = await Mediator.Send(new UpdatePersonCommand(personId, parameters));
        return NoContent();
    }

    /// <summary>
    /// Добавить номер телефона
    /// </summary>
    /// <param name="id"></param>
    /// <param name="parameters"></param>
    [HttpPost("{id}/AddPhone")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<IActionResult> AddPhone([FromRoute]string id, [FromBody] AddPhoneParameters parameters)
    {
        var personId = PersonId.FromString(id);
        _ = await Mediator.Send(new AddPhoneCommand(personId, parameters));
        return NoContent();
    }
    
    /// <summary>
    /// Удалить номер телефона
    /// </summary>
    /// <param name="id"></param>
    /// <param name="parameters"></param>
    [HttpPost("{id}/RemovePhone")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<IActionResult> RemovePhone([FromRoute]string id, [FromBody] RemovePhoneParameters parameters)
    {
        var personId = PersonId.FromString(id);
        _ = await Mediator.Send(new RemovePhoneCommand(personId, parameters));
        return NoContent();
    }

    /// <summary>
    /// Удалить человека
    /// </summary>
    /// <param name="id"></param>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeletePerson([FromRoute]string id)
    {
        var personId = PersonId.FromString(id);
        _ = await Mediator.Send(new DeletePersonCommand(personId));
        return NoContent();
    }
}