using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace FibonacciApi.Infrastructure;

public class GlobalExceptionHandlerMiddleware : IMiddleware
{
    private readonly ILogger<GlobalExceptionHandlerMiddleware> _logger;

    public GlobalExceptionHandlerMiddleware(ILogger<GlobalExceptionHandlerMiddleware> logger)
    {
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception exception)
        {
            _logger.LogError(exception, "eventName={Event} message={Message}", "request.failed", exception.Message);

            var resultCode = (int)(exception switch
            {
                ArgumentOutOfRangeException => HttpStatusCode.BadRequest,
                _ => HttpStatusCode.InternalServerError
            });

            context.Response.StatusCode = resultCode;
            await context.Response.WriteAsJsonAsync(new ProblemDetails
            {
                Status = resultCode,
                Title = "Error happened",
                Detail = exception.Message
            });
        }
    }
}
