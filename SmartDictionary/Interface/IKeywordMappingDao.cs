// Copyright © Qiang Huang, All rights reserved.

using System.Collections.Generic;
using System.Threading.Tasks;
using SmartDictionary.Entity;

namespace SmartDictionary.Interface
{
    public interface IKeywordMappingDao
    {
        Task<int> DeleteById(long id);

        Task<int> SaveAsync(KeywordMappingBase keywordMapping);

        Task<int> SaveMultipleAsync(IEnumerable<KeywordMappingBase> keywordMappings);

        Task<IEnumerable<CommonMapping>> SearchByKeywordsAsync(IEnumerable<CommonMapping> keywords);
    }
}