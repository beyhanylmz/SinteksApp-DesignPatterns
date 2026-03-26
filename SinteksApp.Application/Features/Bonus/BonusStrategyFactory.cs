using SinteksApp.Domain.Enums;

namespace SinteksApp.Application.Features.Bonus;

public class BonusStrategyFactory : IBonusStrategyFactory
{
    private readonly IReadOnlyDictionary<BonusType, IBonusCalculationStrategy> _strategies;

    public BonusStrategyFactory(IEnumerable<IBonusCalculationStrategy> strategies)
    {
        _strategies = strategies.ToDictionary(s => s.Type);
    }

    public IBonusCalculationStrategy GetStrategy(BonusType type) 
        => _strategies.TryGetValue(type, out var strategy) 
            ? strategy 
            : throw new KeyNotFoundException();
}