using SQLite;
using System;

namespace Autinaut.ViewModels
{
    public class ItemViewModel : IItemViewModel
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public string Note { get; set; }
        public string Date { get; set; } = DateTime.Now.ToString();
    }
}