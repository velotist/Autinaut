using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Autinaut.Views
{
    public partial class InfoPage : ContentPage
    {
        private readonly Uri SpiHome = new Uri("https://autinaut.net");
        private readonly string cancelDisplayAlert = "OK";
        public InfoPage()
        {
            InitializeComponent();
        }

        private async void GoToWebsite_Clicked(object sender, EventArgs e)
        {
            await OpenBrowser(SpiHome);
        }

        private async void OnFeedbackClicked(object sender, EventArgs e)
        {
            await SendEmail("Feedback On Autinaut", "", new List<string>
            {
                "marcusgreiner@protonmail.com"
            });
        }

        private async Task SendEmail(string subject, string body, List<string> recipients)
        {
            try
            {
                EmailMessage message = new EmailMessage
                {
                    Subject = subject,
                    Body = body,
                    To = recipients,
                };

                await Email.ComposeAsync(message);
            }
            catch (FeatureNotSupportedException)
            {
                await DisplayAlert("Feature Not Supported", "Email is not supported on this device", cancelDisplayAlert);
            }
            catch (Exception ex)
            {
                await DisplayAlert("Exception", ex.ToString(), cancelDisplayAlert);
            }
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
