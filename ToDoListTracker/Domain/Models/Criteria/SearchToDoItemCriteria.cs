namespace ToDoListTracker.Domain.Models.Criteria;

public record SearchToDoItemCriteria : PagedRequest
{
	public string Keyword { get; init; }
}