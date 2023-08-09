using Autinaut.Common;
using Autinaut.ViewModels;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Autinaut.Models
{
    public class SuccessItemDatabase
    {
        private static readonly SQLiteAsyncConnection Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);

        public static readonly AsyncLazy<SuccessItemDatabase> Instance = new AsyncLazy<SuccessItemDatabase>(async () =>
        {
            SuccessItemDatabase instance = new SuccessItemDatabase();
            await Database.CreateTableAsync<SuccessItemViewModel>();

            return instance;
        });

        public Task<List<SuccessItemViewModel>> GetItemsAsync()
        {
            Task<List<SuccessItemViewModel>> successes = Database.Table<SuccessItemViewModel>()
                .OrderByDescending(p => p.Date)
                .ToListAsync();

            return successes;
        }

        public Task<SuccessItemViewModel> GetItemAsync(int id)
        {
            return Database.Table<SuccessItemViewModel>()
                .Where(i => i.ID == id)
                .FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(SuccessItemViewModel item)
        {
            return item.ID != 0 ? Database.UpdateAsync(item) : Database.InsertAsync(item);
        }

        public Task<int> DeleteItemAsync(SuccessItemViewModel item)
        {
            return Database.DeleteAsync(item);
        }
    }
}