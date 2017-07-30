using SmartDictionary.Entity;
using SQLite;
using System;
using System.IO;
using System.Threading.Tasks;

namespace SmartDictionary.DataAccess.Persistence
{
    /// <summary>
    /// Data Source of Sqlite.
    /// </summary>
    public static class DataSource
    {
        public static SQLiteAsyncConnection GetConnection()
        {
            // ReSharper disable once InvertIf
            if (_sqliteAsyncConnection == null)
            {
                lock (Lock)
                {
                    if (_sqliteAsyncConnection == null)
                        _sqliteAsyncConnection = new SQLiteAsyncConnection(Path);
                }
            }
            return _sqliteAsyncConnection;
        }

        public static async Task<CreateTablesResult> Init()
        {
            var conn = GetConnection();
            return await conn.CreateTableAsync<Sentence>().ConfigureAwait(false);
        }

        public static async Task DeleteAll()
        {
            var conn = GetConnection();
            await conn.DropTableAsync<Sentence>().ConfigureAwait(false);
        }

        private static readonly object Lock = new object();
        private static SQLiteAsyncConnection _sqliteAsyncConnection;
        private static readonly string Path = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "smartdict.sqlite");
    }
}
