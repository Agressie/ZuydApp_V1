using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZuydApp_V1.Data
{
    public static class Constants
    {
        private const string DBName = "ZuydWayFinderDB.db3";
        public const SQLiteOpenFlags flags = SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create | SQLiteOpenFlags.SharedCache;

        public static string DBPath
        {
            get
            {
                return Path.Combine(FileSystem.AppDataDirectory, DBName);
            }
        }
    }
}
