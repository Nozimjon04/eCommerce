using eCommerce.Data.DbContexts;
using eCommerce.Data.IRepositories;
using eCommerce.Domain.Commons;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace eCommerce.Data.Repositories;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : Auditable
{
	private readonly AppDbContext dbContext;
	private readonly DbSet<TEntity> dbset;
	public Repository(AppDbContext appDbContext)
	{
		this.dbContext = appDbContext;
		this.dbset= dbContext.Set<TEntity>();
	}
	public async Task<bool> DeleteAsync(Expression<Func<TEntity, bool>> predicate)
	{
		var entity=await dbset.FirstOrDefaultAsync(predicate);
		if (entity == null)
		{
			return false;
		}
		dbset.Remove(entity);
		return true;
	}

	public async Task<TEntity> InsertAsync(TEntity entity)
	{
		var result = await dbset.AddAsync(entity);
		return result.Entity;
		
	}

	public async Task<bool> SaveAsync()
	{
		return await dbContext.SaveChangesAsync()>0;
		
	}

	public IQueryable<TEntity> SelectAllAsync() => dbset;
	
	

	public async Task<TEntity> SelectAsync(Expression<Func<TEntity, bool>> predicate)
	{
		var entity = await dbset.FirstOrDefaultAsync(predicate);
		if (entity == null)
		{
			return null;
		}
		return entity;
	}

	public async Task<TEntity> UpdateAsync(TEntity entity)
	{
		var result=dbset.Update(entity);
		return  result.Entity;
	}
}
