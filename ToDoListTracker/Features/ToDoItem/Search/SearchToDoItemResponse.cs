namespace ToDoListTracker.Features.ToDoItem.Search;

public class SearchToDoItemResponse
{
	public Guid Id { get; set; }
	
	public string Title { get; set; }
	
	public string Description { get; set; }
	
	public bool IsCompleted { get; set; }
	
	public DateTime? DueDate { get; set; }
	
	public SearchToDoItemPriorityResponse Priority { get; set; }
	
	public SearchToDoItemUserResponse User { get; set; }
}

public class SearchToDoItemPriorityResponse
{
	public int Level { get; set; }
}

public class SearchToDoItemUserResponse
{
	public string Name { get; set; }
}