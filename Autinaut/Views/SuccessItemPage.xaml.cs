using System;
using Autinaut.Database;
using Autinaut.Resx;
using Autinaut.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Autinaut.Views;

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
        await ScrollView.ScrollToAsync(Buttons, ScrollToPosition.End, true);
    }

    private async void OnSaveClicked(object sender, EventArgs e)
    {
        var successItem = (SuccessItemViewModel)BindingContext;
        if (string.IsNullOrEmpty(successItem.SuccessNote))
        {
            _ = DisplayAlert(AppResources.NotificationTitle, AppResources.NotificationSuccessText, "OK");
            SfButtonSave.IsChecked = false;

            await ScrollView.ScrollToAsync(ScrollView, ScrollToPosition.Start, true);

            return;
        }

        var databaseHelper = new DatabaseHelper();
        await databaseHelper.SaveItemAsync(successItem);

        await Navigation.PopToRootAsync();
    }

    private async void OnDeleteClicked(object sender, EventArgs e)
    {
        var successItem = (SuccessItemViewModel)BindingContext;
        var databaseHelper = new DatabaseHelper();
        await databaseHelper.DeleteItemAsync(successItem);

        await Navigation.PopToRootAsync();
    }

    private void EditorFocused(object sender, FocusEventArgs e)
    {
        SuccessNote.ShowHelperText = false;
        SuccessNote.ShowCharCount = true;
    }
}