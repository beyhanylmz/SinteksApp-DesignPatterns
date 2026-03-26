using Mapster;
using SinteksApp.Application.Features.Product.Commands;
using SinteksApp.Application.Features.Product.Response;

namespace SinteksApp.Application.Features.Product;

public class ProductMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        TypeAdapterConfig<Domain.Entities.Product, ProductListResponse>.NewConfig();
        TypeAdapterConfig<Domain.Entities.Product, ProductDetailResponse>.NewConfig();
        TypeAdapterConfig<CreateProductCommand, Domain.Entities.Product>.NewConfig();
        TypeAdapterConfig<UpdateProductCommand, Domain.Entities.Product>.NewConfig();
    }
}