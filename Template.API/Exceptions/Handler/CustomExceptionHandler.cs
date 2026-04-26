using Azure;
using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading;
using Template.Application.Common;
using Template.Application.Common.Exceptions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Template.API.Exceptions.Handler;
public class CustomExceptionHandler(ILogger<CustomExceptionHandler> logger) : IExceptionHandler
{

    public async ValueTask<bool> TryHandleAsync(HttpContext context,Exception exception,CancellationToken cancellationToken)
    {
        logger.LogError(exception,
            "Error Message: {exceptionMessage}, Time: {time}",
            exception.Message,
            DateTime.UtcNow);

        var (message, statusCode, errorCode, errors) = exception switch
        {
            ValidationException ex => (
                "Validation failed",
                StatusCodes.Status400BadRequest,
                ErrorCodes.Validation,
                ex.Errors?.Select(e => e.ErrorMessage).ToList()
            ),

            BadRequestException ex => (
                ex.Message,
                StatusCodes.Status400BadRequest,
                ErrorCodes.BadRequest,
                new List<string> { ex.Message }
            ),

            NotFoundException ex => (
                ex.Message,
                StatusCodes.Status404NotFound,
                ErrorCodes.NotFound,
                new List<string> { ex.Message }
            ),

            InternalServerException ex => (
                ex.Message,
                StatusCodes.Status500InternalServerError,
                ErrorCodes.InternalServer,
                new List<string> { ex.Message }
            ),

            _ => (
                "An unexpected error occurred",
                StatusCodes.Status500InternalServerError,
                ErrorCodes.InternalServer,
                new List<string> { exception.Message }
            )
        };

        var response = GlobalApiResponse<object>.FailureResponse(
            message,
            errors,
            statusCode,
            errorCode
        );

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = statusCode;

        await context.Response.WriteAsJsonAsync(response, cancellationToken);

        return true;
    }
}
