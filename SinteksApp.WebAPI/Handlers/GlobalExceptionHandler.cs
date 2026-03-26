using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using FluentResults;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using SinteksApp.Application.Common.Errors;
using SinteksApp.Application.Common.Exceptions;

namespace SinteksApp.WebAPI.Handlers;

public class GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger) : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        var trackId = (httpContext.Items["TrackId"] as string) 
                      ?? Guid.NewGuid().ToString("D");
        int statusCode;
        Result failResult;

        switch (exception)
        {
            case ValidationFailedException vex:
                failResult = Result.Fail(new ValidationError(vex.Message, vex.Errors));
                statusCode = vex.StatusCode;
                break;
            case AppException aex:
                statusCode = aex.StatusCode;
                failResult = Result.Fail(new Error(aex.Message));
                break;
            default:
                statusCode = StatusCodes.Status500InternalServerError;
                failResult = Result.Fail(new Error("Internal server error"));
                break;
        }
        
        logger.LogError(exception, "Unhandled error. TrackId: {TrackId}", trackId);

        httpContext.Response.StatusCode = statusCode;
        httpContext.Response.ContentType = "application/json";
       
        var errorsList = failResult.Errors
            .SelectMany(e => 
                    (e.Metadata != null)
                        ? e.Metadata.Values.OfType<string>() 
                        : [e.Message]
            )
            .ToList();

        var response = new FailResponse(
            failResult.Errors.FirstOrDefault()?.Message ?? "Error",
            errorsList,
            trackId
        );


        var json = JsonSerializer.Serialize(response, new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        });
        
        await httpContext.Response.WriteAsync(json, cancellationToken);
        return true;
    }
    
    private record FailResponse(string Message, List<string> Errors, string TrackId);
}