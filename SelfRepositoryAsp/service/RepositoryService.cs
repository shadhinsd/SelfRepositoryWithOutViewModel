
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using SelfRepositoryAsp.DatabaseContext;

namespace SelfRepositoryAsp.service;

public class RepositoryService<TEntity> : IRepositoryService<TEntity> where TEntity : class
{
    private readonly EmployeeDbContext dbContext;

    public RepositoryService(EmployeeDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    public async Task<TEntity> DeleteByIdAsync(long id)
    {
        if (id==0)
        {
            return null;
        }
        else
        {
            var data=await dbContext.Set<TEntity>().FindAsync(id);
            dbContext.Set<TEntity>().Remove(data);
            await dbContext.SaveChangesAsync();
            return data;
        }
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        var data=await dbContext.Set<TEntity>().AsNoTracking().ToListAsync();
        return data;
    }

    public async Task<TEntity> GetByIdAsync(long id)
    {
        if (id==0)
        {
            return null;
        }
        else
        {
            var data = await dbContext.Set<TEntity>().FindAsync(id);
            return data;
        }
    }

    public async Task<TEntity> InsertAsync(TEntity entity)
    {   
        var data= dbContext.Set<TEntity>().Add(entity);
        await dbContext.SaveChangesAsync();
        return entity;
    }

    public async Task<TEntity> UpdateAsync(long id, TEntity entity)
    {
        if (id==0)
        {
            return null;
        }
        else
        {
            var data= dbContext.Set<TEntity>().Update(entity);
            await dbContext.SaveChangesAsync();
            return entity;
        }
    }
}