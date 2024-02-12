using System.Linq.Expressions;

namespace VSOP.Domain.Primitives;

public interface IRepository<TEntity> where TEntity : class
{
    public Task<TEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken);

    public Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken);
    public Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken);

    public Task AddAsync(TEntity entity, CancellationToken cancellationToken);

    public void Update(TEntity entity, CancellationToken cancellationToken);

    public void Remove(TEntity entity);
}