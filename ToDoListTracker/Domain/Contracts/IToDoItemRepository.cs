using ToDoListTracker.Domain.Entities;
using ToDoListTracker.Domain.Models;
using ToDoListTracker.Domain.Models.Criteria;
using ToDoItemDb = ToDoListTracker.Domain.Entities.ToDoItem;

namespace ToDoListTracker.Domain.Contracts;

public interface IToDoItemRepository : IRepository<ToDoItemDb, Guid>
{
	Task<PagedList<ToDoItem>> Search(SearchToDoItemCriteria searchCriteria, CancellationToken cancellationToken);
}