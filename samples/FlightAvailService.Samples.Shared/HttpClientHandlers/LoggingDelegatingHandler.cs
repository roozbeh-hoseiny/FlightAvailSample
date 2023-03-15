using Microsoft.Extensions.Logging;

namespace FlightAvailService.Samples.Shared.HttpClientHandlers;

internal sealed class LoggingDelegatingHandler : DelegatingHandler
{
    private readonly ILogger<LoggingDelegatingHandler> _logger;

    public LoggingDelegatingHandler(ILogger<LoggingDelegatingHandler> logger)
    {
        this._logger = logger;
    }

    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        _logger.LogDebug("sending http '{method}' request to '{url}'", request.Method, request.RequestUri?.ToString() ?? "");
        return base.SendAsync(request, cancellationToken);
    }
}
