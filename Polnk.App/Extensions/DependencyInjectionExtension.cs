namespace Polnk.App.Extensions;

public static class DependencyInjectionExtension
{
    public static void DependencyInjection(this MauiAppBuilder builder)
    {
        builder.Services.AddSingleton<PolnkHttpRequests>();
        builder.Services.AddSingleton<IHttpClientService, HttpClientService>();
        builder.Services.AddSingleton<ISessionManagementService, SessionManagementService>();
    }
}