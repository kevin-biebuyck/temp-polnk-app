namespace Polnk.App.Pages.ShellViews;

public partial class AppShell : Shell
{
    private readonly ISessionManagementService sessionManagementService;

    public AppShell()
    {
        sessionManagementService = ServiceProvider.GetService<ISessionManagementService>();
        CheckLoginStatus();
        InitializeComponent();
    }

    private void CheckLoginStatus()
    {
        var accessToken = sessionManagementService.GetSession(SessionKey.ACCESS_TOKEN);
        if (accessToken.IsNullOrEmpty())
        {
            //TODO Session out, not loggedIn
        }
    }
}
