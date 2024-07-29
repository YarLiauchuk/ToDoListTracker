namespace ToDoListTracker.Domain.Entities;

public class Priority : EntityBase<Guid>
{
	public Priority(Guid id, int level)
	{
		Id = id;
		Level = level;
	}
	
	public int Level { get; set; }
	
	public List<ToDoItem> ToDoItems { get; set; }
}