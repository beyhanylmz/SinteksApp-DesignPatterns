namespace SinteksApp.Application.Features.BranchProductAssortment.Response;

public record BranchProductAssortmentDetailResponse(
    int Id,
    int BranchId,
    int ProductId,
    bool IsAvailable);