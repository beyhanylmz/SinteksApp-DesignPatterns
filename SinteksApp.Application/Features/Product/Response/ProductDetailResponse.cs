namespace SinteksApp.Application.Features.Product.Response;

public record ProductDetailResponse(
    int Id,
    string Name,
    decimal PurchasePrice,
    decimal BaseSalePrice,
    string Color,
    string Size,
    int BrandId,
    int ProductCategoryId);