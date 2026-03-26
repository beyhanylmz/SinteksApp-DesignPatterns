namespace SinteksApp.Application.Features.Branch.Response;

public record BranchStockResponse
(   int BranchId,
    string BranchName,
    int AvailableQuantity);