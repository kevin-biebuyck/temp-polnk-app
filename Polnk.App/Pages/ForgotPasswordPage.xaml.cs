namespace Polnk.App.Pages;

public partial class ForgotPasswordPage : ContentPage
{
    public ForgotPasswordPage()
    {
        InitializeComponent();
    }
    private void Code_send(object sender, EventArgs e)
    {
        Navigation.PushAsync(new VerificationCodePage());
    }
}
