using AwesomeApp.Models;
using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AwesomeApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SuccessItemsPage : ContentPage
    {
        public ObservableCollection<SuccessItem> Items { get; set; }

        public SuccessItemsPage()
        {
            InitializeComponent();

            Items = new ObservableCollection<SuccessItem>
            {
                new SuccessItem { SuccessNote = "Zähne geputzt", Date = DateTime.Now.ToString() },
                new SuccessItem { SuccessNote = "Hintern gewaschen", Date = DateTime.Now.ToString() },
                new SuccessItem { SuccessNote = "Vater angerufen", Date = DateTime.Now.ToString() },
                new SuccessItem { SuccessNote = "Brief weggebracht", Date = DateTime.Now.ToString() },
                new SuccessItem { SuccessNote = "Geld überwiesen", Date = DateTime.Now.ToString() },
                new SuccessItem { SuccessNote = "Mit Frau ausgegangen", Date = DateTime.Now.ToString() },
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
