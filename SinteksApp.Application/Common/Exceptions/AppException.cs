using Microsoft.AspNetCore.Http;

namespace SinteksApp.Application.Common.Exceptions;

public class AppException : Exception
{
    public AppException(string message) : base(message) { }
    public virtual int StatusCode => StatusCodes.Status400BadRequest;
    public virtual IReadOnlyList<string>? Errors => null;
}