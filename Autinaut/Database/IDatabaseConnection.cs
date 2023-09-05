using SQLite;

namespace Autinaut.Database;

public interface IDatabaseConnection
{
    SQLiteAsyncConnection DbConnection();
}
