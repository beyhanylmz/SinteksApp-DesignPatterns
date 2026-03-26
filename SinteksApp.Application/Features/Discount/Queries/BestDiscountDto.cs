namespace SinteksApp.Application.Features.Discount.Queries;

public record BestDiscountDto(
    int? DiscountId,
    decimal DiscountPercent
);