using System.Collections.Generic;

namespace AwesomeApp.Models
{
    public class CarouselMoodViewModel
    {
        public CarouselMoodViewModel()
        {
            ImageCollection.Add(new CarouselMoodModel("anger.png", "Anger"));
            ImageCollection.Add(new CarouselMoodModel("contempt.png", "Contempt"));
            ImageCollection.Add(new CarouselMoodModel("disgust.png", "Disgust"));
            ImageCollection.Add(new CarouselMoodModel("fear.png", "Fear"));
            ImageCollection.Add(new CarouselMoodModel("joy.png", "Joy"));
            ImageCollection.Add(new CarouselMoodModel("sadness.png", "Sadness"));
            ImageCollection.Add(new CarouselMoodModel("surprise.png", "Surprise"));
        }

        public List<CarouselMoodModel> ImageCollection { get; set; } = new List<CarouselMoodModel>();
    }
}
