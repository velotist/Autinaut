using AwesomeApp.Data;
using AwesomeApp.Models;
using System;
using Xamarin.Forms;

namespace AwesomeApp.Views
{
    public partial class MoodItemPage : ContentPage
    {
        public MoodItemPage()
        {
            InitializeComponent();
            BindingContext = new MoodItem { Date = DateTime.Now.ToString() };
        }

        private async void OnSaveClicked(object sender, EventArgs e)
        {
            MoodItem moodItem = (MoodItem)BindingContext;
            MoodItemDatabase database = await MoodItemDatabase.Instance;
            _ = await database.SaveItemAsync(moodItem);
            _ = await Navigation.PopAsync();
        }

        private async void OnCancelClicked(object sender, EventArgs e)
        {
            _ = await Navigation.PopAsync();
        }
    }
}