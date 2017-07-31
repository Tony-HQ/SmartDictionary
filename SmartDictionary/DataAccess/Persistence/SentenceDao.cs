// Copyright © Qiang Huang, All rights reserved.

using System;
using System.Threading.Tasks;
using SmartDictionary.Entity;
using SQLite;

namespace SmartDictionary.DataAccess.Persistence
{
    public static class SentenceDao
    {
        public static Task<int> DeleteAsync(long id)
        {
            return DataSource.GetConnection().DeleteAsync(new Sentence
            {
                Id = id
            });
        }

        public static Task<Sentence> GetByKeyAsync(string key)
        {
            var query = DataSource.GetConnection().Table<Sentence>().Where(sentence => sentence.Key.Equals(key));
            return query.FirstAsync();
        }

        public static Task<int> SaveAsync(Sentence sentence)
        {
            return DataSource.GetConnection().InsertAsync(sentence);
        }

        public static Task<int> UpdateLastUsedTimeAsync(long id)
        {
            return DataSource.GetConnection().UpdateAsync(new Sentence
            {
                Id = id,
                LastUsedTime = DateTime.Now
            });
        }
    }
}