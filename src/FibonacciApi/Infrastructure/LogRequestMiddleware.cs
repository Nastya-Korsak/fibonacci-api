using Microsoft.AspNetCore.Http.Extensions;

namespace FibonacciApi.Infrastructure;

public class LogRequestMiddleware : IMiddleware
{
    private readonly ILogger<LogRequestMiddleware> _logger;

    public LogRequestMiddleware(ILogger<LogRequestMiddleware> logger)
    {
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        var urlHost = context.Request.Host.Value;
        var urlPath = context.Request.Path;
        var fullUrl = context.Request.GetDisplayUrl();

        _logger.LogInformation("eventName={Event} path={Path} host={Host} fullUrl={FullUrl}", "request.received", urlPath, urlHost, fullUrl);

        await next(context);

        _logger.LogInformation("eventName={Event} path={Path} host={Host} fullUrl={FullUrl}", "request.processed", urlPath, urlHost, fullUrl);

    }
}
