using AwesomeApp.Data;
using AwesomeApp.Models;
using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace AwesomeApp.Views
{
    public partial class MoodItemPage : ContentPage
    {
        public ObservableCollection<BasicFeeling> Feelings { get; set; }
        public MoodItemPage()
        {
            InitializeComponent();
            BindingContext = new MoodItem { Date = DateTime.Now.ToString() };
        }

        private void Carousel_SelectionChanged(object sender, Syncfusion.SfCarousel.XForms.SelectionChangedEventArgs e)
        {
            OnSaveClicked(sender, e);
        }

        private async void OnSaveClicked(object sender, Syncfusion.SfCarousel.XForms.SelectionChangedEventArgs e)
        {
            MoodItem moodItem = (MoodItem)BindingContext;
            switch (e.SelectedIndex)
            {
                case 1:
                    moodItem.MoodIcon = "anger.png";
                    moodItem.Mood = "Angry";
                    break;
                case 2:
                    moodItem.MoodIcon = "contempt.png";
                    moodItem.Mood = "Contempt";
                    break;
                case 3:
                    moodItem.MoodIcon = "disgust.png";
                    moodItem.Mood = "Disgust";
                    break;
                case 4:
                    moodItem.MoodIcon = "fear.png";
                    moodItem.Mood = "Fear";
                    break;
                case 5:
                    moodItem.MoodIcon = "joy.png";
                    moodItem.Mood = "Joy";
                    break;
                case 6:
                    moodItem.MoodIcon = "sadness.png";
                    moodItem.Mood = "Sadness";
                    break;
                case 7:
                    moodItem.MoodIcon = "surprise.png";
                    moodItem.Mood = "Surprise";
                    break;
            }
            MoodItemDatabase database = await MoodItemDatabase.Instance;
            _ = await database.SaveItemAsync(moodItem);
            _ = await Navigation.PopAsync();
        }

        private async void OnCancelClicked(object sender, EventArgs e)
        {
            _ = await Navigation.PopAsync();
        }
    }
}