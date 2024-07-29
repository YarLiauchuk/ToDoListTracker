using ToDoListTracker.Domain.Enums;

namespace ToDoListTracker.Domain.Models;

public record PagedRequest
{
	public int Take { get; set; }
	public int Skip { get; set; }
	public List<SortExpression>? SortExpressions { get; set; }
}

public record SortExpression
{
	public SortDirection Direction { get; set; }

	public string PropertyName { get; set; }
}