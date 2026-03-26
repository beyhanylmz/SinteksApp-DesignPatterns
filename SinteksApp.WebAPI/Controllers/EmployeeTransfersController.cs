using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SinteksApp.Application.Features.Employee.Commands;

namespace SinteksApp.WebAPI.Controllers;

[ApiController]
[Route("api/employee/transfers")]
public class EmployeeTransfersController(IMediator mediator) : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateEmployeeTransferCommand cmd)
    {
        var result = await mediator.Send(cmd);
        return result.IsSuccess ? NoContent() : MapErrors(result.Errors);
    }
}