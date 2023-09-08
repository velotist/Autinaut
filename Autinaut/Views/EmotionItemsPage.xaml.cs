using System;
using Autinaut.Common;
using Autinaut.Database;
using Autinaut.Resx;
using Autinaut.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Autinaut.Views;

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

        var databaseHelper = new DatabaseHelper();
        var items = await databaseHelper.GetItemsAsync<EmotionItemViewModel>(Order.Descending);
        MyListView.ItemsSource = items;
        Content = items.Count == 0
            ? new StackLayout
            {
                Children =
                {
                    new Label
                    {
                        Text = AppResources.LabelInitialTextPartOne,
                        TextColor = Color.Black,
                        FontSize = 22,
                        Margin = 40
                    },
                    new Label
                    {
                        Text = AppResources.LabelInitialTextPartTwo,
                        TextColor = Color.Black,
                        FontSize = 22,
                        Margin = 40
                    }
                }
            }
            : MyListView;
    }

    private async void OnListItemTapped(object sender, ItemTappedEventArgs e)
    {
        if (_isRunning) return;

        _isRunning = true;

        if (e.Item == null) return;

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
        if (_isRunning) return;

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