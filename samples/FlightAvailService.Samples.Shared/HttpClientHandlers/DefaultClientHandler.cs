using System.Net;

namespace FlightAvailService.Samples.Shared.HttpClientHandlers;

internal sealed class DefaultClientHandler : HttpClientHandler
{
    public DefaultClientHandler() => AutomaticDecompression = DecompressionMethods.Brotli | DecompressionMethods.Deflate | DecompressionMethods.GZip;
}
