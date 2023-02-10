using Autinaut.Data;
using Autinaut.Models;
using Syncfusion.SfCarousel.XForms;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Autinaut.Views
{
    public partial class EmotionItemPage : ContentPage
    {
        private readonly string affectBilanceText = "Die Affektbilanz liegt bei {0} %.";

        public ObservableCollection<SfCarouselItem> CarouselItems { get; set; }

        public EmotionItemPage()
        {
            InitializeComponent();
            AddCarouselItems();
            EmotionsCarouselView.ItemsSource = CarouselItems;
            EmotionsCarouselView.SelectedIndex = GetSelectedEmotion();
            EmotionsCarouselView.SelectionChanged += Carousel_SelectionChanged;
        }

        private async void EditorUnfocused(object sender, EventArgs e)
        {
            await scrollView.ScrollToAsync(positiveLabel, ScrollToPosition.Center, true);
        }

        private void AddCarouselItems()
        {
            CarouselItems = new ObservableCollection<SfCarouselItem>
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
                                TextColor = Color.Black,
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
                                TextColor = Color.Black,
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
                                TextColor = Color.Black,
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
                                TextColor = Color.Black,
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
                                TextColor = Color.Black,
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
                                TextColor = Color.Black,
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
                                TextColor = Color.Black,
                                HorizontalTextAlignment=TextAlignment.Center
                            }
                        }
                    }
                },
            };
        }

        private int GetSelectedEmotion()
        {
            EmotionItemViewModel EmotionItem = (EmotionItemViewModel)BindingContext;

            switch (EmotionItem.Emotion)
            {
                case "Wut":
                    EmotionItem.ImageID = 0;
                    break;

                case "Verachtung":
                    EmotionItem.ImageID = 1;
                    break;

                case "Ekel":
                    EmotionItem.ImageID = 2;
                    break;

                case "Angst":
                    EmotionItem.ImageID = 3;
                    break;

                case "Freude":
                    EmotionItem.ImageID = 4;
                    break;

                case "Trauer":
                    EmotionItem.ImageID = 5;
                    break;

                case "Überraschung":
                    EmotionItem.ImageID = 6;
                    break;

                default:
                    EmotionItem.ImageID = 3;
                    break;
            }

            return EmotionItem.ImageID;
        }

        private void Carousel_SelectionChanged(object sender, Syncfusion.SfCarousel.XForms.SelectionChangedEventArgs e)
        {
            EmotionItemViewModel EmotionItem = (EmotionItemViewModel)BindingContext;
            switch (e.SelectedIndex)
            {
                case 0:
                    EmotionItem.EmotionIcon = "anger.png";
                    EmotionItem.Emotion = "Wut";
                    break;

                case 1:
                    EmotionItem.EmotionIcon = "contempt.png";
                    EmotionItem.Emotion = "Verachtung";
                    break;

                case 2:
                    EmotionItem.EmotionIcon = "disgust.png";
                    EmotionItem.Emotion = "Ekel";
                    break;

                case 3:
                    EmotionItem.EmotionIcon = "fear.png";
                    EmotionItem.Emotion = "Angst";
                    break;

                case 4:
                    EmotionItem.EmotionIcon = "joy.png";
                    EmotionItem.Emotion = "Freude";
                    break;

                case 5:
                    EmotionItem.EmotionIcon = "sadness.png";
                    EmotionItem.Emotion = "Trauer";
                    break;

                case 6:
                    EmotionItem.EmotionIcon = "surprise.png";
                    EmotionItem.Emotion = "Überraschung";
                    break;
            }
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

        private async void OnCancelClicked(object sender, EventArgs e)
        {
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