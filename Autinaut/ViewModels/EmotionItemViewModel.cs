using Autinaut.Resx;
using SQLite;
using System;

namespace Autinaut.ViewModels
{
    public class EmotionItemViewModel
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public string EmotionName { get; set; } = AppResources.TextEmotionFear;
        public string EmotionSituation { get; set; }
        public string EmotionIcon { get; set; } = "fear.png";
        public int IconID { get; set; } = 3;
        public int PositiveAffectBalance { get; set; }
        public int NegativeAffectBalance { get; set; }
        public string Date { get; set; } = DateTime.Now.ToString();
    }
}