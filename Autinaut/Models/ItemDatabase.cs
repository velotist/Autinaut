using Autinaut.Common;
using Autinaut.ViewModels;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Autinaut.Models
{
    public sealed class ItemDatabase<T> where T : ItemViewModel, new()
    {
        private readonly SQLiteAsyncConnection _database;

        public ItemDatabase()
        {
            _database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
            _database.CreateTableAsync<T>().Wait();
        }

        public async Task<List<T>> GetItemsAsync()
        {
            return await _database.Table<T>()
                .OrderByDescending(p => p.Date)
                .ToListAsync();
        }

        public Task<T> GetItemAsync(int id)
        {
            return _database.Table<T>()
                .Where(i => i.ID == id)
                .FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(T item)
        {
            return item.ID != 0 ? _database.UpdateAsync(item) : _database.InsertAsync(item);
        }

        public Task<int> DeleteItemAsync(T item)
        {
            return _database.DeleteAsync(item);
        }
    }
}