using SinteksApp.Domain.Enums;

namespace SinteksApp.Application.Features.Bonus;

public interface IBonusStrategyFactory
{
    IBonusCalculationStrategy GetStrategy(BonusType type);
}