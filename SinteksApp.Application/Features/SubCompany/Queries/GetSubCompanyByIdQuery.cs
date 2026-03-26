using Ardalis.Specification;
using FluentResults;
using Mapster;
using MediatR;
using SinteksApp.Application.Common.Errors;
using SinteksApp.Application.Features.SubCompany.Response;

namespace SinteksApp.Application.Features.SubCompany.Queries;

public record GetSubCompanyByIdQuery(int Id) : IRequest<Result<SubCompanyDetailResponse>>;

public class GetSubCompanyByIdQueryHandler(IReadRepositoryBase<Domain.Entities.SubCompany> repo) : IRequestHandler<GetSubCompanyByIdQuery,  Result<SubCompanyDetailResponse>>
{
    public async Task<Result<SubCompanyDetailResponse>> Handle(GetSubCompanyByIdQuery request, CancellationToken cancellationToken) 
    {
        var subCompany = await repo.GetByIdAsync(request.Id,cancellationToken);
        if (subCompany is null)
            return Result.Fail<SubCompanyDetailResponse>(new NotFoundError("SubCompany not found."));
        
        var subCompanyResponse = subCompany.Adapt<SubCompanyDetailResponse>();
        return Result.Ok(subCompanyResponse);
    }
}
