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
        public MoodItemPage ()
        {
            InitializeComponent();
            moodsCarouselView.SelectionChanged += Carousel_SelectionChanged;
            BindingContext = new MoodItem() { Date = DateTime.Now.ToString() };

            Feelings = new ObservableCollection<BasicFeeling>
            {
                new BasicFeeling { Name = "Anger", MoodIcon = "anger.png" },
                new BasicFeeling { Name = "Fear", MoodIcon = "fear.png" },
                new BasicFeeling { Name = "Contempt", MoodIcon = "contempt.png" },
                new BasicFeeling { Name = "Disgust", MoodIcon = "disgust.png" },
                new BasicFeeling { Name = "Joy", MoodIcon = "joy.png" },
                new BasicFeeling { Name = "Sadness", MoodIcon = "sadness.png" },
                new BasicFeeling { Name = "Surprise", MoodIcon = "surprise.png" }
            };

            moodsCarouselView.ItemsSource = Feelings;
        }

        private void Carousel_SelectionChanged (object sender, Syncfusion.SfCarousel.XForms.SelectionChangedEventArgs e)
        {
            OnSaveClicked(sender, e);
        }

        private async void OnSaveClicked (object sender, EventArgs e)
        {
            MoodItem moodItem = (MoodItem)BindingContext;
            moodItem.MoodIcon = "anger.png";
            moodItem.Mood = "Angry";
            MoodItemDatabase database = await MoodItemDatabase.Instance;
            _ = await database.SaveItemAsync(moodItem);
            _ = await Navigation.PopAsync();
        }

        private async void OnCancelClicked (object sender, EventArgs e)
        {
            _ = await Navigation.PopAsync();
        }
    }
}