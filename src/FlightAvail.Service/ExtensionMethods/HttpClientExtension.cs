using System.Net.Http.Json;
using System.Text.Json;

namespace FlightAvail.Service.ExtensionMethods;

internal static class HttpClientExtension
{
    private static JsonSerializerOptions DefaultJsonSerializerOptions = new()
    {
        PropertyNameCaseInsensitive = true
    };

    public static async Task<T?> SendJsonRequest<T>(this HttpClient client,
        string endpoint,
        HttpMethod method,
        object? request,
        CancellationToken cancellationToken = default) where T : class
    {
        var messageRequest = new HttpRequestMessage(method, endpoint);
        if (method != HttpMethod.Get && request is not null)
        {
            messageRequest.Content = new StringContent(JsonSerializer.Serialize(request), System.Text.Encoding.UTF8, "application/json");
        }
        var httpResponse = await client.SendAsync(messageRequest, cancellationToken).ConfigureAwait(false);

        if (httpResponse is null) return default;

        httpResponse.EnsureSuccessStatusCode();

        return await httpResponse.Content.ReadFromJsonAsync<T>(DefaultJsonSerializerOptions, cancellationToken).ConfigureAwait(false);
    }
}
