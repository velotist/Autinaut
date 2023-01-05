﻿using Autinaut.Data;
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
            moodsCarouselView.BindingContext = new CarouselMoodViewModel();
            moodsCarouselView.SelectionChanged += Carousel_SelectionChanged;
        }

        private void Carousel_SelectionChanged(object sender, Syncfusion.SfCarousel.XForms.SelectionChangedEventArgs e)
        {
            MoodItem moodItem = (MoodItem)BindingContext;
            switch (e.SelectedIndex)
            {
                case 0:
                    moodItem.MoodIcon = "anger.png";
                    moodItem.Mood = "Angry";
                    break;
                case 1:
                    moodItem.MoodIcon = "contempt.png";
                    moodItem.Mood = "Contempt";
                    break;
                case 2:
                    moodItem.MoodIcon = "disgust.png";
                    moodItem.Mood = "Disgust";
                    break;
                case 3:
                    moodItem.MoodIcon = "fear.png";
                    moodItem.Mood = "Fear";
                    break;
                case 4:
                    moodItem.MoodIcon = "joy.png";
                    moodItem.Mood = "Joy";
                    break;
                case 5:
                    moodItem.MoodIcon = "sadness.png";
                    moodItem.Mood = "Sadness";
                    break;
                case 6:
                    moodItem.MoodIcon = "surprise.png";
                    moodItem.Mood = "Surprise";
                    break;
                default:
                    moodItem.MoodIcon = "disgust.png";
                    moodItem.Mood = "Disgust";
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

        private void OnPositiveSliderValueChanged(object sender, ValueChangedEventArgs args)
        {
            double value = args.NewValue;
            MoodItem moodItem = (MoodItem)BindingContext;
            moodItem.PositiveAffectBalance = value;
            positiveLabel.Text = string.Format("The Slider value is {0}", value);
        }
        private void OnNegativeSliderValueChanged(object sender, ValueChangedEventArgs args)
        {
            double value = args.NewValue;
            MoodItem moodItem = (MoodItem)BindingContext;
            moodItem.NegativeAffectBalance = value;
            negativeLabel.Text = string.Format("The Slider value is {0}", value);
        }
    }
}