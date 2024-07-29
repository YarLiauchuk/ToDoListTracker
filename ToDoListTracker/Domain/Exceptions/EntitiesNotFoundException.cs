using FluentValidation;

namespace ToDoListTracker.Domain.Exceptions;

public class EntitiesNotFoundException<TKey> : ValidationException
{
	public EntitiesNotFoundException(TKey key, string entity, string fieldName)
		: base($"Entity {entity} by field {fieldName} with key: {key} not found")
	{
	}
}