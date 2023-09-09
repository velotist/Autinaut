using System.Collections.Generic;
using Autinaut.Resx;

namespace Autinaut.Models;

public class BasicEmotion
{
    private static readonly List<BasicEmotion> BasicEmotions = new()
    {
        new BasicEmotion(AppResources.TextEmotionAnger, "anger.png"),
        new BasicEmotion(AppResources.TextEmotionContempt, "contempt.png"),
        new BasicEmotion(AppResources.TextEmotionDisgust, "disgust.png"),
        new BasicEmotion(AppResources.TextEmotionFear, "fear.png"),
        new BasicEmotion(AppResources.TextEmotionJoy, "joy.png"),
        new BasicEmotion(AppResources.TextEmotionSadness, "sadness.png"),
        new BasicEmotion(AppResources.TextEmotionSurprise, "surprise.png")
    };

    private BasicEmotion(string name, string icon)
    {
        Name = name;
        Icon = icon;
    }

    private string Name { get; }
    private string Icon { get; }

    public static string GetIconForSelectedIndex(int selectedIndex)
    {
        if (selectedIndex >= 0 && selectedIndex < BasicEmotions.Count) return BasicEmotions[selectedIndex].Icon;

        return null;
    }

    public static string GetNameForSelectedIndex(int selectedIndex)
    {
        if (selectedIndex >= 0 && selectedIndex < BasicEmotions.Count) return BasicEmotions[selectedIndex].Name;

        return null;
    }
}