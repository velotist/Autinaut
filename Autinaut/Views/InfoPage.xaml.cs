using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Autinaut.Views
{
    public partial class InfoPage : ContentPage
    {
        private readonly string cancelDisplayAlert = "OK";
        private readonly string feedbackMailAddress = "marcusgreiner@protonmail.com";
        private readonly string subject = "Feedback On Autinaut";

        public InfoPage()
        {
            InitializeComponent();
        }

        private async void OnFeedbackClicked(object sender, EventArgs e)
        {
            await SendEmail(subject, "", new List<string>
            {
                feedbackMailAddress
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
    }
}