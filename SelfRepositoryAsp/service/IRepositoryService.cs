namespace SelfRepositoryAsp.service;

public interface IRepositoryService<TEntity> where TEntity : class
{
    Task<IEnumerable<TEntity>> GetAllAsync();
    Task<TEntity> GetByIdAsync(long id);
    Task<TEntity> InsertAsync(TEntity entity);
    Task<TEntity> UpdateAsync(long id,TEntity entity);
    Task<TEntity> DeleteByIdAsync(long id);
}
