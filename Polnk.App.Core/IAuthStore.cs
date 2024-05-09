namespace Polnk.App.Core;

public interface IAuthStore
{
    Task<string> GetAccessToken();
    Task<string> GetRefreshToken();
    Task StoreToken(string accessToken, string refreshToken);
}