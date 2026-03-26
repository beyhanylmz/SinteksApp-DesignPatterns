using SinteksApp.Application.Common.UnitOfWork;
using SinteksApp.Persistence.Context;

namespace SinteksApp.Persistence;

public class UnitOfWork(SinteksAppDbContext dbContext) : IUnitOfWork
{
    private readonly SinteksAppDbContext _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public void Dispose() => _dbContext.Dispose();
}