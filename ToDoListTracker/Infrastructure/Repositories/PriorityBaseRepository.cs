using ToDoListTracker.Domain.Contracts;
using ToDoListTracker.Domain.Entities;

namespace ToDoListTracker.Infrastructure.Repositories;

public class PriorityBaseRepository : BaseRepository<Priority, Guid>, IPriorityRepository
{
	public PriorityBaseRepository(ToDoListDbContext context) : base(context)
	{
	}
}