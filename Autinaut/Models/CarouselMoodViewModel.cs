using System.Collections.Generic;

namespace Autinaut.Models
{
    public class CarouselMoodViewModel
    {
        public CarouselMoodViewModel()
        {
            ImageCollection.Add(new CarouselMoodModel("anger.png", "Wut"));
            ImageCollection.Add(new CarouselMoodModel("contempt.png", "Verachtung"));
            ImageCollection.Add(new CarouselMoodModel("disgust.png", "Ekel"));
            ImageCollection.Add(new CarouselMoodModel("fear.png", "Angst"));
            ImageCollection.Add(new CarouselMoodModel("joy.png", "Freude"));
            ImageCollection.Add(new CarouselMoodModel("sadness.png", "Trauer"));
            ImageCollection.Add(new CarouselMoodModel("surprise.png", "Überraschung"));
        }

        public List<CarouselMoodModel> ImageCollection { get; set; } = new List<CarouselMoodModel>();
    }
}
