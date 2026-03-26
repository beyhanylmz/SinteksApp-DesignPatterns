using Ardalis.Specification;

namespace SinteksApp.Application.Features.Brand.Specs;

public sealed class BrandWithAssignmentsSpec : Specification<Domain.Entities.Brand>
{
    public BrandWithAssignmentsSpec(int brandId)
    {
        Query.Where(x => x.Id == brandId)
            .Include(x => x.SubCompanyAssignments);
    }
}