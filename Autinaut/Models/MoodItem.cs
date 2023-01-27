using SQLite;
using System;

namespace Autinaut.Models
{
    public class MoodItem
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Mood { get; set; } = "Angst";
        public string MoodSituation { get; set; }
        public string MoodIcon { get; set; } = "fear.png";
        public int ImageID { get; set; } = 3;
        public int MoodScore { get; set; }
        public int PositiveAffectBalance { get; set; }
        public int NegativeAffectBalance { get; set; }
        public string Date { get; set; } = DateTime.Now.ToString();
    }
}