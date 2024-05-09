namespace Polnk.App.Constants;
public class ApiRoutes
{
    private static string UserId = "64a976f9-3d40-4959-941d-0390eff67dcc";
    private static readonly string BaseUrl = "https://api.polnk.io/";

    private static readonly string Get = $"{BaseUrl}/profile/{UserId}/personal";

    public static readonly string Login = $"https://auth.polnk.io/oauth/token";
    public static readonly string Register = "https://api.polnk.io/register";
    public static readonly string RegisterProfilePic = $"{BaseUrl}profile/{UserId}/avatar";
    public static readonly string UpdateUser = $"{BaseUrl}profile/{UserId}/personal"; 
}