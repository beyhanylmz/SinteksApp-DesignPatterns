using Ardalis.Specification;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SinteksApp.Application.Common.UnitOfWork;
using SinteksApp.Persistence.Context;
using SinteksApp.Persistence.Repositories;

namespace SinteksApp.Persistence;

public static class ServiceExtensions
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<SinteksAppDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("Postgres")));
        
        services.AddScoped(typeof(IRepositoryBase<>), typeof(AppRepository<>));
        services.AddScoped(typeof(IReadRepositoryBase<>), typeof(AppRepository<>));
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}