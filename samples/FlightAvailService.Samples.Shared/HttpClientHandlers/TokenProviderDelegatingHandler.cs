using FlightAvailService.Samples.Shared.Services;
using Microsoft.Extensions.Logging;

namespace FlightAvailService.Samples.Shared.HttpClientHandlers;

internal sealed class TokenProviderDelegatingHandler : DelegatingHandler
{
    private readonly ITokenProvider _tokenProvider;
    private readonly ILogger<TokenProviderDelegatingHandler> _logger;

    public TokenProviderDelegatingHandler(ITokenProvider tokenProvider, ILogger<TokenProviderDelegatingHandler> logger)
    {
        _tokenProvider = tokenProvider;
        this._logger = logger;
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        this._logger.LogDebug("adding token ....");
        request.Headers.TryAddWithoutValidation("authorization", (await this._tokenProvider.GetToken(cancellationToken)));
        return await base.SendAsync(request, cancellationToken);
    }
}