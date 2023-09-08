using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Autinaut.Database;
using Autinaut.Models;
using Autinaut.Resx;
using Autinaut.ViewModels;
using Syncfusion.SfCarousel.XForms;
using Xamarin.Forms;
using SelectionChangedEventArgs = Syncfusion.SfCarousel.XForms.SelectionChangedEventArgs;

namespace Autinaut.Views;

public partial class EmotionItemPage : ContentPage
{
    private readonly string _affectBilanceText = AppResources.TextActualAffectBilance;

    private readonly ObservableCollection<SfCarouselItem> _carouselItems = new()
    {
        new SfCarouselItem
        {
            ItemContent = new StackLayout
            {
                Children =
                {
                    new Image
                    {
                        Source = "anger.png",
                        Aspect = Aspect.AspectFit
                    },
                    new Label
                    {
                        Text = AppResources.TextEmotionAnger,
                        TextColor = Color.Black,
                        HorizontalTextAlignment = TextAlignment.Center
                    }
                }
            }
        },
        new SfCarouselItem
        {
            ItemContent = new StackLayout
            {
                Children =
                {
                    new Image
                    {
                        Source = "contempt.png",
                        Aspect = Aspect.AspectFit
                    },
                    new Label
                    {
                        Text = AppResources.TextEmotionContempt,
                        TextColor = Color.Black,
                        HorizontalTextAlignment = TextAlignment.Center
                    }
                }
            }
        },
        new SfCarouselItem
        {
            ItemContent = new StackLayout
            {
                Children =
                {
                    new Image
                    {
                        Source = "disgust.png",
                        Aspect = Aspect.AspectFit
                    },
                    new Label
                    {
                        Text = AppResources.TextEmotionDisgust,
                        TextColor = Color.Black,
                        HorizontalTextAlignment = TextAlignment.Center
                    }
                }
            }
        },
        new SfCarouselItem
        {
            ItemContent = new StackLayout
            {
                Children =
                {
                    new Image
                    {
                        Source = "fear.png",
                        Aspect = Aspect.AspectFit
                    },
                    new Label
                    {
                        Text = AppResources.TextEmotionFear,
                        TextColor = Color.Black,
                        HorizontalTextAlignment = TextAlignment.Center
                    }
                }
            }
        },
        new SfCarouselItem
        {
            ItemContent = new StackLayout
            {
                Children =
                {
                    new Image
                    {
                        Source = "joy.png",
                        Aspect = Aspect.AspectFit
                    },
                    new Label
                    {
                        Text = AppResources.TextEmotionJoy,
                        TextColor = Color.Black,
                        HorizontalTextAlignment = TextAlignment.Center
                    }
                }
            }
        },
        new SfCarouselItem
        {
            ItemContent = new StackLayout
            {
                Children =
                {
                    new Image
                    {
                        Source = "sadness.png",
                        Aspect = Aspect.AspectFit
                    },
                    new Label
                    {
                        Text = AppResources.TextEmotionSadness,
                        TextColor = Color.Black,
                        HorizontalTextAlignment = TextAlignment.Center
                    }
                }
            }
        },
        new SfCarouselItem
        {
            ItemContent = new StackLayout
            {
                Children =
                {
                    new Image
                    {
                        Source = "surprise.png",
                        Aspect = Aspect.AspectFit
                    },
                    new Label
                    {
                        Text = AppResources.TextEmotionSurprise,
                        TextColor = Color.Black,
                        HorizontalTextAlignment = TextAlignment.Center
                    }
                }
            }
        }
    };

    public EmotionItemPage(bool hasDeleteButton)
    {
        InitializeComponent();
        SfButtonDelete.IsVisible = hasDeleteButton;
        EmotionsCarouselView.ItemsSource = _carouselItems;
        EmotionsCarouselView.SelectionChanged += Carousel_SelectionChanged;
    }

    private async void EditorUnfocused(object sender, EventArgs e)
    {
        await ScrollView.ScrollToAsync(PositiveLabel, ScrollToPosition.Center, true);
    }

    private void Carousel_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var emotion = (EmotionItemViewModel)BindingContext;
        emotion.EmotionIcon = BasicEmotion.GetIconForSelectedIndex(e.SelectedIndex);
        emotion.EmotionName = BasicEmotion.GetNameForSelectedIndex(e.SelectedIndex);
    }

    private async Task ScrollToEnd()
    {
        await ScrollView.ScrollToAsync(Buttons, ScrollToPosition.Start, true);
    }

    private async void OnSaveClicked(object sender, EventArgs e)
    {
        var emotion = (EmotionItemViewModel)BindingContext;
        if (string.IsNullOrEmpty(emotion.EmotionSituation))
        {
            await DisplayAlert(AppResources.NotificationTitle, AppResources.NotificationSituationText, "OK");
            SfButtonSave.IsChecked = false;

            await ScrollView.ScrollToAsync(ScrollView, ScrollToPosition.Start, true);

            return;
        }

        var databaseHelper = new DatabaseHelper();
        _ = await databaseHelper.SaveItemAsync(emotion);

        await Navigation.PopToRootAsync();
    }

    private async void OnDeleteClicked(object sender, EventArgs e)
    {
        var emotion = (EmotionItemViewModel)BindingContext;
        var databaseHelper = new DatabaseHelper();
        _ = await databaseHelper.DeleteItemAsync(emotion);

        await Navigation.PopToRootAsync();
    }

    private void OnPositiveSliderValueChanged(object sender, ValueChangedEventArgs args)
    {
        var emotion = (EmotionItemViewModel)BindingContext;
        emotion.PositiveAffectBalance = (int)Math.Round(args.NewValue);
        PositiveLabel.Text = string.Format(_affectBilanceText, emotion.PositiveAffectBalance);

        _ = ScrollToEnd();
    }

    private void OnNegativeSliderValueChanged(object sender, ValueChangedEventArgs args)
    {
        var emotion = (EmotionItemViewModel)BindingContext;
        emotion.NegativeAffectBalance = (int)Math.Round(args.NewValue);
        NegativeLabel.Text = string.Format(_affectBilanceText, emotion.NegativeAffectBalance);
    }
}