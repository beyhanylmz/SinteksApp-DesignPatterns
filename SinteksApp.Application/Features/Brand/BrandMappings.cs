using Mapster;
using SinteksApp.Application.Features.Brand.Commands;
using SinteksApp.Application.Features.Brand.Response;

namespace SinteksApp.Application.Features.Brand;

public class BrandMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        TypeAdapterConfig<Domain.Entities.Brand, BrandListResponse>.NewConfig();
        TypeAdapterConfig<Domain.Entities.Brand, BrandDetailResponse>.NewConfig();
        TypeAdapterConfig<CreateBrandCommand, Domain.Entities.Brand>.NewConfig();
        TypeAdapterConfig<UpdateBrandCommand, Domain.Entities.Brand>.NewConfig();
    }
}