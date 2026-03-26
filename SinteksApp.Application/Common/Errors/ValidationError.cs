using FluentResults;

namespace SinteksApp.Application.Common.Errors;

public sealed class ValidationError : Error
{
    public IEnumerable<string> Errors { get; }

    public ValidationError(string message, IEnumerable<string> errors) : base(message)
    {
        Errors = errors;
    }
}