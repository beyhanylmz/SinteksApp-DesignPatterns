using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using SinteksApp.Persistence.Context;

namespace SinteksApp.Persistence.Repositories;

public class AppRepository<T>
    : RepositoryBase<T>, IRepositoryBase<T>, IReadRepositoryBase<T>
    where T : class
{
    public AppRepository(SinteksAppDbContext dbContext)
        : base(dbContext)
    {
    }
}
