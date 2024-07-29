using ToDoListTracker.Domain.Entities;

namespace ToDoListTracker.Domain.Contracts;

public interface IPriorityRepository : IRepository<Priority, Guid>
{
}