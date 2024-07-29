using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ToDoListTracker.Domain.Contracts;

namespace ToDoListTracker.Infrastructure.Repositories;

public class BaseRepository<TEntity, TKey>
	where TEntity : class, IEntity<TKey>
	where TKey : struct
{
	protected readonly DbContext Context;
	protected readonly DbSet<TEntity> EntitiesDbSet;

	protected BaseRepository(DbContext context)
	{
		Context = context;
		EntitiesDbSet = context.Set<TEntity>();
	}
	
	public virtual Task<TEntity> GetById(
		TKey id,
		bool asNoTracking = false,
		CancellationToken cancellationToken = default)
	{
		return (asNoTracking ? EntitiesDbSet.AsNoTracking() : (IEnumerable<TEntity>) EntitiesDbSet).AsQueryable().SingleOrDefaultAsync(x => x.Id.Equals(id));
	}
	
	public async Task<List<TEntity>> GetAll(
		CancellationToken cancellationToken = default)
	{
		return await EntitiesDbSet.AsNoTracking().ToListAsync(cancellationToken);
	}

	public virtual async Task<TEntity> Add(TEntity entity,
		CancellationToken cancellationToken = default)
	{
		EntityEntry<TEntity> entry = await EntitiesDbSet.AddAsync(entity, cancellationToken);
		await Save(cancellationToken);
		TEntity entity1 = entry.Entity;
		return entity1;
	}

	public virtual async Task Update(TEntity entity, CancellationToken cancellationToken = default)
	{
		EntitiesDbSet.Update(entity);
		await Save(cancellationToken);
	}

	public virtual async Task Delete(TEntity entity, CancellationToken cancellationToken = default)
	{
		EntitiesDbSet.Remove(entity);
		await Save(cancellationToken);
	}
	
	public virtual Task<bool> IsExist(TKey id, CancellationToken cancellationToken = default)
	{
		return EntitiesDbSet.AsNoTracking().AnyAsync(x => x.Id.Equals(id));
	}

	public virtual Task Save(CancellationToken cancellationToken = default)
	{
		return Context.SaveChangesAsync(cancellationToken);
	}
}