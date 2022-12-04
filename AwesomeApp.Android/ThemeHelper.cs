using Xamarin.Forms;
using static AwesomeApp.App;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AwesomeApp.Styles;

[assembly: Dependency(typeof(AwesomeApp.Droid.ThemeHelper))]
namespace AwesomeApp.Droid
{
    public class ThemeHelper : IAppTheme
    {
        public void SetAppTheme(Theme theme)
        {
            SetTheme(theme);
        }

        private void SetTheme(Theme mode)
        {
            if (mode == Theme.Dark)
            {
                if (App.AppTheme == Theme.Dark)
                    return;
                App.Current.Resources = new DarkTheme();
            }
            else
            {
                if (App.AppTheme != Theme.Dark)
                    return;
                LightTheme lightTheme = new LightTheme();
                App.Current.Resources = lightTheme;
            }

            App.AppTheme = mode;
        }
    }
}