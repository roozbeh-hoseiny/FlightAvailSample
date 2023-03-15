using FlightAvailService.Samples.Shared.Fixtures;

namespace FlightAvailService.Samples.Shared.HttpClientHandlers;

internal sealed class Supplier2SampleResponseDelegatingHandler : DelegatingHandler
{
    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        return Task.FromResult(new HttpResponseMessage(System.Net.HttpStatusCode.OK)
        {
            Content = new StringContent(System.Text.Json.JsonSerializer.Serialize(Supplier2ProxyResponse.Create()), System.Text.Encoding.UTF8, "application/json")
        });
    }
}
