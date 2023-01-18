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
            myListView.ItemsSource = await database.GetItemsAsync();
            System.Collections.Generic.List<SuccessItem> items = await database.GetItemsAsync();
            if (items.Count == 0)
            {
                Label hintLabel = new Label
                {
                    Text = "Sei Dein Autinaut. Klicke auf das Icon in der oberen Leiste, um Deinen ersten Eintrag zu erstellen.",
                    TextColor = Color.GhostWhite,
                    FontSize = 24,
                    Margin = 20,
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.Center
                };

                Content = hintLabel;
            }
            else
            {
                Content = myListView;
            }
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
