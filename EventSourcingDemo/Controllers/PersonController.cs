using EventSourcingDemo.Application.UseCases.AddPerson;
using EventSourcingDemo.Application.UseCases.UpdatePerson;
using EventSourcingDemo.Application.ViewModels;
using EventSourcingDemo.Domain.ValueObjects;
using Microsoft.AspNetCore.Mvc;

namespace EventSourcingDemo.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PersonController : ControllerBase
{
    /// <summary>
    /// Получить список людей
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<PersonViewModel[]> GetAll()
    {
        await Task.Delay(100);
        return new[]
        {
            new PersonViewModel("Erich", "Gamma"),
            new PersonViewModel("Richard", "Helm"),
            new PersonViewModel("Ralph", "Johnson"),
            new PersonViewModel("John", "Vlissides") 
        };
    }

    /// <summary>
    /// Получить одного человека
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<PersonViewModel> GetPerson([FromRoute]string id)
    {
        await Task.Delay(100);
        return new PersonViewModel("Erich", "Gamma");
    }

    /// <summary>
    /// Создать человека
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<string> AddPerson(AddPersonParameters parameters)
    {
        await Task.Delay(100);
        return PersonId.New().ToString();
    }

    /// <summary>
    /// Изменить атрибуты человека
    /// </summary>
    /// <param name="id"></param>
    /// <param name="command"></param>
    [HttpPost("{id}")]
    public async Task UpdatePerson([FromRoute]string id, [FromBody] UpdatePersonCommand command)
    {
        await Task.Delay(100);
    }

    /// <summary>
    /// Удалить человека
    /// </summary>
    /// <param name="id"></param>
    [HttpDelete("{id}")]
    public async Task DeletePerson([FromRoute]string id)
    {
        await Task.Delay(100);
    }
}