using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using SinteksApp.Application.Common.Behaviours;
using SinteksApp.Application.Features.Bonus;
using SinteksApp.Application.Features.Branch.Commands;
using SinteksApp.Application.Features.Discount;
using SinteksApp.Application.Mappings;

namespace SinteksApp.Application;

public static class ServiceExtensions
{
    public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
    {
        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssemblies(typeof(CreateBranchCommand).Assembly);
            configuration.AddOpenBehavior(typeof(LoggingPipelineBehaviour<,>));
            configuration.AddOpenBehavior(typeof(ValidationPipelineBehaviour<,>));
        });
        services.AddValidatorsFromAssembly(typeof(ServiceCollectionExtensions).Assembly);
        
        services.AddScoped<IBonusCalculationStrategy, FixedBonusStrategy>();
        services.AddScoped<IBonusCalculationStrategy, PercentBonusStrategy>();
        services.AddScoped<IBonusCalculationStrategy, ChampionshipTopNBonusStrategy>();
        services.AddScoped<IBonusCalculationStrategy, OverLimitPoolBonusStrategy>();
        services.AddScoped<IBonusCalculationStrategy, CombinedBonusStrategy>();
        services.AddScoped<IBonusStrategyFactory, BonusStrategyFactory>();
        
        services.AddScoped<IDiscountStrategy, ProductStrategy>();
        services.AddScoped<IDiscountStrategy, CategoryStrategy>();
        services.AddScoped<IDiscountStrategy, BrandStrategy>();
        services.AddScoped<IDiscountEngine, DiscountEngine>();
        MapsterConfig.Register();
        return services;
    }
}