using System;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using static AwesomeApp.App;

namespace AwesomeApp
{
    public partial class MainPage : ContentPage
    {
        private readonly Uri SpiHome = new Uri("https://google.de");
        public MainPage()
        {
            InitializeComponent();
        }

        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            await OpenBrowser(SpiHome);
        }

        private async Task OpenBrowser(Uri uri)
        {
            try
            {
                await Browser.OpenAsync(uri, BrowserLaunchMode.SystemPreferred);
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.ToString(), "OK");
            }
        }

        private void Switch_Toggled(object sender, ToggledEventArgs e)
        {
            var toggleStatus = themeToggle.IsToggled;
            SetTheme(toggleStatus);
        }

        void SetTheme(bool status)
        {
            Theme themeRequested = status ? Theme.Dark : Theme.Light;
            DependencyService.Get<IAppTheme>().SetAppTheme(themeRequested);
        }
    }
}
