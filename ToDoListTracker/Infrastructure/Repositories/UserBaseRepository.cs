using ToDoListTracker.Domain.Contracts;
using ToDoListTracker.Domain.Entities;

namespace ToDoListTracker.Infrastructure.Repositories;

public class UserBaseRepository : BaseRepository<User, Guid>, IUserRepository
{
	public UserBaseRepository(ToDoListDbContext context) : base(context)
	{
	}
}