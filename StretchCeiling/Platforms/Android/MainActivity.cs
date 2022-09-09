using Android.App;
using Android.Content.PM;
using Android.OS;

namespace StretchCeiling;

[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
public class MainActivity : MauiAppCompatActivity
{
    protected override void OnCreate(Bundle bundle)
    {        
        base.OnCreate(bundle);
        Window.SetStatusBarColor(Android.Graphics.Color.Transparent);
    }
}
