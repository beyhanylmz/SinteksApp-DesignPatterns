using Mapster;
using SinteksApp.Application.Features.ProductCategory.Commands;
using SinteksApp.Application.Features.ProductCategory.Response;

namespace SinteksApp.Application.Features.ProductCategory;

public class ProductCategoryMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        TypeAdapterConfig<Domain.Entities.ProductCategory, ProductCategoryListResponse>.NewConfig();
        TypeAdapterConfig<Domain.Entities.ProductCategory, ProductCategoryDetailResponse>.NewConfig();
        TypeAdapterConfig<CreateProductCategoryCommand, Domain.Entities.ProductCategory>.NewConfig();
        TypeAdapterConfig<UpdateProductCategoryCommand, Domain.Entities.ProductCategory>.NewConfig();
    }
}