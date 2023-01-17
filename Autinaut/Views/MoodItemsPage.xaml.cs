using Autinaut.Data;
using Autinaut.Models;
using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Autinaut.Views
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

        private async void OnListItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
            {
                return;
            }

            await Navigation.PushAsync(new MoodItemPage
            {
                BindingContext = e.Item
            });
        }

        private async void OnItemAdded(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MoodItemPage
            {
                BindingContext = new MoodItem()
            });
        }
    }
}
