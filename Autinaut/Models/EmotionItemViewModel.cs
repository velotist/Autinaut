using SQLite;
using System;

namespace Autinaut.Models
{
    public class EmotionItemViewModel
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Emotion { get; set; } = "Angst";
        public string EmotionSituation { get; set; }
        public string EmotionIcon { get; set; } = "fear.png";
        public int ImageID { get; set; } = 3;
        public int EmotionScore { get; set; }
        public int PositiveAffectBalance { get; set; }
        public int NegativeAffectBalance { get; set; }
        public string Date { get; set; } = DateTime.Now.ToString();
    }
}