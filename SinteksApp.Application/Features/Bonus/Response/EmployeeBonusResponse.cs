namespace SinteksApp.Application.Features.Bonus.Response;

public record EmployeeBonusResponse(
    bool IsEligible,
    decimal BonusAmount,
    string? Reason
);
