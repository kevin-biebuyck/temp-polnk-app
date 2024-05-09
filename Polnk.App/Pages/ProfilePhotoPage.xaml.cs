namespace Polnk.App.Pages
{
    public partial class ProfilePhotoPage : ContentPage
    {
        private byte[] fileBytes;
        private readonly IHttpClientService? httpClientService;
        private readonly PolnkHttpRequests polnkHttpRequests;
        private static string mimeType;
        private static string fileName;
        public ProfilePhotoPage()
        {
            polnkHttpRequests = ServiceProvider.GetService<PolnkHttpRequests>();
            InitializeComponent();
        }

        private void ResetErrors()
        {
            ImageUploadError.IsVisible = false;
        }
        private static string GetMimeType(string fileName)
        {
            string extension = Path.GetExtension(fileName)?.ToLower();
            switch (extension)
            {
                case ".jpg":
                case ".jpeg":
                    return "image/jpeg";
                case ".png":
                    return "image/png";
                // Add cases for other image formats as needed
                default:
                    return "application/octet-stream"; // Default to binary/octet-stream for unknown file types
            }
        }

        // Define a class-level variable to store the selected file path
        private string selectedFilePath;

        private async void UploadButton_Clicked(object sender, EventArgs e)
        {
            var customFileType = new FilePickerFileType(new Dictionary<DevicePlatform, IEnumerable<string>>
            {
                { DevicePlatform.iOS, new[] { "public.my.comic.extension" } }, // or general UTType values  
                { DevicePlatform.Android, new[] { "*/*" } },
            });

            var options = new PickOptions
            {
                PickerTitle = "Please select a Picture",
                FileTypes = FilePickerFileType.Images,
            };

            var result = await FilePicker.PickAsync(options);

            if (result != null)
            {

                selectedFilePath = result.FullPath;

                UploadedImage.Source = ImageSource.FromFile(selectedFilePath);
            }
        }

        private async void SavePicButton_Clicked(object sender, EventArgs e)
        {
            //    ResetErrors();

            //    if (selectedFilePath == null)
            //    {
            //        ImageUploadError.IsVisible = true;
            //        return;
            //    }

            //    // Pass the selected file path to the RegisterPic method
            //    var response = await polnkHttpRequests.RegisterPic(selectedFilePath);
            //    if (response is null)
            //    {
            //        // TODO: Handle request failed
            //    }

            //    // Navigate to the next page after successful upload
            //    Navigation.PushAsync(new ProfessionalInformationPage());
            //}
            //HttpClient client = new HttpClient();

            //HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Put, "https://api.polnk.io/profile/cf1bdbbc-efaa-44b3-ba30-8387e518bc3e/avatar");

            //request.Headers.Add("Authorization", "Bearer eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCIsImtpZCI6IlBGR2JmVzlsZm1oYzhheGhrNWw5SSJ9.eyJpc3MiOiJodHRwczovL2F1dGgucG9sbmsuaW8vIiwic3ViIjoiYXV0aDB8Y2YxYmRiYmMtZWZhYS00NGIzLWJhMzAtODM4N2U1MThiYzNlIiwiYXVkIjpbImh0dHBzOi8vYXBpLnBvbG5rLmlvIiwiaHR0cHM6Ly9wb2xuay5ldS5hdXRoMC5jb20vdXNlcmluZm8iXSwiaWF0IjoxNzE1MDk3MDQ4LCJleHAiOjE3MTUxODM0NDgsInNjb3BlIjoib3BlbmlkIHByb2ZpbGUgZW1haWwgcmVhZDpwcm9maWxlIHVwZGF0ZTpwcm9maWxlIGNyZWF0ZTp2aWRlbyBvZmZsaW5lX2FjY2VzcyIsImd0eSI6InBhc3N3b3JkIiwiYXpwIjoiT3BkZ0hPSHlFT3JYMVlvR0p1aU1OamVwMlVKZWxXTGcifQ.XOZxOO2jqubmtbxe3XT8bDJ6aKxxhxiC7yeiZEYYY_JG8dImzua3XlZWXAJhWUxmhtt_cht7b4_5e-UI6AvZTowPrsw-h8zPaQa5D25e9u8vGbZ9IvvJTqJ815D6PmMgw_4yV1r-ODSLhfVn_-5BxDIid6hSIPFtgh_QNUdzYOPIKZgxUrVzVlkTjrnpCbUCO04OaBK8qZsy5eoZC33p0VYQsG9Ub5_ngYlcduHbxesX3qD92Sv0Y-ozmmI6NgEgbNVJuXip62Z83XBZ0VQaLvhRArudKJjnCdjtPO_fEb0uoJNBJc5pbg0QG-CTWA7cjlJgVudbivsciBQ8hZZkJQ");


            //MultipartFormDataContent content = new MultipartFormDataContent();
            //content.Add(new ByteArrayContent(File.ReadAllBytes(@"Platforms\Android\Resources\drawable\notifications.png")), "file", Path.GetFileName(@"Platforms\Android\Resources\drawable\notifications.png"));

            //request.Content = content;

            //HttpResponseMessage response = await client.SendAsync(request);
            //response.EnsureSuccessStatusCode();
            //string responseBody = await response.Content.ReadAsStringAsync();
            
        }
    }
}