﻿using AwesomeApp.Models;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AwesomeApp.Data
{
    public class MoodItemDatabase
    {
        static SQLiteAsyncConnection Database;

        public static readonly AsyncLazy<MoodItemDatabase> Instance = new AsyncLazy<MoodItemDatabase>(async () =>
        {
            var instance = new MoodItemDatabase();
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

        public Task<List<MoodItem>> GetItemsNotDoneAsync()
        {
            return Database.QueryAsync<MoodItem>("SELECT * FROM [MoodItem]");
        }

        public Task<MoodItem> GetItemAsync(int id)
        {
            return Database.Table<MoodItem>()
                .Where(i => i.ID == id)
                .FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(MoodItem item)
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

        public Task<int> DeleteItemAsync(MoodItem item)
        {
            return Database.DeleteAsync(item);
        }
    }
}
