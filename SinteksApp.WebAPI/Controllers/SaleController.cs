using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SinteksApp.Application.Features.Sale.Commands;

namespace SinteksApp.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SaleController(IMediator mediator) : BaseController
{
    // [HttpGet]
    // public async Task<IActionResult> GetAll()
    // {
    //     var result = await mediator.Send(new GetAllSaleQuery());
    //     return result.IsSuccess ? Ok(result.Value) : MapErrors(result.Errors);
    // }
    //
    // [HttpGet("{id}")]
    // public async Task<IActionResult> GetById(int id)
    // {
    //     var result = await mediator.Send(new GetSaleByIdQuery(id));
    //     return result.IsSuccess ? Ok(result.Value) : MapErrors(result.Errors);
    // }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateSaleCommand command)
    {
        var result = await mediator.Send(command);
        return result.IsSuccess ? NoContent() : MapErrors(result.Errors);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] ReturnSaleCommand command)
    {
        var result = await mediator.Send(command);
        return result.IsSuccess ? NoContent() : MapErrors(result.Errors);
    }

    // [HttpDelete("{id}")]
    // public async Task<IActionResult> Delete(int id)
    // {
    //     var result = await mediator.Send(new DeleteStockCommand(id));
    //     return result.IsSuccess ? NoContent() : MapErrors(result.Errors);
    // }
}