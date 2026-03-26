using FluentResults;

namespace SinteksApp.Application.Common.Errors;

public class NotFoundError(string message) : Error(message);
