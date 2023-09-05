using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Autinaut.Common;
using Autinaut.Resx;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Autinaut.Views;

public partial class InfoPage : ContentPage
{
    private const string CancelDisplayAlert = "OK";
    private const string FeedbackMailAddress = "marcusgreiner@protonmail.com";
    private readonly string _subject = AppResources.MailSubjectText;

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
        await SendEmail(_subject, "", new List<string>
        {
            FeedbackMailAddress
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
                AppResources.TextAlertMailNotSupportedText, CancelDisplayAlert);
        }
        catch (Exception ex)
        {
            await DisplayAlert(AppResources.TextExceptionTtitle, ex.ToString(), CancelDisplayAlert);
        }
    }
}