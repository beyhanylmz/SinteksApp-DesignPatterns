using Ardalis.Specification;
using FluentResults;
using MediatR;
using SinteksApp.Application.Features.Discount.Queries;
using SinteksApp.Application.Features.Sale.Specs;

namespace SinteksApp.Application.Features.Sale.Commands;
public record CreateSaleCommand(
    int BranchId,
    int ProductId,
    int Quantity,
    int EmployeeId,
    int? CustomerId
) : IRequest<Result<int>>;

public class CreateSaleCommandHandler(
    IRepositoryBase<Domain.Entities.Sale> saleRepository,
    IRepositoryBase<Domain.Entities.Stock> stockRepository,
    IRepositoryBase<Domain.Entities.Product> productRepository,
    IMediator mediator)
    : IRequestHandler<CreateSaleCommand, Result<int>>
{
    public async Task<Result<int>> Handle(
        CreateSaleCommand request,
        CancellationToken cancellationToken)
    {
        var stock = await stockRepository.FirstOrDefaultAsync(
            new StockByBranchAndProductSpec(request.BranchId, request.ProductId),
            cancellationToken);

        if (stock == null || stock.Quantity < request.Quantity)
            return Result.Fail("Insufficient stock");

        var product = await productRepository.GetByIdAsync(request.ProductId, cancellationToken);
        if (product == null)
            return Result.Fail("Product not found");

        var discountResult = await mediator.Send(
            new GetBestDiscountForSaleQuery(
                request.BranchId,
                request.ProductId,
                product.ProductCategoryId,
                product.BrandId,
                DateTime.UtcNow),
            cancellationToken);

        if (discountResult.IsFailed)
            return Result.Fail(discountResult.Errors.Select(x => x.Message));

        var bestDiscount = discountResult.Value;

        var unitPrice = product.BaseSalePrice;
        var grossAmount = unitPrice * request.Quantity;
        var discountPercentage = bestDiscount.DiscountPercent;
        var discountAmount = grossAmount * discountPercentage / 100m;
        var netAmount = grossAmount - discountAmount;

        stock.Quantity -= request.Quantity;

        var sale = new Domain.Entities.Sale
        {
            BranchId = request.BranchId,
            ProductId = request.ProductId,
            Quantity = request.Quantity,
            EmployeeId = request.EmployeeId,
            CustomerId = request.CustomerId,
            BasePrice = unitPrice,
            DiscountedPrice = discountAmount,
            NetPrice = netAmount,
            DiscountPercent = discountPercentage,
            SaleDate = DateTime.UtcNow
        };

        await saleRepository.AddAsync(sale, cancellationToken);
        await stockRepository.UpdateAsync(stock, cancellationToken);

        await saleRepository.SaveChangesAsync(cancellationToken);

        return Result.Ok(sale.Id);
    }
}
