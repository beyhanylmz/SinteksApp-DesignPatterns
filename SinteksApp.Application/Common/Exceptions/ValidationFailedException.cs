using Microsoft.AspNetCore.Http;

namespace SinteksApp.Application.Common.Exceptions;

public sealed class ValidationFailedException : AppException
{
    public ValidationFailedException(IEnumerable<string> errors, string? message = null)
        : base(message ?? "Validation failed")
    {
        Errors = errors.ToList();
    }

    public override int StatusCode => StatusCodes.Status422UnprocessableEntity;
    public override IReadOnlyList<string>? Errors { get; }
}