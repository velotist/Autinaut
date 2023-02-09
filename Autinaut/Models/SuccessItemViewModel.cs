﻿using SQLite;
using System;

namespace Autinaut.Models
{
    public class SuccessItemViewModel
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public string SuccessNote { get; set; }
        public string Date { get; set; } = DateTime.Now.ToString();
    }
}