using Microsoft.EntityFrameworkCore;

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
        return await _context.SingleOrDefaultAsync(x => x.Id == id);
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _context.ToListAsync(cancellationToken);
    }

    public async Task AddAsync(TEntity entity, CancellationToken cancellationToken)
    {
        var result = await _context.AddAsync(entity);
    }

    public void UpdateAsync(TEntity entity, CancellationToken cancellationToken)
    {
        var result = _context.Update(entity);
        //var result =  _entities.Entry(entity).State = EntityState.Modified;
    }

    public void Remove(TEntity entity)
    {
        _context.Remove(entity);
    }
}