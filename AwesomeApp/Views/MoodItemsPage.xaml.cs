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

        private DateTime Today = DateTime.Now;

        public MoodItemsPage()
        {
            InitializeComponent();

            Items = new ObservableCollection<MoodItem>
            {
                new MoodItem { ID=1, Mood = "Angry", Date = Today.AddDays(1).ToString("dd.MMM.yyyy") },
                new MoodItem { ID=2, Mood = "Sad", Date = Today.AddDays(1).ToString("dd.MMM.yyyy") },
                new MoodItem { ID=3, Mood = "Disgusted", Date = Today.AddDays(2).ToString("dd.MMM.yyyy") },
                new MoodItem { ID=4, Mood = "Enjoying", Date = Today.AddDays(3).ToString("dd.MMM.yyyy") },
                new MoodItem { ID=5, Mood = "Sad", Date = Today.AddDays(4).ToString("dd.MMM.yyyy") },
                new MoodItem { ID=6, Mood = "Angry", Date = Today.AddDays(5).ToString("dd.MMM.yyyy") },
                new MoodItem { ID=7, Mood = "Fear", Date = Today.AddDays(5).ToString("dd.MMM.yyyy") },
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
