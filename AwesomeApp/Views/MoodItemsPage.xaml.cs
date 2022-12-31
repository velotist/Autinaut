using AwesomeApp.Data;
using AwesomeApp.Models;
using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AwesomeApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MoodItemsPage : ContentPage
    {
        public ObservableCollection<MoodItem> Items { get; set; }

        public MoodItemsPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            MoodItemDatabase database = await MoodItemDatabase.Instance;
            myListView.ItemsSource = await database.GetItemsAsync();
        }

        private async void OnListItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new MoodItemPage
                {
                    BindingContext = e.SelectedItem as MoodItem
                });
            }
        }

        private async void OnItemAdded(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MoodItemPage
            {
                BindingContext = new MoodItem()
            });
        }

        private async void OnChartClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MoodChartPage
            {
                BindingContext = Items
            });
        }
    }
}
