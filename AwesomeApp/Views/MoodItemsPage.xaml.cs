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

            var database = await MoodItemDatabase.Instance;
            myListView.ItemsSource = await database.GetItemsAsync();
        }

        async void OnListItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new MoodItemPage
                {
                    BindingContext = e.SelectedItem as MoodItem
                });
            }
        }

        async void OnItemAdded(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MoodItemPage
            {
                BindingContext = new MoodItem()
            });
        }

        async void OnChartClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MoodChartPage
            {
                BindingContext = Items
            });
        }
    }
}
