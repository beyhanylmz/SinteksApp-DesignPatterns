namespace SinteksApp.Domain.Enums;

public enum BonusType
{
    Fixed = 1,
    Percent = 2,
    ChampionshipTopN = 3,
    OverLimitPool = 4,
    Combined = 5 // personal + extra if store limit exceeded
}