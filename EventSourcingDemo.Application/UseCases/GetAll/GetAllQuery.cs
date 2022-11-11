using EventSourcingDemo.Domain.Entities;
using MediatR;

namespace EventSourcingDemo.Application.UseCases.GetAll;

public record GetAllQuery() : IRequest<Person[]>;