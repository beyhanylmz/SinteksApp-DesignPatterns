using System.Collections.Generic;
using System.Linq;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using SinteksApp.Application.Common.Errors;

namespace SinteksApp.WebAPI.Controllers;

[ApiController]
public abstract class BaseController : ControllerBase
{
    protected IActionResult FromResult(Result result)
    {
        if (result.IsSuccess)
            return Ok();

        return MapErrors(result.Errors);
    }

    protected IActionResult FromResult<T>(Result<T> result)
    {
        if (result.IsSuccess)
            return Ok(result.Value);

        return MapErrors(result.Errors);
    }

    protected IActionResult MapErrors(IReadOnlyList<IError> errors)
    {
        var error = errors.First();

        return error switch
        {
            ValidationError ve => BadRequest(new { message = ve.Message, errors = ve.Errors }),
            NotFoundError => NotFound(new { message = error.Message }),
            ConflictError => Conflict(new { message = error.Message }),
            _ => StatusCode(500, new { message = "Unexpected error occurred" })
        };
    }
}

