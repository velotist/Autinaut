using Autinaut.Data;
using Autinaut.Models;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Autinaut.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EmotionItemsPage : ContentPage
    {
        private bool _isRunning;

        public EmotionItemsPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            EmotionItemDatabase database = await EmotionItemDatabase.Instance;
            System.Collections.Generic.List<EmotionItemViewModel> items = await database.GetItemsAsync();
            myListView.ItemsSource = items;
            Content = items.Count == 0
                ? new StackLayout
                {
                    Children =
                    {
                        new Label
                        {
                            Text = "Sei Dein Autinaut. Klicke auf das Icon in der oberen Leiste um Deinen ersten Eintrag zu erstellen.",
                            TextColor = Color.Black,
                            FontSize = 22,
                            Margin = 40
                        },
                        new Label
                        {
                            Text = "Klicke dann auf einen vorhandenen Listeneintrag um ihn zu editieren oder zu löschen.",
                            TextColor = Color.Black,
                            FontSize = 22,
                            Margin = 40
                        }
                    }
                }
                : (View)myListView;
        }

        private async void OnListItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (_isRunning)
            {
                return;
            }

            _isRunning = true;

            if (e.Item == null)
            {
                return;
            }

            try
            {
                await Navigation.PushAsync(new EmotionItemPage(true)
                {
                    BindingContext = e.Item as EmotionItemViewModel
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
                await Navigation.PushAsync(new EmotionItemPage(false)
                {
                    BindingContext = new EmotionItemViewModel()
                });
            }
            finally
            {
                _isRunning = false;
            }
        }
    }
}