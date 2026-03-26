using Ardalis.Specification;
using SinteksApp.Domain.Entities;

namespace SinteksApp.Application.Features.Bonus.Specs;

public class BonusDefinitionForMonthSpec : Specification<BonusDefinition>
{
    public BonusDefinitionForMonthSpec(int branchId, int year, int month)
    {
        Query.Where(x => x.BranchId == branchId && x.Year == year && x.Month == month && x.IsActive)
            .Include(x => x.Rules);
    }
}