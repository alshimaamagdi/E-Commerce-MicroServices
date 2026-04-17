using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Web.Http.ExceptionHandling;

public class CustomExceptionHandler : IExceptionHandler
{
    private readonly ILogger<CustomExceptionHandler> logger;

    public CustomExceptionHandler(ILogger<CustomExceptionHandler> logger)
    {
        this.logger = logger;
    }

    public async ValueTask<bool> TryHandleAsync(
        HttpContext context,
        Exception exception,
        CancellationToken cancellationToken)
    {
        logger.LogError(exception,
            "Error Message: {Message}, Time: {Time}",
            exception.Message,
            DateTime.UtcNow);

        var problemDetails = new ProblemDetails
        {
            Title = exception.GetType().Name,
            Detail = exception.Message,
            Status = StatusCodes.Status500InternalServerError,
            Instance = context.Request.Path
        };

        problemDetails.Extensions["traceId"] = context.TraceIdentifier;

        context.Response.StatusCode = problemDetails.Status.Value;

        await context.Response.WriteAsJsonAsync(problemDetails, cancellationToken);

        return true;
    }
}