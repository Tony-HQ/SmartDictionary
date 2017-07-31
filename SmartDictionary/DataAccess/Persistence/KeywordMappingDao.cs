// Copyright © Qiang Huang, All rights reserved.

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmartDictionary.Entity;

namespace SmartDictionary.DataAccess.Persistence
{
    public static class KeywordMappingDao<T> where T : KeywordMappingBase, new()
    {
        public static Task<int> DeleteById(long id)
        {
            return DataSource.GetConnection().DeleteAsync(new T
            {
                Id = id
            });
        }

        public static Task<int> SaveAsync(T keywordMapping)
        {
            return DataSource.GetConnection().InsertAsync(keywordMapping);
        }

        public static Task<int> SaveMultipleAsync(IEnumerable<T> keywordMappings)
        {
            return DataSource.GetConnection().InsertAllAsync(keywordMappings);
        }

        public static Task<List<T>> SearchByKeywordsAsync(IEnumerable<string> keywords)
        {
            return DataSource.GetConnection().Table<T>()
                .Where(_ => keywords.Contains(_.Key))
                .ToListAsync();
        }
    }
}