using System;
using System.IO;

namespace Autinaut
{
    public static class Constants
    {
        public const string DatabaseFilename = "Autinaut.db3";

        public const SQLite.SQLiteOpenFlags Flags =
            SQLite.SQLiteOpenFlags.ReadWrite |
            SQLite.SQLiteOpenFlags.Create |
            SQLite.SQLiteOpenFlags.SharedCache;

        public static string DatabasePath
        {
            get
            {
                string basePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

                return Path.Combine(basePath, DatabaseFilename);
            }
        }
    }
}