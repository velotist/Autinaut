using System;
using Autinaut.Resx;
using SQLite;

namespace Autinaut.ViewModels
{
    public class EmotionItemViewModel
    {
        [PrimaryKey] [AutoIncrement] public int Id { get; set; }

        public string EmotionName { get; set; } = AppResources.TextEmotionFear;
        public string EmotionSituation { get; set; }
        public string EmotionIcon { get; set; } = "fear.png";
        public int IconId { get; set; } = 3;
        public int PositiveAffectBalance { get; set; }
        public int NegativeAffectBalance { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
    }
}