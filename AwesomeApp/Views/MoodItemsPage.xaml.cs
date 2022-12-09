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

            Items = new ObservableCollection<MoodItem>
            {
                new MoodItem { Mood = "Angry", Date = DateTime.Now.ToString() },
                new MoodItem { Mood = "Sad", Date = DateTime.Now.ToString() },
                new MoodItem { Mood = "Disgusted", Date = DateTime.Now.ToString() },
                new MoodItem { Mood = "Enjoying", Date = DateTime.Now.ToString() },
                new MoodItem { Mood = "Sad", Date = DateTime.Now.ToString() },
                new MoodItem { Mood = "Angry", Date = DateTime.Now.ToString() },
                new MoodItem { Mood = "Fear", Date = DateTime.Now.ToString() },
            };
            
            MyListView.ItemsSource = Items;
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            await DisplayAlert("Item Tapped", "An item was tapped.", "OK");

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }
    }
}
