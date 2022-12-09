using System.Threading.Tasks;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace AwesomeApp.Controls
{
    public partial class FlyoutFooter : ContentView
    {
        private readonly Uri SpiHome = new Uri("https://ITsmus.de");
        public FlyoutFooter()
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
                await Application.Current.MainPage.DisplayAlert("Error", ex.ToString(), "OK");
            }
        }
    }
}
