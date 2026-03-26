using Mapster;
using SinteksApp.Application.Features.SubCompany.Commands;
using SinteksApp.Application.Features.SubCompany.Response;

namespace SinteksApp.Application.Features.SubCompany;

public class SubCompanyMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        TypeAdapterConfig<Domain.Entities.SubCompany, SubCompanyListResponse>.NewConfig();
        TypeAdapterConfig<Domain.Entities.SubCompany, SubCompanyDetailResponse>.NewConfig();
        TypeAdapterConfig<CreateSubCompanyCommand, Domain.Entities.SubCompany>.NewConfig();
        TypeAdapterConfig<UpdateSubCompanyCommand, Domain.Entities.SubCompany>.NewConfig();
    }
}