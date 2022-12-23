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
            BindingContext = new MoodItem { Date = DateTime.Now.ToString() };
        }

        async void OnSaveClicked(object sender, EventArgs e)
        {
            var moodItem = (MoodItem)BindingContext;
            MoodItemDatabase database = await MoodItemDatabase.Instance;
            await database.SaveItemAsync(moodItem);
            await Navigation.PopAsync();
        }

        async void OnCancelClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}