using Ardalis.Specification;
using FluentResults;
using MediatR;
using SinteksApp.Application.Features.Sale.Specs;

namespace SinteksApp.Application.Features.Sale.Commands;

public record ReturnSaleCommand(int SaleId)
    : IRequest<Result>;

public class ReturnSaleCommandHandler(
    IRepositoryBase<Domain.Entities.Sale> saleRepository,
    IRepositoryBase<Domain.Entities.Stock> stockRepository)
    : IRequestHandler<ReturnSaleCommand, Result>
{
    public async Task<Result> Handle(ReturnSaleCommand request, CancellationToken cancellationToken)
    {
        var now = DateTime.UtcNow;
        var sale = await saleRepository.GetByIdAsync(request.SaleId, cancellationToken);

        if (sale is null)
            return Result.Fail("Sale not found");

        if (sale.IsReturned)
            return Result.Fail("Already returned");

        if (sale.SaleDate < DateTime.UtcNow.AddDays(-14))
            return Result.Fail("Return period expired");

        var stock = await stockRepository.FirstOrDefaultAsync(
            new StockByBranchAndProductSpec(
                sale.BranchId,
                sale.ProductId),
            cancellationToken);
        if (stock is null)
            return Result.Fail("Stock not found");
        
        stock?.Quantity += sale.Quantity;
        sale.IsReturned = true;
        sale.ReturnDate = now;
        
        await stockRepository.UpdateAsync(stock, cancellationToken);
        await saleRepository.UpdateAsync(sale, cancellationToken);

        await saleRepository.SaveChangesAsync(cancellationToken);

        return Result.Ok();
    }
}