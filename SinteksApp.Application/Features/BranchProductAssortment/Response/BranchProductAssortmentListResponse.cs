namespace SinteksApp.Application.Features.BranchProductAssortment.Response;

public record BranchProductAssortmentListResponse(
    int Id,
    int BranchId,
    int ProductId,
    bool IsAvailable);