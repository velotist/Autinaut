namespace AwesomeApp.Models
{
    public class CarouselMoodModel
    {
        public CarouselMoodModel(string imageString, string imageName)
        {
            Image = imageString;
            Name = imageName;
        }

        public string Image { get; set; }
        public string Name { get; set; }
    }
}
