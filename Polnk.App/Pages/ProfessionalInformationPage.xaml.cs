namespace Polnk.App.Pages
{
    public partial class ProfessionalInformationPage : ContentPage
    {
        public ObservableCollection<string> Chips { get; set; }

        public ProfessionalInformationPage()
        {
            InitializeComponent();
            Chips = new ObservableCollection<string>();
            BindingContext = this;
            AddButton.Command = new Command(OnAddButtonClicked);
        }

        private string skillText;
        public string SkillText
        {
            get { return skillText; }
            set { skillText = value; OnPropertyChanged(nameof(SkillText)); }
        }

        private void ResetErrors()
        {
            JobTitleContainer.HasError = false;
            DescriptionContainer.HasError = false;
        }

        private void OnAddButtonClicked()
        {
            if (!string.IsNullOrWhiteSpace(SkillText))
            {
                Chips.Add(SkillText);
                SkillText = string.Empty;
            }
        }

        private void ContinueButton_Clicked(object sender, EventArgs e)
        {
            ResetErrors();

            string JobTitle = InputJobTitle.Text;
            string Description = InputDescription.Text;

            if (JobTitle.IsNullOrEmpty())
            {
                JobTitleContainer.HasError = true;
                return;
            }

            if (Description.IsNullOrEmpty())
            {
                DescriptionContainer.HasError = true;
                return;
            }
            Application.Current.MainPage = new NavigationPage(new BasicInformationPage());
        }

        private void CloseButton_Clicked(object sender, EventArgs e)
        {
            if (sender is SfChip chip)
            {
                var chipText = chip.Text;
                Chips.Remove(chipText);
            }
        }
    }
}
