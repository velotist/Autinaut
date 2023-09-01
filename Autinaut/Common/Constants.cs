using System;
using System.IO;
using SQLite;

namespace Autinaut.Common
{
    public static class Constants
    {
        public const string DatabaseFilename = "Autinaut.db3";

        public const SQLiteOpenFlags Flags =
            SQLiteOpenFlags.ReadWrite |
            SQLiteOpenFlags.Create |
            SQLiteOpenFlags.SharedCache;

        public static string DatabasePath
        {
            get
            {
                var basePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

                return Path.Combine(basePath, DatabaseFilename);
            }
        }
    }
}