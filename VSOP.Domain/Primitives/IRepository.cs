namespace VSOP.Domain.Primitives;

public interface IRepository<TEntity> where TEntity : class
{
    public Task<TEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken);

    public Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken);

    public Task AddAsync(TEntity entity, CancellationToken cancellationToken);

    public void UpdateAsync(TEntity entity, CancellationToken cancellationToken);

    public void Remove(TEntity entity);
}