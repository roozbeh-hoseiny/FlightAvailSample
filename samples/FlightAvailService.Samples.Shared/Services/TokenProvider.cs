namespace FlightAvailService.Samples.Shared.Services;

internal interface ITokenProvider
{
    public ValueTask<string> GetToken(CancellationToken cancellationToken);
}
internal sealed class TokenProvider : ITokenProvider
{
    public ValueTask<string> GetToken(CancellationToken cancellationToken) => ValueTask.FromResult(DateTime.Now.ToString());
}
