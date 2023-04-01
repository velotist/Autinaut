using Autinaut.Models;
using Autinaut.Resx;

namespace Autinaut.ViewModels
{
    public class EmotionItemViewModel : ItemViewModel, IEmotion
    {
        public int PositiveAffectBalance { get; set; }
        public int NegativeAffectBalance { get; set; }

        public int EmotionID { get; set; } = 3;
        public string Name { get; set; } = AppResources.TextEmotionFear;
        public string Icon { get; set; } = "fear.png";
    }
}