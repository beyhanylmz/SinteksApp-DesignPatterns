using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SinteksApp.Application.Features.Stock.Commands;
using SinteksApp.Application.Features.Stock.Queries;

namespace SinteksApp.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StockController(IMediator mediator) : BaseController
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await mediator.Send(new GetAllStockQuery());
        return result.IsSuccess ? Ok(result.Value) : MapErrors(result.Errors);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await mediator.Send(new GetStockByIdQuery(id));
        return result.IsSuccess ? Ok(result.Value) : MapErrors(result.Errors);
    }
    
    [HttpGet("checkOtherBranches")]
    public async Task<IActionResult> CheckOtherBranches([FromQuery]CheckOtherBranchesQuery query)
    {
        var result = await mediator.Send(query);
        return result.IsSuccess ? Ok(result.Value) : MapErrors(result.Errors);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateStockCommand command)
    {
        var result = await mediator.Send(command);
        return result.IsSuccess ? NoContent() : MapErrors(result.Errors);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateStockCommand command)
    {
        var result = await mediator.Send(command);
        return result.IsSuccess ? NoContent() : MapErrors(result.Errors);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await mediator.Send(new DeleteStockCommand(id));
        return result.IsSuccess ? NoContent() : MapErrors(result.Errors);
    }
}