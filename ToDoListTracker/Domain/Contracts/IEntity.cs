namespace ToDoListTracker.Domain.Contracts;

public interface IEntity<TKey>
{
	TKey Id { get; set; }
}