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

    /// <summary>Метод получения объекта из базы данных по его Id</summary>
    /// <param name="id">Id объекта</param>
    /// <param name="cancellationToken"></param>
    /// <returns>Найденный объект или null</returns>
    public async Task<TEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        => await _context.FirstOrDefaultAsync(x => x.Id == id);


    /// <summary>
    /// Метод получения списока всех объектов данного типа
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns>Список всех объектов данного или null</returns>
    public async Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _context.ToListAsync(cancellationToken);
    }

    /// <summary>
    /// Метод получения всех объектов данного типа соответствующих переданному условию
    /// </summary>
    /// <param name="predicate">Условие отбора</param>
    /// <param name="cancellationToken"></param>
    /// <returns>Список всех объектов соответствуюх переданному условию или null</returns>
    public async Task<IEnumerable<TEntity>> WhereAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken)
        => await _context.Where(predicate).ToListAsync(cancellationToken);

    /// <summary>
    /// Метод получения флага наличия хотя бы одного объекта данного типа, соответствующего переданному условию в базе данных
    /// </summary>
    /// <param name="predicate">Условие отбора</param>
    /// <param name="cancellationToken"></param>
    /// <returns>флаг наличия хотя бы одного объекта данного типа, соответствующего переданному условию в базе данных</returns>
    public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken)
        => await _context.AnyAsync(predicate, cancellationToken);

    /// <summary>
    /// Метод создания нового объекта в обазе данных
    /// </summary>
    /// <param name="entity">Объект</param>
    /// <param name="cancellationToken"></param>
    public async Task AddAsync(TEntity entity, CancellationToken cancellationToken)
        => await _context.AddAsync(entity);

    /// <summary>
    /// Метод обновления объекта в базе данных
    /// </summary>
    /// <param name="entity">Объект</param>
    public void Update(TEntity entity)
        => _context.Update(entity);

    /// <summary>
    /// Метод удаления объекта в базе данных
    /// </summary>
    /// <param name="entity">Объект</param>
    public void Remove(TEntity entity)
      => _context.Remove(entity);
}