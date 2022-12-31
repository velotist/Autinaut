using AwesomeApp.Data;
using AwesomeApp.Models;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AwesomeApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SuccessItemPage : ContentPage
    {
        public SuccessItemPage ()
        {
            InitializeComponent();
        }

        private async void OnSaveClicked (object sender, EventArgs e)
        {
            SuccessItem successItem = (SuccessItem)BindingContext;
            SuccessItemDatabase database = await SuccessItemDatabase.Instance;
            _ = await database.SaveItemAsync(successItem);
            _ = await Navigation.PopAsync();
        }

        private async void OnCancelClicked (object sender, EventArgs e)
        {
            _ = await Navigation.PopAsync();
        }
    }
}