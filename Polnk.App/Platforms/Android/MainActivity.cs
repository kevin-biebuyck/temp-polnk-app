using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Views;
using Platform = Microsoft.Maui.ApplicationModel.Platform;

namespace Polnk.App
{
    [Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
    public class MainActivity : MauiAppCompatActivity
    {
        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Platform.Init(this, savedInstanceState);

            this.Window!.AddFlags(WindowManagerFlags.Fullscreen);

        }
    }
}
