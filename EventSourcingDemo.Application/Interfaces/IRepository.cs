﻿using EventSourcingDemo.Domain.Base;

namespace EventSourcingDemo.Application.Interfaces;

public interface IRepository<TEntity, in TId> where TEntity : Entity<TId> where TId : BaseId
{
    Task<TEntity> this[TId id] { get; }
    Task Add(TEntity entity);
    Task Remove(TEntity entity);
}