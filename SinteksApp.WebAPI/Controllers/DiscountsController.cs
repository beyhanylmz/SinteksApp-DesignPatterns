using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SinteksApp.Application.Features.Discount.Commands;
using SinteksApp.Application.Features.Discount.Queries;

namespace SinteksApp.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DiscountsController(IMediator mediator) : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateDiscountCommand cmd)
    {
        var result = await mediator.Send(cmd);
        return result.IsSuccess ? NoContent() : MapErrors(result.Errors);
        
    }

    [HttpGet("best")]
    public async Task<IActionResult> Best([FromQuery] GetBestDiscountForSaleQuery q)
    {
        var result = await mediator.Send(q);
        return result.IsSuccess ? Ok(result.Value) : MapErrors(result.Errors);
    }
}