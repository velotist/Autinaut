using System;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Autinaut.Views
{
    public partial class InfoPage : ContentPage
    {
        private readonly Uri SpiHome = new Uri("https://ITsmus.de");
        public InfoPage()
        {
            InitializeComponent();
        }

        private async void GoToGithubButton_Clicked(object sender, EventArgs e)
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
    }
}
