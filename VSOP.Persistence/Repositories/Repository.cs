using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using VSOP.Domain.Primitives;

namespace VSOP.Persistence.Repositories;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
{
    protected readonly DbSet<TEntity> _context;

    public Repository(DbContext context)
    {
        _context = context.Set<TEntity>();
    }

    public async Task<TEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _context.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _context.ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<TEntity>> WhereAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken)
    {
        return await _context.Where(predicate).ToListAsync(cancellationToken);
    }

    public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken)
    {
        return await _context.AnyAsync(predicate, cancellationToken);
    }

    public async Task AddAsync(TEntity entity, CancellationToken cancellationToken)
        => await _context.AddAsync(entity);

    public void Update(TEntity entity)
        => _context.Update(entity);

    public void Remove(TEntity entity)
    {
        _context.Remove(entity);
    }
}