namespace Polnk.App.Pages;
public partial class CreateAccountPage : ContentPage
{
    private readonly PolnkHttpRequests polnkHttpRequests;
    private static string userId;
    private static string accessToken;
    private readonly ISessionManagementService sessionManagementService;
    public static string UserId => userId;
    public CreateAccountPage()
    {
        polnkHttpRequests = ServiceProvider.GetService<PolnkHttpRequests>();
        InitializeComponent();
    }

    private void ResetErrors()
    {
        ContainerEmail.HasError = false;
        ContainerPassword.HasError = false;
    }

    private void LoginButton_Tapped(object sender, EventArgs e)
    {
        Navigation.PushAsync(new LoginPage());
    }
    private async void Continue_Clicked(Object sender, EventArgs e)
    {
        ResetErrors();

        string email = InputEmail.Text;
        string password = InputPassword.Text;
        bool ischecked = CheckBoxAgrement.IsChecked;

        if (email.IsNullOrEmpty())
        {
            ContainerEmail.HasError = true;
            return;
        }

        if (password.IsNullOrEmpty())
        {
            ContainerPassword.HasError = true;
            return;
        }

        if (!ischecked)
        {
            CheckBoxAgrement.Background = Colors.Red;
            return;
        }

        RegisterRequest registerRequest = new(Email: email, Password: password);

        var response = await polnkHttpRequests.Register(registerRequest);

        accessToken = response.AccessToken;
        var refreshToken = response.RefreshToken;
        var handler = new JwtSecurityTokenHandler();
        var jsonAccessToken = handler.ReadToken(accessToken) as JwtSecurityToken;
   
        userId = jsonAccessToken?.Claims.FirstOrDefault(claim => claim.Type == "sub")?.Value;

        

        if (response is null)
        {
            return;
        }

        //if (response!.Error!.IsNotNullOrEmpty())
        //{
        //    //TODO authentication error
        //    return;
        //}

        await Navigation.PushAsync(new RegistrationPage());
    }
}