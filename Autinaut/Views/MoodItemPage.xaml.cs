using Autinaut.Data;
using Autinaut.Models;
using Syncfusion.SfCarousel.XForms;
using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace Autinaut.Views
{
    public partial class MoodItemPage : ContentPage
    {
        public MoodItemPage()
        {
            InitializeComponent();
            ObservableCollection<SfCarouselItem> carouselItems = new ObservableCollection<SfCarouselItem>
            {
                new SfCarouselItem()
                {
                    ItemContent = new StackLayout
                    {
                        Children =
                        {
                            new Image()
                            {
                                Source = "anger.png",
                                Aspect = Aspect.AspectFit
                            },
                            new Label
                            {
                                Text = "Wut",
                                HorizontalTextAlignment = TextAlignment.Center
                            }
                        }
                    }
                },
                new SfCarouselItem() {
                    ItemContent = new StackLayout
                    {
                        Children =
                        {
                            new Image()
                            {
                                Source = "contempt.png",
                                Aspect = Aspect.AspectFit
                            },
                            new Label
                            {
                                Text = "Verachtung",
                                HorizontalTextAlignment = TextAlignment.Center
                            }
                        }
                    }
                },
                new SfCarouselItem() {
                    ItemContent = new StackLayout
                    {
                        Children =
                        {
                            new Image()
                            {
                                Source = "disgust.png",
                                Aspect = Aspect.AspectFit
                            },
                            new Label
                            {
                                Text = "Ekel",
                                HorizontalTextAlignment = TextAlignment.Center
                            }
                        }
                    }
                },
                new SfCarouselItem() {
                    ItemContent = new StackLayout
                    {
                        Children =
                        {
                            new Image()
                            {
                                Source = "fear.png",
                                Aspect = Aspect.AspectFit
                            },
                            new Label
                            {
                                Text = "Angst",
                                HorizontalTextAlignment = TextAlignment.Center
                            }
                        }
                    }
                },
                new SfCarouselItem() {
                    ItemContent = new StackLayout
                    {
                        Children =
                        {
                            new Image()
                            {
                                Source = "joy.png",
                                Aspect = Aspect.AspectFit
                            },
                            new Label
                            {
                                Text = "Freude",
                                HorizontalTextAlignment = TextAlignment.Center
                            }
                        }
                    }
                },
               new SfCarouselItem() {
                    ItemContent = new StackLayout
                    {
                        Children =
                        {
                            new Image()
                            {
                                Source = "sadness.png",
                                Aspect = Aspect.AspectFit
                            },
                            new Label
                            {
                                Text = "Trauer",
                                HorizontalTextAlignment=TextAlignment.Center
                            }
                        }
                    }
                },
                new SfCarouselItem() {
                    ItemContent = new StackLayout
                    {
                        Children =
                        {
                            new Image()
                            {
                                Source = "surprise.png",
                                Aspect = Aspect.AspectFit
                            },
                            new Label
                            {
                                Text = "Überraschung",
                                HorizontalTextAlignment=TextAlignment.Center
                            }
                        }
                    }
                },
            };
            moodsCarouselView.ItemsSource = carouselItems;
            moodsCarouselView.SelectionChanged += Carousel_SelectionChanged;
        }

        private async void EditorUnfocused(object sender, EventArgs e)
        {
            await scrollView.ScrollToAsync(positiveLabel, ScrollToPosition.Center, true);
        }

        private void Carousel_SelectionChanged(object sender, Syncfusion.SfCarousel.XForms.SelectionChangedEventArgs e)
        {
            MoodItem moodItem = (MoodItem)BindingContext;
            switch (e.SelectedIndex)
            {
                case 0:
                    moodItem.MoodIcon = "anger.png";
                    moodItem.Mood = "Wut";
                    break;
                case 1:
                    moodItem.MoodIcon = "contempt.png";
                    moodItem.Mood = "Verachtung";
                    break;
                case 2:
                    moodItem.MoodIcon = "disgust.png";
                    moodItem.Mood = "Ekel";
                    break;
                case 3:
                    moodItem.MoodIcon = "fear.png";
                    moodItem.Mood = "Angst";
                    break;
                case 4:
                    moodItem.MoodIcon = "joy.png";
                    moodItem.Mood = "Freude";
                    break;
                case 5:
                    moodItem.MoodIcon = "sadness.png";
                    moodItem.Mood = "Trauer";
                    break;
                case 6:
                    moodItem.MoodIcon = "surprise.png";
                    moodItem.Mood = "Überraschung";
                    break;
                default:
                    moodItem.MoodIcon = "anger.png";
                    moodItem.Mood = "Wut";
                    break;
            }
        }

        private async void ScrollToEnd()
        {
            await scrollView.ScrollToAsync(buttons, ScrollToPosition.End, true);
        }

        private async void OnSaveClicked(object sender, EventArgs e)
        {
            MoodItem moodItem = (MoodItem)BindingContext;
            if (string.IsNullOrEmpty(moodItem.MoodSituation))
            {
                await DisplayAlert("Meldung", "Bitte trage eine Situation ein.", "OK");
                SfButtonSave.IsChecked = false;
                await scrollView.ScrollToAsync(scrollView, ScrollToPosition.Start, true);

                return;
            }

            MoodItemDatabase database = await MoodItemDatabase.Instance;
            _ = await database.SaveItemAsync(moodItem);
            await Navigation.PopToRootAsync();
        }

        private async void OnDeleteClicked(object sender, EventArgs e)
        {
            MoodItem moodItem = (MoodItem)BindingContext;
            MoodItemDatabase database = await MoodItemDatabase.Instance;
            _ = await database.DeleteItemAsync(moodItem);
            await Navigation.PopToRootAsync();
        }

        private async void OnCancelClicked(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }

        private void OnPositiveSliderValueChanged(object sender, ValueChangedEventArgs args)
        {
            double value = args.NewValue;
            MoodItem moodItem = (MoodItem)BindingContext;
            moodItem.PositiveAffectBalance = value;
            positiveLabel.Text = string.Format("Die Affektbilanz liegt bei {0}.", value);

            ScrollToEnd();
        }
        private void OnNegativeSliderValueChanged(object sender, ValueChangedEventArgs args)
        {
            double value = args.NewValue;
            MoodItem moodItem = (MoodItem)BindingContext;
            moodItem.NegativeAffectBalance = value;
            negativeLabel.Text = string.Format("Die Affektbilanz liegt bei {0}.", value);
        }
    }
}