using SQLite;
using System;

namespace Autinaut.Models
{
    public class MoodItem
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Mood { get; set; } = "Anger";
        public string MoodSituation { get; set; }
        public string MoodIcon { get; set; } = "anger.png";
        public double PositiveAffectBalance { get; set; }
        public double NegativeAffectBalance { get; set; }
        public string Date { get; set; } = DateTime.Now.ToString();
    }
}