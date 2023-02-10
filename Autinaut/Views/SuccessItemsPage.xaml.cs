using Autinaut.Data;
using Autinaut.Models;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Autinaut.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SuccessItemsPage : ContentPage
    {
        private bool _isRunning;

        public SuccessItemsPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            SuccessItemDatabase database = await SuccessItemDatabase.Instance;
            System.Collections.Generic.List<SuccessItemViewModel> items = await database.GetItemsAsync();
            myListView.ItemsSource = items;
            Content = items.Count == 0
                ? new Label
                {
                    Text = "Sei Dein Autinaut. Klicke auf das Icon in der oberen Leiste, um Deinen ersten Eintrag zu erstellen.",
                    TextColor = Color.Black,
                    FontSize = 22,
                    Margin = 40
                }
                : (View)myListView;
        }

        private async void OnListItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
            {
                return;
            }

            if (_isRunning)
            {
                return;
            }

            _isRunning = true;

            try
            {
                await Navigation.PushAsync(new SuccessItemPage(true)
                {
                    BindingContext = e.SelectedItem as SuccessItemViewModel
                });
            }
            finally
            {
                _isRunning = false;
            }
        }

        private async void OnItemAdded(object sender, EventArgs e)
        {
            if (_isRunning)
            {
                return;
            }

            _isRunning = true;

            try
            {
                await Navigation.PushAsync(new SuccessItemPage(false)
                {
                    BindingContext = new SuccessItemViewModel()
                });
            }
            finally
            {
                _isRunning = false;
            }
        }
    }
}