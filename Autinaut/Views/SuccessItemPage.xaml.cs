using Autinaut.Models;
using Autinaut.Resx;
using Autinaut.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Autinaut.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SuccessItemPage : ContentPage
    {
        public SuccessItemPage(bool hasDeleteButton)
        {
            InitializeComponent();
            SfButtonDelete.IsVisible = hasDeleteButton;
        }

        private async void EditorUnfocused(object sender, EventArgs e)
        {
            await scrollView.ScrollToAsync(buttons, ScrollToPosition.End, true);
        }

        private async void OnSaveClicked(object sender, EventArgs e)
        {
            SuccessItemViewModel successItem = (SuccessItemViewModel)BindingContext;
            if (string.IsNullOrEmpty(successItem.SuccessNote))
            {
                _ = DisplayAlert(AppResources.NotificationTitle, AppResources.NotificationSuccessText, "OK");
                SfButtonSave.IsChecked = false;

                await scrollView.ScrollToAsync(scrollView, ScrollToPosition.Start, true);

                return;
            }

            SuccessItemDatabase database = await SuccessItemDatabase.Instance;
            _ = await database.SaveItemAsync(successItem);

            await Navigation.PopToRootAsync();
        }

        private async void OnDeleteClicked(object sender, EventArgs e)
        {
            SuccessItemViewModel successItem = (SuccessItemViewModel)BindingContext;
            SuccessItemDatabase database = await SuccessItemDatabase.Instance;
            _ = await database.DeleteItemAsync(successItem);

            await Navigation.PopToRootAsync();
        }
    }
}