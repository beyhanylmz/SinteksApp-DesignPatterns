using Mapster;
using SinteksApp.Application.Features.Discount.Commands;
using SinteksApp.Domain.Entities;

namespace SinteksApp.Application.Features.Discount;

public class DiscountMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        TypeAdapterConfig<CreateDiscountCommand, Domain.Entities.Discount>.NewConfig()
            .Map(dest => dest.Name, src => src.Name.Trim())
            .Map(dest => dest.Type, src => src.Type)
            .Map(dest => dest.DiscountPercent, src => src.DiscountPercent)
            .Map(dest => dest.StartDate, src => src.StartDate)
            .Map(dest => dest.EndDate, src => src.EndDate)
            .Map(dest => dest.Priority, src => src.Priority)
            .Map(dest => dest.IsActive, src => src.IsActive)
            .Map(dest => dest.Branches, src =>
                Normalize(src.BranchIds)
                    .Select(x => new DiscountBranch { BranchId = x })
                    .ToList())
            .Map(dest => dest.Products, src =>
                Normalize(src.ProductIds)
                    .Select(x => new DiscountProduct { ProductId = x })
                    .ToList())
            .Map(dest => dest.Categories, src =>
                Normalize(src.CategoryIds)
                    .Select(x => new DiscountCategory { CategoryId = x })
                    .ToList())
            .Map(dest => dest.Brands, src =>
                Normalize(src.BrandIds)
                    .Select(x => new DiscountBrand { BrandId = x })
                    .ToList())
            .Map(dest => dest.ExcludedProducts, src =>
                Normalize(src.ExcludedProductIds)
                    .Select(x => new DiscountExcludedProduct { ProductId = x })
                    .ToList());
    }

    private static List<int> Normalize(IEnumerable<int>? ids)
    {
        return (ids ?? Enumerable.Empty<int>())
            .Where(x => x > 0)
            .Distinct()
            .ToList();
    }
}