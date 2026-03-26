using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SinteksApp.Application.Features.Bonus.Queries;

namespace SinteksApp.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BonusController(IMediator mediator) : BaseController
{
    [HttpGet("calculate")]
    public async Task<IActionResult> Calculate([FromQuery] CalculateEmployeeBonusQuery query)
    {
        var result = await mediator.Send(query);
        return result.IsSuccess ? Ok(result.Value) : MapErrors(result.Errors);
    }
}