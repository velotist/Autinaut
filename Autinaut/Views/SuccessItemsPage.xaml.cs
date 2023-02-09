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

            await Navigation.PushAsync(new SuccessItemPage
            {
                BindingContext = e.Item as SuccessItemViewModel
            });
        }

        private async void OnItemAdded(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SuccessItemPage
            {
                BindingContext = new SuccessItemViewModel()
            });
        }
    }
}