using System;
using Autinaut.Common;
using Autinaut.Database;
using Autinaut.Resx;
using Autinaut.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Autinaut.Views;

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

        var databaseHelper = new DatabaseHelper();

        var items = await databaseHelper.GetItemsAsync<SuccessItemViewModel>(Order.Descending);
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
        if (e.Item == null) return;

        if (_isRunning) return;

        _isRunning = true;

        try
        {
            await Navigation.PushAsync(new SuccessItemPage(true)
            {
                BindingContext = e.Item as SuccessItemViewModel
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