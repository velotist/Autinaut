using System;

namespace Autinaut.Database;

public interface IDatabaseItem
{
    int Id { get; set; }
    DateTime Date { get; set; }
}
