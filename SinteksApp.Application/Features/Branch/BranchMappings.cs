using Mapster;
using SinteksApp.Application.Features.Branch.Commands;
using SinteksApp.Application.Features.Branch.Response;

namespace SinteksApp.Application.Features.Branch;

public class BranchMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        TypeAdapterConfig<Domain.Entities.Branch, BranchListResponse>.NewConfig();
        TypeAdapterConfig<Domain.Entities.Branch, BranchDetailResponse>.NewConfig();
        TypeAdapterConfig<CreateBranchCommand, Domain.Entities.Branch>.NewConfig();
        TypeAdapterConfig<UpdateBranchCommand, Domain.Entities.Branch>.NewConfig();
    }
}