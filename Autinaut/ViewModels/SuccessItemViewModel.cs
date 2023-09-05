using System;
using Autinaut.Database;
using SQLite;

namespace Autinaut.ViewModels;

public class SuccessItemViewModel : IDatabaseItem
{
    [PrimaryKey] [AutoIncrement] public int Id { get; set; }
    public DateTime Date { get; set; } = DateTime.Now;
    public string SuccessNote { get; set; }
}