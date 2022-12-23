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
            InitializeComponent ();
        }

        async void OnSaveClicked(object sender, EventArgs e)
        {
            var successItem = (SuccessItem)BindingContext;
            SuccessItemDatabase database = await SuccessItemDatabase.Instance;
            await database.SaveItemAsync(successItem);
            await Navigation.PopAsync();
        }

        async void OnCancelClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}