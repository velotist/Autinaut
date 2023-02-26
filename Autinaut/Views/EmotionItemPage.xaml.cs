using Autinaut.Data;
using Autinaut.Models;
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
        private readonly string affectBilanceText = "Die Affektbilanz liegt bei {0} %.";

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
                            Text = "Wut",
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
                            Text = "Verachtung",
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
                            Text = "Ekel",
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
                                Text = "Angst",
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
                            Text = "Freude",
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
                            Text = "Trauer",
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
                            Text = "Überraschung",
                            TextColor = Color.Black,
                            HorizontalTextAlignment=TextAlignment.Center
                        }
                    }
                }
            },
        };

        private readonly List<Emotions> BasicEmotions = new List<Emotions> {
            new Emotions { ID = 1, Name = "Wut", Icon = "anger.png" },
            new Emotions { ID = 2, Name = "Verachtung", Icon = "contempt.png" },
            new Emotions { ID = 3, Name = "Ekel", Icon = "disgust.png" },
            new Emotions { ID = 4, Name = "Angst", Icon = "fear.png" },
            new Emotions { ID = 5, Name = "Freude", Icon = "joy.png" },
            new Emotions { ID = 6, Name = "Trauer", Icon = "sadness.png" },
            new Emotions { ID = 7, Name = "Überraschung", Icon = "surprise.png" }
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
                await DisplayAlert("Meldung", "Bitte trage eine Situation ein.", "OK");
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