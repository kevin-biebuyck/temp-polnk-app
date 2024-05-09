namespace Polnk.App.Models.Responses;

public class RegisterResponse
{
    [JsonPropertyName("accessToken")]
    public string? AccessToken { get; set; }

    [JsonPropertyName("identityToken")]
    public string? IdentityToken { get; set; }

    [JsonPropertyName("refreshToken")]
    public string? RefreshToken { get; set; }
    
    [JsonPropertyName("accessTokenExpiration")]
    public DateTime? AccessTokenExpiration { get; set; }
    
    [JsonPropertyName("authenticationTime")]
    public DateTime? AuthenticationTime { get; set; }

    [JsonPropertyName("error")]
    public string? error { get; set; }

    [JsonPropertyName("error_description")]
    public string? errordescription { get; set; }
}
