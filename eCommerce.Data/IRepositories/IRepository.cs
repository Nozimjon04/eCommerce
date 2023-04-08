using eCommerce.Domain.Commons;
using System.Linq.Expressions;

namespace eCommerce.Data.IRepositories;

public interface IRepository<TEntity> where TEntity:Auditable
{
	public Task<TEntity> InsertAsync(TEntity entity);
	public Task<TEntity> UpdateAsync(TEntity entity);
	Task<bool> DeleteAsync(Expression<Func<TEntity, bool>> predicate);
	Task<TEntity> SelectAsync(Expression<Func<TEntity, bool>> predicate);
	IQueryable<TEntity> SelectAllAsync();
	Task<bool> SaveAsync();
}
