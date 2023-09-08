using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autinaut.Common;
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

    public async Task<List<T>> GetItemsAsync<T>(Order direction) where T : class, IDatabaseEntity, new()
    {
        var items = await _database.Table<T>().ToListAsync();

        var orderedItems = direction == Order.Descending
            ? items.OrderByDescending(item => item.Date).ToList()
            : items.OrderBy(item => item.Date).ToList();

        return orderedItems;
    }

    public Task<T> GetItemAsync<T>(int id) where T : IDatabaseEntity, new()
    {
        return _database.Table<T>()
            .Where(i => i.Id == id)
            .FirstOrDefaultAsync();
    }

    public Task<int> SaveItemAsync<T>(T item) where T : IDatabaseEntity
    {
        return item.Id != 0 ? _database.UpdateAsync(item) : _database.InsertAsync(item);
    }

    public Task<int> DeleteItemAsync<T>(T item) where T : IDatabaseEntity
    {
        return _database.DeleteAsync(item);
    }
}