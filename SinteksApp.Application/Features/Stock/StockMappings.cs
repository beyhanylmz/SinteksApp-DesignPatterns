using Mapster;
using SinteksApp.Application.Features.Stock.Commands;
using SinteksApp.Application.Features.Stock.Response;

namespace SinteksApp.Application.Features.Stock;

public class StockMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        TypeAdapterConfig<Domain.Entities.Stock, StockListResponse>.NewConfig();
        TypeAdapterConfig<Domain.Entities.Stock, StockDetailResponse>.NewConfig();
        TypeAdapterConfig<CreateStockCommand, Domain.Entities.Stock>.NewConfig();
        TypeAdapterConfig<UpdateStockCommand, Domain.Entities.Stock>.NewConfig();
    }
}