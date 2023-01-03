﻿using SQLite;
using System;

namespace Autinaut.Models
{
    public class MoodItem
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Mood { get; set; }
        public string MoodSituation { get; set; }
        public string MoodIcon { get; set; }
        public string Date { get; set; } = DateTime.Now.ToString();
    }
}