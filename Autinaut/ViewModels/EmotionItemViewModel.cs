using System;
using Autinaut.Database;
using Autinaut.Resx;
using SQLite;

namespace Autinaut.ViewModels;

public class EmotionItemViewModel : IDatabaseEntity
{
    [PrimaryKey] [AutoIncrement] public int Id { get; set; }
    public DateTime Date { get; set; } = DateTime.Now;
    public string EmotionName { get; set; } = AppResources.TextEmotionFear;
    private string _emotionSituation;
    public string EmotionSituation
    {
        get => _emotionSituation;
        set =>
            _emotionSituation = value is { Length: > 500 } ? value.Substring(0, 500) :
                value;
    }
    public string EmotionIcon { get; set; } = "fear.png";
    public int IconId { get; set; } = 3;
    public int PositiveAffectBalance { get; set; }
    public int NegativeAffectBalance { get; set; }
}