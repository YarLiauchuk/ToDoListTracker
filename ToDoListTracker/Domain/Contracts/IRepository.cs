namespace ToDoListTracker.Domain.Contracts;

public interface IRepository<TEntity, TKey>
	where TEntity : class, IEntity<TKey>
	where TKey : struct
{
	Task<TEntity> GetById(TKey id, bool asNoTracking = false, CancellationToken cancellationToken = default);

	Task<List<TEntity>> GetAll(CancellationToken cancellationToken = default);

	Task<TEntity> Add(TEntity entity, CancellationToken cancellationToken = default);
	
	Task Update(TEntity entity, CancellationToken cancellationToken = default);
	
	Task Delete(TEntity entity, CancellationToken cancellationToken = default);
	
	Task<bool> IsExist(TKey id, CancellationToken cancellationToken = default);
}