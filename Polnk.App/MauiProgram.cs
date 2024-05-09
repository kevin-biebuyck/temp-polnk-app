using CommunityToolkit.Maui;

namespace Polnk.App;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        SyncfusionLicenseProvider.RegisterLicense("MzIyMjcwOEAzMjM1MmUzMDJlMzBjV3EwTlFrSkhSQjFiY2d2bFVXSWNwbFFaTVNLTmo2RkNZcjJ3VHo2TXVrPQ==");

        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("InterFont.ttf", "InterFont");
            });

#if DEBUG
		builder.Logging.AddDebug();
#endif
        builder.DependencyInjection();
        builder.ConfigureSyncfusionCore();

        var app = builder.Build();

        Utilities.ServiceProvider.Initialize(app.Services);

        return app;
    }
}
