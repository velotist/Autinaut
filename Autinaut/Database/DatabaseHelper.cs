using System.Collections.Generic;
using System.Threading.Tasks;
using Autinaut.ViewModels;
using SQLite;
using Xamarin.Forms;

namespace Autinaut.Database;

public class DatabaseHelper
{
    private readonly SQLiteAsyncConnection _database;

    public DatabaseHelper()
    {
        _database = DependencyService.Get<IDatabaseConnection>().DbConnection();
        // Executes a "create table if not exists" on the database.
        _database.CreateTableAsync<SuccessItemViewModel>().Wait();
        _database.CreateTableAsync<EmotionItemViewModel>().Wait();
    }
    
    public Task<List<T>> GetItemsAsync<T>() where T : class, new()
    {
        return _database.Table<T>().ToListAsync();
    }

    public Task<T> GetItemAsync<T>(int id) where T : IDatabaseItem, new()
    {
        return _database.Table<T>()
            .Where(i => i.Id == id)
            .FirstOrDefaultAsync();
    }

    public Task<int> SaveItemAsync<T>(T item) where T : IDatabaseItem
    {
        return item.Id != 0 ? _database.UpdateAsync(item) : _database.InsertAsync(item);
    }

    public Task<int> DeleteItemAsync<T>(T item) where T : IDatabaseItem
    {
        return _database.DeleteAsync(item);
    }
}
