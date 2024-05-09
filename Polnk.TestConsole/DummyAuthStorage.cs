using Polnk.App.Core;

public class DummyAuthStorage : IAuthStore
{
    private string? _accessToken;
    private string? _refreshToken;

    public Task<string> GetAccessToken() => Task.FromResult(_accessToken ?? throw new InvalidOperationException("The access token was not set"));
    public Task<string> GetRefreshToken() => Task.FromResult(_refreshToken ?? throw new InvalidOperationException("The refresh token was not set"));

    public Task StoreToken(string accessToken, string refreshToken)
    {
        _accessToken = accessToken ?? throw new ArgumentNullException(nameof(accessToken));
        _refreshToken = refreshToken ?? throw new ArgumentNullException(nameof(refreshToken));
        return Task.CompletedTask;
    }
}