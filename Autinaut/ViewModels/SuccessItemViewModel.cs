using SQLite;
using System;

namespace Autinaut.ViewModels
{
    public class SuccessItemViewModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string SuccessNote { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
    }
}