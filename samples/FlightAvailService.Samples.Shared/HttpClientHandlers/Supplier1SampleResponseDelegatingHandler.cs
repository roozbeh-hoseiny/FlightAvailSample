using FlightAvailService.Samples.Shared.Fixtures;
using Microsoft.Extensions.Logging;

namespace FlightAvailService.Samples.Shared.HttpClientHandlers;

internal sealed class Supplier1SampleResponseDelegatingHandler : DelegatingHandler
{
    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        return Task.FromResult(new HttpResponseMessage(System.Net.HttpStatusCode.OK)
        {
            Content = new StringContent(System.Text.Json.JsonSerializer.Serialize(Supplier1ProxyResponse.Create()), System.Text.Encoding.UTF8, "application/json")
        });
    }
}
