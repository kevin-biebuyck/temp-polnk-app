namespace Polnk.App.Pages;
public partial class RegistrationPage : ContentPage
{
    private Button selectedButton;
    bool GenderSelected = false;
    private readonly PolnkHttpRequests polnkHttpRequests;

    public RegistrationPage()
    {
        polnkHttpRequests = ServiceProvider.GetService<PolnkHttpRequests>();

        InitializeComponent();

        ButtonMale.Clicked += GenderSelctionButton_Clicked!;
        ButtonFemale.Clicked += GenderSelctionButton_Clicked!;
        ButtonOthers.Clicked += GenderSelctionButton_Clicked!;
    }

    private void GenderSelctionButton_Clicked(object sender, EventArgs e)
    {
        GenderSelected = true;

        var button = (Button)sender;

        if (selectedButton != null)
        {
            selectedButton.BorderColor = (Color)Application.Current!.Resources["BlackBackground"];
        }

        button.BorderColor = (Color)Application.Current!.Resources["BlueGreenButton"];
        selectedButton = button;
    }
    private void ResetErrors()
    {
        FullNameContainer.HasError = false;
        ContainerPhoneNo.HasError = false;
        GenderSelectError.IsVisible = false;

    }
    private async void Continue_Clicked(Object sender, EventArgs e)
    {
        ResetErrors();

        string Name = "/" + InputFullName.Text;
        string PhoneNo = InputPhoneNumber.Text;

        if (Name.IsNullOrEmpty())
        {
            FullNameContainer.HasError = true;
            return;
        }

        if (!GenderSelected)
        {
            GenderSelectError.IsVisible = true;
            return;
        }

        if (PhoneNo.IsNullOrEmpty())
        {
            ContainerPhoneNo.HasError = true;
            return;
        }

        UpdateUserInformationRequest UpdateUser = new(Op: "", Path: "/firstName", Value: "AHMADrt");
        var response = await polnkHttpRequests.UpdateInfo(UpdateUser: UpdateUser);
        if (response is null)
        {
            //todo request failed 
        }

        //if (response!.error!.isnotnullorempty())
        //{
        //    //todo authentication error
        //    return;
        //    //  }

            Navigation.PushAsync(new ProfilePhotoPage());
    }
}


