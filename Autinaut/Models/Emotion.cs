using Autinaut.Resx;
using System.Collections.Immutable;

namespace Autinaut.Models
{
    public sealed class Emotion : IEmotion
    {
        public int EmotionID { get; }
        public string Name { get; }
        public string Icon { get; }

        private static readonly ImmutableList<Emotion> _emotions = ImmutableList.Create(
            new Emotion(1, AppResources.TextEmotionAnger, "anger.png"),
            new Emotion(2, AppResources.TextEmotionContempt, "contempt.png"),
            new Emotion(3, AppResources.TextEmotionDisgust, "disgust.png"),
            new Emotion(4, AppResources.TextEmotionFear, "fear.png"),
            new Emotion(5, AppResources.TextEmotionJoy, "joy.png"),
            new Emotion(6, AppResources.TextEmotionSadness, "sadness.png"),
            new Emotion(7, AppResources.TextEmotionSurprise, "surprise.png")
        );

        private Emotion(int id, string name, string icon)
        {
            EmotionID = id;
            Name = name;
            Icon = icon;
        }

        public static ImmutableList<Emotion> GetEmotionsList()
        {
            return _emotions;
        }
    }
}