namespace Polnk.App.Pages;

public partial class VerificationCodePage : ContentPage
{
    public VerificationCodePage()
    {
        InitializeComponent();
    }
    private void Change_Password(object sender, EventArgs e)
    {
        Navigation.PushAsync(new NewPasswordPage());
    }

    private void Button_Clicked(object sender, EventArgs e)
    {

    }
}
