// Copyright © Qiang Huang, All rights reserved.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmartDictionary.Entity;

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

        public static Task<List<Sentence>> GetByIdsAsync(IEnumerable<long> ids)
        {
            return DataSource.GetConnection().Table<Sentence>().Where(sentence => ids.Contains(sentence.Id))
                .ToListAsync();
        }

        public static Task<Sentence> GetByKeyAsync(string key)
        {
            var query = DataSource.GetConnection().Table<Sentence>().Where(sentence => sentence.Key.Equals(key));
            return query.FirstOrDefaultAsync();
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