using System;
using AwesomeApp.Data;
using AwesomeApp.Models;
using Xamarin.Forms;

namespace AwesomeApp.Views
{
    public partial class MoodItemPage : ContentPage
    {
        public MoodItemPage()
        {
            InitializeComponent();
            BindingContext = new MoodItem();
        }

        async void OnSaveClicked(object sender, EventArgs e)
        {
            var MoodItem = (MoodItem)BindingContext;
            MoodItemDatabase database = await MoodItemDatabase.Instance;
            await database.SaveItemAsync(MoodItem);
            await Navigation.PopAsync();
        }

        async void OnDeleteClicked(object sender, EventArgs e)
        {
            var MoodItem = (MoodItem)BindingContext;
            MoodItemDatabase database = await MoodItemDatabase.Instance;
            await database.DeleteItemAsync(MoodItem);
            await Navigation.PopAsync();
        }

        async void OnCancelClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}