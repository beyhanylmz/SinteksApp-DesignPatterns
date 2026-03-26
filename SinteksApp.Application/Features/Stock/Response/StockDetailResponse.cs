namespace SinteksApp.Application.Features.Stock.Response;

public record StockDetailResponse(
    int Id,
    int BranchId,
    int ProductId,
    int Quantity,
    int? MinStock,
    int? MaxStock);