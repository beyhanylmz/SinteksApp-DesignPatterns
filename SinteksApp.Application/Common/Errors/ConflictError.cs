using FluentResults;

namespace SinteksApp.Application.Common.Errors;

public class ConflictError(string message) : Error(message);