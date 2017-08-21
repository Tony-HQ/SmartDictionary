// Copyright © Qiang Huang, All rights reserved.

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmartDictionary.Entity;
using SmartDictionary.Interface;

namespace SmartDictionary.DataAccess.Persistence
{
    public abstract class KeywordMappingDao<T> : IKeywordMappingDao where T : KeywordMappingBase, new()
    {
        public Task<int> DeleteById(long id)
        {
            return DataSource.GetConnection().DeleteAsync(new T
            {
                Id = id
            });
        }

        public Task<int> SaveAsync(KeywordMappingBase keywordMapping)
        {
            return DataSource.GetConnection().InsertAsync(keywordMapping);
        }

        public Task<int> SaveMultipleAsync(IEnumerable<KeywordMappingBase> keywordMappings)
        {
            return DataSource.GetConnection().InsertAllAsync(keywordMappings);
        }

        public async Task<IEnumerable<CommonMapping>> SearchByKeywordsAsync(IEnumerable<string> keywords)
        {
            var result = await DataSource.GetConnection().Table<T>()
                .Where(_ => keywords.Contains(_.Key))
                .ToListAsync();
            return result.Select(i => new CommonMapping {Id = i.Id, Key = i.Key});
        }
    }
}