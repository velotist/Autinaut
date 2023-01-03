using Autinaut.Data;
using Autinaut.Models;
using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Autinaut.Views
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

            SuccessItemDatabase database = await SuccessItemDatabase.Instance;
            myListView.ItemsSource = await database.GetItemsAsync();
        }

        private async void OnListItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new SuccessItemPage
                {
                    BindingContext = e.SelectedItem as SuccessItem
                });
            }
        }

        private async void OnItemAdded(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SuccessItemPage
            {
                BindingContext = new SuccessItem()
            });
        }
    }
}
