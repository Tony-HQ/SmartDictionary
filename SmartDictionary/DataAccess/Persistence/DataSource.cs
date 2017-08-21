// Copyright © Qiang Huang, All rights reserved.

using System.Threading.Tasks;
using SmartDictionary.Common;
using SmartDictionary.Entity;
using SQLite;

namespace SmartDictionary.DataAccess.Persistence
{
    /// <summary>
    ///     Data Source of Sqlite.
    /// </summary>
    public static class DataSource
    {
        public static async Task DeleteAll()
        {
            var conn = GetConnection();
            await conn.DropTableAsync<Sentence>().ConfigureAwait(false);
        }

        public static async Task DropAllTables()
        {
            var tasks = new[]
            {
                GetConnection().DropTableAsync<Sentence>(),
                GetConnection().DropTableAsync<OneTwoMapping>(),
                GetConnection().DropTableAsync<ThreeMapping>(),
                GetConnection().DropTableAsync<FourMapping>(),
                GetConnection().DropTableAsync<FiveMapping>(),
                GetConnection().DropTableAsync<SixMapping>(),
                GetConnection().DropTableAsync<SevenMapping>(),
                GetConnection().DropTableAsync<EightMapping>(),
                GetConnection().DropTableAsync<NineMapping>(),
                GetConnection().DropTableAsync<TenMapping>(),
                GetConnection().DropTableAsync<MoreThanTenMapping>()
            };
            await Task.WhenAll(tasks);
        }

        public static SQLiteAsyncConnection GetConnection()
        {
            return new SQLiteAsyncConnection(Path);
        }

        public static async Task Init()
        {
            var tasks = new[]
            {
                GetConnection().CreateTableAsync<Sentence>(),
                GetConnection().CreateTableAsync<OneTwoMapping>(),
                GetConnection().CreateTableAsync<ThreeMapping>(),
                GetConnection().CreateTableAsync<FourMapping>(),
                GetConnection().CreateTableAsync<FiveMapping>(),
                GetConnection().CreateTableAsync<SixMapping>(),
                GetConnection().CreateTableAsync<SevenMapping>(),
                GetConnection().CreateTableAsync<EightMapping>(),
                GetConnection().CreateTableAsync<NineMapping>(),
                GetConnection().CreateTableAsync<TenMapping>(),
                GetConnection().CreateTableAsync<MoreThanTenMapping>()
            };
            await Task.WhenAll(tasks);
        }

        private static readonly string Path = System.IO.Path.Combine(System.IO.Path.GetTempPath(), Configuration.DatabaseName());
    }
}