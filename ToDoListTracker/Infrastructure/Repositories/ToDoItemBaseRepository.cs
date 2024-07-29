using Microsoft.EntityFrameworkCore;
using ToDoListTracker.Infrastructure.Repositories.Extensions;
using ToDoListTracker.Domain.Contracts;
using ToDoListTracker.Domain.Entities;
using ToDoListTracker.Domain.Models;
using ToDoListTracker.Domain.Models.Criteria;

namespace ToDoListTracker.Infrastructure.Repositories;

public class ToDoItemBaseRepository : BaseRepository<ToDoItem, Guid>, IToDoItemRepository
{
	private static readonly string EscapeCharacter = "\\";

	public ToDoItemBaseRepository(ToDoListDbContext context) : base(context)
	{
	}

	public async Task<PagedList<ToDoItem>> Search(SearchToDoItemCriteria searchCriteria,
		CancellationToken cancellationToken)
	{
		var query = EntitiesDbSet
			.Include(x => x.User)
			.Include(x => x.Priority)
			.Where(x => !x.IsDeleted)
			.AsNoTracking();

		if (!string.IsNullOrWhiteSpace(searchCriteria.Keyword))
		{
			query = query.Where(x => EF.Functions.ILike(x.Title, searchCriteria.Keyword, EscapeCharacter)
			                         || EF.Functions.ILike(x.Description, searchCriteria.Keyword, EscapeCharacter));
		}

		if (searchCriteria.SortExpressions.Any())
		{
			query = query.OrderByExpressions(searchCriteria.SortExpressions);
		}

		var result = new PagedList<ToDoItem>
		{
			TotalCount = await query.CountAsync(cancellationToken),
		};
		
		result.Items = await query
			.Skip(searchCriteria.Skip)
			.Take(searchCriteria.Take)
			.ToListAsync(cancellationToken);

		return result;
	}
}