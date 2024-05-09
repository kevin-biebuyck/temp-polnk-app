namespace Polnk.App.Pages;
public partial class AddIntroPage : ContentPage
{ 
    public ObservableCollection<string> Chips { get; set; }
    public Color BachelorButtonBackgroundColor { get; set; } 
    public Color MasterButtonBackgroundColor { get; set; }
    public Color DoctoralButtonBackgroundColor { get; set; } 
    public Color ProfessionalButtonBackgroundColor { get; set; } 
    public AddIntroPage()
	{
		InitializeComponent();
       
       Chips = new ObservableCollection<string>();

    }
    private string skillText;
    public string SkillText
    {
        get { return skillText; }
        set { skillText = value; OnPropertyChanged(nameof(SkillText)); }
    }
    private void EducationButton_Clicked(Object sender, EventArgs e)
    {
        EducationFrame.IsVisible = !EducationFrame.IsVisible;
        if(EducationFrame.IsVisible == true) {
            EducationButton.Background = (Color)Application.Current!.Resources["BlueGreenButton"];
        }
        else
        {
            EducationButton.Background = (Color)Application.Current!.Resources["InputBackground"];
        }
    }
    private void MasterButton_clicked(Object sender, EventArgs e)
    {
        PopupForm.Show();
    }
    private void AddNewButton_clicked(Object sender, EventArgs e)
    {
        PopupForm.Show();
    }
    private Button previousClickedButton = null;

    private void DegreeButton_Clicked(object sender, EventArgs e)
    {
        var clickedButton = sender as Button;

        if (clickedButton == null)
            return;

        if (previousClickedButton != null)
        {
           
            previousClickedButton.Background = Colors.Gray;
        }

        clickedButton.Background = (Color)Application.Current!.Resources["BlueGreenButton"];
        previousClickedButton = clickedButton;

    }


}