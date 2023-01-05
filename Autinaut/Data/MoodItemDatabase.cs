using Autinaut.Models;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Autinaut.Data
{
    public class MoodItemDatabase
    {
        private static SQLiteAsyncConnection Database;

        public static readonly AsyncLazy<MoodItemDatabase> Instance = new AsyncLazy<MoodItemDatabase>(async () =>
        {
            MoodItemDatabase instance = new MoodItemDatabase();
            CreateTableResult result = await Database.CreateTableAsync<MoodItem>();

            return instance;
        });

        public MoodItemDatabase()
        {
            Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        }

        public Task<List<MoodItem>> GetItemsAsync()
        {
            return Database.Table<MoodItem>().ToListAsync();
        }

        public Task<MoodItem> GetItemAsync(int id)
        {
            return Database.Table<MoodItem>()
                .Where(i => i.ID == id)
                .FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(MoodItem item)
        {
            return item.ID != 0 ? Database.UpdateAsync(item) : Database.InsertAsync(item);
        }

        public Task<int> DeleteItemAsync(MoodItem item)
        {
            return Database.DeleteAsync(item);
        }
    }
}
