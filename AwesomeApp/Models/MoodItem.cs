﻿using SQLite;
using System;

namespace AwesomeApp.Models
{
    public class MoodItem
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Mood { get; set; }
        public string Date { get; set; }
    }
}