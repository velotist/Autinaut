using System.IO;
using Autinaut.Database;
using SQLite;
using Xamarin.Forms;

[assembly: Dependency(typeof(DatabaseConnection))]

namespace Autinaut.Database;

public class DatabaseConnection : IDatabaseConnection
{
    public SQLiteAsyncConnection DbConnection()
    {
        const string dbName = "Autinaut.db3";
        var path = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData), dbName);
        
        return new SQLiteAsyncConnection(path);
    }
}