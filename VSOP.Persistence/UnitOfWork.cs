using VSOP.Application.Data;

namespace VSOP.Persistence;

internal class UnitOfWork : IUnitOfWork
{
    private readonly VSEOPContext _dbContext;

    public UnitOfWork(VSEOPContext dbContext) =>
        _dbContext = dbContext;

    public Task SaveChangesAsync(CancellationToken cancellationToken = default) =>
        _dbContext.SaveChangesAsync(cancellationToken);
}