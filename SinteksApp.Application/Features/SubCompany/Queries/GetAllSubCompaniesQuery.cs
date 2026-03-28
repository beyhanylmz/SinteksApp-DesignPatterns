using Ardalis.Specification;
using FluentResults;
using Mapster;
using MediatR;
using SinteksApp.Application.Features.SubCompany.Response;

namespace SinteksApp.Application.Features.SubCompany.Queries;

public record GetAllSubCompaniesQuery : IRequest<Result<List<SubCompanyListResponse>>>;

public class GetAllSubCompaniesQueryHandler(IReadRepositoryBase<Domain.Entities.SubCompany> repo)
    : IRequestHandler<GetAllSubCompaniesQuery, Result<List<SubCompanyListResponse>>>
{
    public async Task<Result<List<SubCompanyListResponse>>> Handle(GetAllSubCompaniesQuery request,
        CancellationToken cancellationToken)
    {
        var data = await repo.ListAsync(cancellationToken);
        var result = data.Adapt<List<SubCompanyListResponse>>();
        return Result.Ok(result);
    }
}