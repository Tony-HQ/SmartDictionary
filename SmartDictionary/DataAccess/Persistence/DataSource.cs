// Copyright © Qiang Huang, All rights reserved.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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

        public static SQLiteAsyncConnection GetConnection()
        {
            return new SQLiteAsyncConnection(Path);
        }

        public static async Task Init()
        {
            var tasks = new[] {
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
        
        private static readonly string Path = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "smartdict.sqlite");
    }
}