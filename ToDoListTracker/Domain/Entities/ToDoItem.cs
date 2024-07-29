namespace ToDoListTracker.Domain.Entities;

public class ToDoItem : EntityBase<Guid>
{
	public ToDoItem(){}
	
	public ToDoItem(Guid id, string title, bool isCompleted,
		DateTime? dueDate, Guid priorityId, Guid? userId)
	{
		Id = id;
		Title = title;
		IsCompleted = isCompleted;
		DueDate = dueDate;
		PriorityId = priorityId;
		UserId = userId;
	}
	
	public string Title { get; set; }
	
	public string? Description { get; set; }
	
	public bool IsCompleted { get; set; }
	public bool IsDeleted { get; set; }
	
	public DateTime? DueDate { get; set; }
	
	public Guid PriorityId { get; set; }
	public Priority Priority { get; set; }
	
	public Guid? UserId { get; set; }
	public User User { get; set; }
}