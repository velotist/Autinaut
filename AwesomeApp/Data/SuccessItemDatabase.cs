using AwesomeApp.Models;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AwesomeApp.Data
{
    public class SuccessItemDatabase
    {
        static SQLiteAsyncConnection Database;

        public static readonly AsyncLazy<SuccessItemDatabase> Instance = new AsyncLazy<SuccessItemDatabase>(async () =>
        {
            var instance = new SuccessItemDatabase();
            CreateTableResult result = await Database.CreateTableAsync<SuccessItem>();

            return instance;
        });

        public SuccessItemDatabase()
        {
            Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        }

        public Task<List<SuccessItem>> GetItemsAsync()
        {
            return Database.Table<SuccessItem>().ToListAsync();
        }

        public Task<SuccessItem> GetItemAsync(int id)
        {
            return Database.Table<SuccessItem>()
                .Where(i => i.ID == id)
                .FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(SuccessItem item)
        {
            if (item.ID != 0)
            {
                return Database.UpdateAsync(item);
            }
            else
            {
                return Database.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(SuccessItem item)
        {
            return Database.DeleteAsync(item);
        }
    }
}
