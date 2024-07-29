using ToDoListTracker.Domain.Contracts;

namespace ToDoListTracker.Domain.Entities;

public abstract class EntityBase<TKey> : IEntity<TKey>
{
	public TKey Id { get; set; }
}