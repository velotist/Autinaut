using Autinaut.Data;
using Autinaut.Models;
using System;
using Xamarin.Forms;

namespace Autinaut.Views
{
    public partial class MoodItemPage : ContentPage
    {
        public MoodItemPage()
        {
            InitializeComponent();
            moodNoteEditor.Unfocused += EditorUnfocused;
            moodsCarouselView.BindingContext = new CarouselMoodViewModel();
            moodsCarouselView.SelectionChanged += Carousel_SelectionChanged;
        }

        private async void EditorUnfocused(object sender, EventArgs e)
        {
            await scrollView.ScrollToAsync(buttons, ScrollToPosition.End, true);
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

        private async void OnSaveClicked(object sender, EventArgs e)
        {
            MoodItem moodItem = (MoodItem)BindingContext;
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

        private async void OnPositiveSliderValueChanged(object sender, ValueChangedEventArgs args)
        {
            double value = args.NewValue;
            MoodItem moodItem = (MoodItem)BindingContext;
            moodItem.PositiveAffectBalance = value;
            positiveLabel.Text = string.Format("Die Affektbilanz liegt bei {0}.", value);

            await scrollView.ScrollToAsync(buttons, ScrollToPosition.End, true);
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