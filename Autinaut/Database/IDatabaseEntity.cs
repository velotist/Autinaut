using System;

namespace Autinaut.Database;

public interface IDatabaseEntity
{
    int Id { get; }
    DateTime Date { get; }
}