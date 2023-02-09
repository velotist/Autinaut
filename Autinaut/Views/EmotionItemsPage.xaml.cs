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
                ? new Label
                {
                    Text = "Sei Dein Autinaut. Klicke auf das Icon in der oberen Leiste, um Deinen ersten Eintrag zu erstellen.",
                    TextColor = Color.Black,
                    FontSize = 22,
                    Margin = 40,
                    HorizontalOptions = LayoutOptions.Fill,
                    VerticalOptions = LayoutOptions.Fill
                }
                : (View)myListView;
        }

        private async void OnListItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
            {
                return;
            }

            await Navigation.PushAsync(new EmotionItemPage
            {
                BindingContext = e.Item as EmotionItemViewModel
            });
        }

        private async void OnItemAdded(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EmotionItemPage
            {
                BindingContext = new EmotionItemViewModel()
            });
        }
    }
}