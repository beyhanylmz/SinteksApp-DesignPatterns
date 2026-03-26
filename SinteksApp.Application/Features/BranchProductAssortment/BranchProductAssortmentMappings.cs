using Mapster;
using SinteksApp.Application.Features.BranchProductAssortment.Commands;
using SinteksApp.Application.Features.BranchProductAssortment.Response;

namespace SinteksApp.Application.Features.BranchProductAssortment;

public class BranchProductAssortmentMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        TypeAdapterConfig<Domain.Entities.BranchProductAssortment, BranchProductAssortmentListResponse>.NewConfig();
        TypeAdapterConfig<Domain.Entities.BranchProductAssortment, BranchProductAssortmentDetailResponse>.NewConfig();
        TypeAdapterConfig<CreateBranchProductAssortmentCommand, Domain.Entities.BranchProductAssortment>.NewConfig();
        TypeAdapterConfig<UpdateBranchProductAssortmentCommand, Domain.Entities.BranchProductAssortment>.NewConfig();
    }
}