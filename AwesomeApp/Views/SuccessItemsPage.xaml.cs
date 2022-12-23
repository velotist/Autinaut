using AwesomeApp.Data;
using AwesomeApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
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
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var database = await SuccessItemDatabase.Instance;
            myListView.ItemsSource = await database.GetItemsAsync();
        }

        async void OnListItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new SuccessItemPage
                {
                    BindingContext = e.SelectedItem as SuccessItem
                });
            }
        }

        async void OnItemAdded(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SuccessItemPage
            {
                BindingContext = new SuccessItem()
            });
        }
    }
}
