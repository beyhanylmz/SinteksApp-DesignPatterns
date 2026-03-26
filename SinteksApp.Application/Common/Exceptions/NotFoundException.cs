using Microsoft.AspNetCore.Http;

namespace SinteksApp.Application.Common.Exceptions;

public sealed class NotFoundException(string message = "Resource not found") : AppException(message)
{
    public override int StatusCode => StatusCodes.Status404NotFound;
}
