using Autinaut.Data;
using Autinaut.Models;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Autinaut.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SuccessItemPage : ContentPage
    {
        public SuccessItemPage()
        {
            InitializeComponent();
            succesNoteEditor.Unfocused += EditorUnfocused;
        }

        private async void EditorUnfocused(object sender, EventArgs e)
        {
            await scrollView.ScrollToAsync(buttons, ScrollToPosition.End, true);
        }

        private async void OnSaveClicked(object sender, EventArgs e)
        {
            SuccessItem successItem = (SuccessItem)BindingContext;
            SuccessItemDatabase database = await SuccessItemDatabase.Instance;
            _ = await database.SaveItemAsync(successItem);
            await Navigation.PopToRootAsync();
        }

        private async void OnDeleteClicked(object sender, EventArgs e)
        {
            SuccessItem successItem = (SuccessItem)BindingContext;
            SuccessItemDatabase database = await SuccessItemDatabase.Instance;
            _ = await database.DeleteItemAsync(successItem);
            await Navigation.PopToRootAsync();
        }

        private async void OnCancelClicked(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }
    }
}