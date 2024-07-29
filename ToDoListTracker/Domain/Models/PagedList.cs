namespace ToDoListTracker.Domain.Models;

public class PagedList<T>
{
	public int TotalCount { get; set; }

	public List<T> Items { get; set; } = new List<T>();
}