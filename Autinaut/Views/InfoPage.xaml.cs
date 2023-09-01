using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Autinaut.Common;
using Autinaut.Resx;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Autinaut.Views
{
    public partial class InfoPage : ContentPage
    {
        private readonly string cancelDisplayAlert = "OK";
        private readonly string feedbackMailAddress = "marcusgreiner@protonmail.com";
        private readonly string subject = AppResources.MailSubjectText;

        public InfoPage()
        {
            InitializeComponent();
        }

        private void OnInfoClicked(object sender, EventArgs e)
        {
            DependencyService.Get<IToast>().ShortToast(AppResources.SpecialThanx);
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
                var message = new EmailMessage
                {
                    Subject = subject,
                    Body = body,
                    To = recipients
                };

                await Email.ComposeAsync(message);
            }
            catch (FeatureNotSupportedException)
            {
                await DisplayAlert(AppResources.TextAlertMailNotSupportedTitle,
                    AppResources.TextAlertMailNotSupportedText, cancelDisplayAlert);
            }
            catch (Exception ex)
            {
                await DisplayAlert(AppResources.TextExceptionTtitle, ex.ToString(), cancelDisplayAlert);
            }
        }
    }
}