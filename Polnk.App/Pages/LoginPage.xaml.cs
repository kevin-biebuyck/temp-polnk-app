namespace Polnk.App.Pages;
public partial class LoginPage : ContentPage
{
    private static string userId;
    private static string accessToken;
    private readonly PolnkHttpRequests polnkHttpRequests;
    private readonly ISessionManagementService sessionManagementService;
    public static string UserId => userId;
    public LoginPage()
    {
        polnkHttpRequests = ServiceProvider.GetService<PolnkHttpRequests>();
        sessionManagementService = ServiceProvider.GetService<ISessionManagementService>();
        InitializeComponent();
    }

    private void Forgot_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new ForgotPasswordPage());
    }
    private void NewUser_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new CreateAccountPage());
    }
    
    async void Login_Click(object sender, EventArgs e)
    {

        ResetErrors();

        string email = InputEmail.Text;
        string password = InputPassword.Text;

        email = "malik@gmail.com";
        password = "ahmadrafay";

        if (email.IsNullOrEmpty())
        {
            Container_Email.HasError = true;
            return;
        }

        if (password.IsNullOrEmpty())
        {
            Container_Password.HasError = true;
            return;
        }
        

        LoginRequest loginRequest = new(email: email, password: password);

        var response = await polnkHttpRequests.Login(loginRequest: loginRequest);

        accessToken = response.AccessToken;
        var refreshToken = response.RefreshToken;
        var handler = new JwtSecurityTokenHandler();
        var jsonAccessToken = handler.ReadToken(accessToken) as JwtSecurityToken;

        userId = jsonAccessToken?.Claims.FirstOrDefault(claim => claim.Type == "sub")?.Value;

        if (response is null)
        {
            //TODO request failed 
        }

        if (response!.Error!.IsNotNullOrEmpty())
        {
            //TODO authentication error
            return;
        }
        if(response!.AccessToken is null)
        {
            return;
        }
        if (response!.IdToken is null)
        {
            return;
        }

        await sessionManagementService.SetSession(SessionKey.ACCESS_TOKEN, response!.AccessToken!);
        await sessionManagementService.SetSession(SessionKey.ID_TOKEN, response!.IdToken!);

     

        Application.Current!.MainPage = new NavigationPage(new BasicInformationPage());
    }

    private void CreateNew_clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new CreateAccountPage());
    }

    private void ResetErrors()
    {
        Container_Email.HasError = false;
        Container_Password.HasError = false;
    }
}
