﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Autinaut.Common;
using Autinaut.ViewModels;
using SQLite;

namespace Autinaut.Models
{
    public class SuccessItemDatabase : ISuccessItemDatabase
    {
        private static readonly SQLiteAsyncConnection Database =
            new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);

        public static readonly AsyncLazy<SuccessItemDatabase> Instance = new AsyncLazy<SuccessItemDatabase>(async () =>
        {
            var instance = new SuccessItemDatabase();
            await Database.CreateTableAsync<SuccessItemViewModel>();

            return instance;
        });

        public Task<List<SuccessItemViewModel>> GetItemsAsync()
        {
            var successes = Database.Table<SuccessItemViewModel>()
                .OrderByDescending(p => p.Date)
                .ToListAsync();

            return successes;
        }

        public Task<SuccessItemViewModel> GetItemAsync(int id)
        {
            return Database.Table<SuccessItemViewModel>()
                .Where(i => i.Id == id)
                .FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(SuccessItemViewModel item)
        {
            return item.Id != 0 ? Database.UpdateAsync(item) : Database.InsertAsync(item);
        }

        public Task<int> DeleteItemAsync(SuccessItemViewModel item)
        {
            return Database.DeleteAsync(item);
        }
    }
}