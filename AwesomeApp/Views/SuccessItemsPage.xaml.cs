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
        private DateTime Today = DateTime.Now;

        public SuccessItemsPage()
        {
            InitializeComponent();

            Items = new ObservableCollection<SuccessItem>
            {
                new SuccessItem { ID=1, SuccessNote = "Zähne geputzt", Date = Today.AddDays(1).ToString() },
                new SuccessItem { ID=2, SuccessNote = "Meditiert", Date = Today.AddDays(2).ToString() },
                new SuccessItem { ID=3, SuccessNote = "Vater angerufen", Date = Today.AddDays(4).ToString() },
                new SuccessItem { ID=4, SuccessNote = "Brief weggebracht", Date = Today.AddDays(4).ToString() },
                new SuccessItem { ID=5, SuccessNote = "Geld überwiesen", Date = Today.AddDays(5).ToString() },
                new SuccessItem { ID=6, SuccessNote = "Mit Frau ausgegangen", Date = Today.AddDays(6).ToString() },
            };
            
            MyListView.ItemsSource = Items;
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;
            var selectedItem = e.Item as SuccessItem;
            await DisplayActionSheet("Details Page:", "Cancel", null, selectedItem.Date.ToString(), selectedItem.SuccessNote.ToString());

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }
    }
}
