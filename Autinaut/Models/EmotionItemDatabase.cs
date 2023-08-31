using Autinaut.Common;
using Autinaut.ViewModels;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Autinaut.Models
{
    public class EmotionItemDatabase
    {
        private static readonly SQLiteAsyncConnection Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);

        public static readonly AsyncLazy<EmotionItemDatabase> Instance = new AsyncLazy<EmotionItemDatabase>(async () =>
        {
            EmotionItemDatabase instance = new EmotionItemDatabase();
            await Database.CreateTableAsync<EmotionItemViewModel>();

            return instance;
        });

        public async Task<List<EmotionItemViewModel>> GetItemsAsync()
        {
            return await Database.Table<EmotionItemViewModel>()
                .OrderByDescending(p => p.Date)
                .ToListAsync();
        }

        public Task<EmotionItemViewModel> GetItemAsync(int id)
        {
            return Database.Table<EmotionItemViewModel>()
                .Where(i => i.Id == id)
                .FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(EmotionItemViewModel item)
        {
            return item.Id != 0 ? Database.UpdateAsync(item) : Database.InsertAsync(item);
        }

        public Task<int> DeleteItemAsync(EmotionItemViewModel item)
        {
            return Database.DeleteAsync(item);
        }
    }
}