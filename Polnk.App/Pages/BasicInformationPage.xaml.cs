namespace Polnk.App.Pages;

public partial class BasicInformationPage : ContentPage
{
    public BasicInformationPage()
    {
        InitializeComponent();
    }

    private async void ShareInfo_clicked(object sender, EventArgs e)
    {
        await Share.RequestAsync(new ShareTextRequest
        {
            Text = "PolnkApp",
            Title = "Share profile"
        });
    }

    private void EditButton_clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new ProfessionalInformationPage());
    }

    private void ChangePic_clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new ProfilePhotoPage());
    }

    private void AddIntro_clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new AddIntroPage());
    }
    private void Name_Tapped(object sender, EventArgs e)
    {
        Navigation.PushAsync(new RegistrationPage());
    }
}