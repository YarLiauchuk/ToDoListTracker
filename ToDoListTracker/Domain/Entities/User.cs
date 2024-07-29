namespace ToDoListTracker.Domain.Entities;

public class User : EntityBase<Guid>
{
	public User(Guid id, string name)
	{
		Id = id;
		Name = name;
	}
	
	public string Name { get; set; }
	
	public ICollection<ToDoItem> ToDoItems { get; set; }
}