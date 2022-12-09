using SQLite;
using System;

namespace AwesomeApp.Models
{
    public class SuccessItem
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string SuccessNote { get; set; }
        public string Date { get; set; } = DateTime.Now.ToString();
    }
}
