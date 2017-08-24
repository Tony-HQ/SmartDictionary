// Copyright © Qiang Huang, All rights reserved.

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmartDictionary.Entity;
using SmartDictionary.Interface;

namespace SmartDictionary.DataAccess.Persistence
{
    public abstract class KeywordMappingDao<T> : IKeywordMappingDao where T : CommonMapping, new()
    {
        public Task<int> DeleteById(long id)
        {
            return DataSource.GetConnection().ExecuteAsync($"delete from {typeof(T).Name} where id = {id}");
        }

        public Task<int> SaveAsync(KeywordMappingBase keywordMapping)
        {
            return DataSource.GetConnection().InsertAsync(keywordMapping);
        }

        public Task<int> SaveMultipleAsync(IEnumerable<KeywordMappingBase> keywordMappings)
        {
            return DataSource.GetConnection().InsertAllAsync(keywordMappings);
        }

        public async Task<IEnumerable<CommonMapping>> SearchByKeywordsAsync(IEnumerable<CommonMapping> keywords)
        {
            var enumerable = keywords as IList<CommonMapping> ?? keywords.ToList();
            var result = await DataSource.GetConnection()
                .QueryAsync<T>($"select * from {typeof(T).Name} where {SearchQueryMaker(enumerable)}");
            return
                result.Select(i => new CommonMapping { Id = i.Id, Key = i.Key });
        }

        private static string OneCondition(string key, int count)
        {
            return $"(key = \"{key}\" and count >= {count})";
        }

        private static string SearchQueryMaker(IEnumerable<CommonMapping> keywords)
        {
            var result = string.Empty;
            var commonMappings = keywords as List<CommonMapping> ?? keywords.ToList();
            for (var i = 0; i < commonMappings.Count(); i++)
            {
                result += OneCondition(commonMappings[i].Key, commonMappings[i].Count);
                if (i != commonMappings.Count - 1)
                {
                    result += " or ";
                }
            }
            return result;
        }
    }
}