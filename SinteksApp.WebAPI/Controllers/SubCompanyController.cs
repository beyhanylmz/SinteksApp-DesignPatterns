using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SinteksApp.Application.Features.SubCompany.Commands;
using SinteksApp.Application.Features.SubCompany.Queries;

namespace SinteksApp.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SubCompanyController(IMediator mediator) : BaseController
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await mediator.Send(new GetAllSubCompaniesQuery());
        return result.IsSuccess ? Ok(result.Value) : MapErrors(result.Errors);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await mediator.Send(new GetSubCompanyByIdQuery(id));
        return result.IsSuccess ? Ok(result.Value) : MapErrors(result.Errors);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateSubCompanyCommand command)
    {
        var result = await mediator.Send(command);
        return result.IsSuccess ? NoContent() : MapErrors(result.Errors);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateSubCompanyCommand command)
    {
        var result = await mediator.Send(command);
        return result.IsSuccess ? NoContent() : MapErrors(result.Errors);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await mediator.Send(new DeleteSubCompanyCommand(id));
        return result.IsSuccess ? NoContent() : MapErrors(result.Errors);
    }
}