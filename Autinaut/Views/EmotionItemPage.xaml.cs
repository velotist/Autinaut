using Autinaut.Models;
using Autinaut.Resx;
using Autinaut.ViewModels;
using Syncfusion.SfCarousel.XForms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Autinaut.Views
{
    public partial class EmotionItemPage : ContentPage
    {
        private readonly string affectBilanceText = AppResources.TextActualAffectBilance;

        private readonly List<Emotions> BasicEmotions = new List<Emotions> {
            new Emotions { ID = 1, Name = AppResources.TextEmotionAnger, Icon = "anger.png" },
            new Emotions { ID = 2, Name = AppResources.TextEmotionContempt, Icon = "contempt.png" },
            new Emotions { ID = 3, Name = AppResources.TextEmotionDisgust, Icon = "disgust.png" },
            new Emotions { ID = 4, Name = AppResources.TextEmotionFear, Icon = "fear.png" },
            new Emotions { ID = 5, Name = AppResources.TextEmotionJoy, Icon = "joy.png" },
            new Emotions { ID = 6, Name = AppResources.TextEmotionSadness, Icon = "sadness.png" },
            new Emotions { ID = 7, Name = AppResources.TextEmotionSurprise, Icon = "surprise.png" }
        };

        private readonly ObservableCollection<SfCarouselItem> CarouselItems = new ObservableCollection<SfCarouselItem>
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
                            HorizontalTextAlignment=TextAlignment.Center
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
                            HorizontalTextAlignment=TextAlignment.Center
                        }
                    }
                }
            },
        };

        public EmotionItemPage(bool hasDeleteButton)
        {
            InitializeComponent();
            SfButtonDelete.IsVisible = hasDeleteButton;
            EmotionsCarouselView.ItemsSource = CarouselItems;
            EmotionsCarouselView.SelectionChanged += Carousel_SelectionChanged;
        }

        private async void EditorUnfocused(object sender, EventArgs e)
        {
            await scrollView.ScrollToAsync(positiveLabel, ScrollToPosition.Center, true);
        }

        private void Carousel_SelectionChanged(object sender, Syncfusion.SfCarousel.XForms.SelectionChangedEventArgs e)
        {
            EmotionItemViewModel EmotionItem = (EmotionItemViewModel)BindingContext;
            EmotionItem.EmotionIcon = BasicEmotions[e.SelectedIndex].Icon;
            EmotionItem.EmotionName = BasicEmotions[e.SelectedIndex].Name;
        }

        private async Task ScrollToEnd()
        {
            await scrollView.ScrollToAsync(buttons, ScrollToPosition.Start, true);
        }

        private async void OnSaveClicked(object sender, EventArgs e)
        {
            EmotionItemViewModel EmotionItem = (EmotionItemViewModel)BindingContext;
            if (string.IsNullOrEmpty(EmotionItem.EmotionSituation))
            {
                await DisplayAlert(AppResources.NotificationTitle, AppResources.NotificationSituationText, "OK");
                SfButtonSave.IsChecked = false;

                await scrollView.ScrollToAsync(scrollView, ScrollToPosition.Start, true);

                return;
            }

            EmotionItemDatabase database = await EmotionItemDatabase.Instance;
            _ = await database.SaveItemAsync(EmotionItem);

            await Navigation.PopToRootAsync();
        }

        private async void OnDeleteClicked(object sender, EventArgs e)
        {
            EmotionItemViewModel EmotionItem = (EmotionItemViewModel)BindingContext;
            EmotionItemDatabase database = await EmotionItemDatabase.Instance;
            _ = await database.DeleteItemAsync(EmotionItem);

            await Navigation.PopToRootAsync();
        }

        private void OnPositiveSliderValueChanged(object sender, ValueChangedEventArgs args)
        {
            EmotionItemViewModel EmotionItem = (EmotionItemViewModel)BindingContext;
            EmotionItem.PositiveAffectBalance = (int)Math.Round(args.NewValue);
            positiveLabel.Text = string.Format(affectBilanceText, EmotionItem.PositiveAffectBalance);

            _ = ScrollToEnd();
        }

        private void OnNegativeSliderValueChanged(object sender, ValueChangedEventArgs args)
        {
            EmotionItemViewModel EmotionItem = (EmotionItemViewModel)BindingContext;
            EmotionItem.NegativeAffectBalance = (int)Math.Round(args.NewValue);
            negativeLabel.Text = string.Format(affectBilanceText, EmotionItem.NegativeAffectBalance);
        }
    }
}