using System;
using Autinaut.Database;
using SQLite;

namespace Autinaut.ViewModels;

public class SuccessItemViewModel : IDatabaseItem
{
    [PrimaryKey] [AutoIncrement] public int Id { get; set; }
    public DateTime Date { get; set; } = DateTime.Now;
    private string _successNote;
    public string SuccessNote
    {
        get => _successNote;
        set =>
            _successNote = value is { Length: > 700 } ? value.Substring(0, 700) :
                value;
    }
}