using Ardalis.Specification;
using FluentResults;
using MediatR;
using SinteksApp.Application.Common.Errors;
using SinteksApp.Application.Features.Brand.Specs;
using SinteksApp.Domain.Entities;

namespace SinteksApp.Application.Features.Brand.Commands;

public record UpdateBrandCommand(
    int Id,
    string Name,
    int SubCompanyId,
    string? Note = null
) : IRequest<Result>;

public class UpdateBrandCommandHandler(IRepositoryBase<Domain.Entities.Brand> brandRepo ) 
    : IRequestHandler<UpdateBrandCommand, Result>
{
    public async Task<Result> Handle(UpdateBrandCommand request, CancellationToken cancellationToken)
    {
        var brand = await brandRepo.FirstOrDefaultAsync(new BrandWithAssignmentsSpec(request.Id), cancellationToken);

        if (brand is null) return Result.Fail(new NotFoundError($"Brand with Id {request.Id} not found"));

        brand.Name = request.Name.Trim();

        // If subcompany changed -> write history
        if (brand.SubCompanyId != request.SubCompanyId)
        {
            var now = DateTime.UtcNow;

            // close current active assignment (if exists)
            var active = brand.SubCompanyAssignments
                .OrderByDescending(x => x.StartDateUtc)
                .FirstOrDefault(x => x.EndDateUtc == null);

            if (active is not null)
                active.EndDateUtc = now;

            // add new assignment
            brand.SubCompanyAssignments.Add(new BrandSubCompanyAssignment
            {
                BrandId = brand.Id,
                SubCompanyId = request.SubCompanyId,
                StartDateUtc = now,
                EndDateUtc = null,
                Note = request.Note
            });
            brand.SubCompanyId = request.SubCompanyId;
        }

        await brandRepo.UpdateAsync(brand, cancellationToken);
        await brandRepo.SaveChangesAsync(cancellationToken);

        return Result.Ok();
    }
}