// Copyright © Qiang Huang, All rights reserved.

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmartDictionary.Entity;

namespace SmartDictionary.DataAccess.Persistence
{
    public static class CommonKeywordMappingDao
    {
        public static async Task DeleteAsync(long id)
        {
            // 1,2 & >10
            var tasks = new List<Task> {GetDeleteTask(id, 1), GetDeleteTask(id, 1000)};
            // length in [3,10]
            From3To10.ForEach(
                length =>
                    GetDeleteTask(id, length)
            );
            await Task.WhenAll(tasks);
        }

        public static async Task SaveAsync(IEnumerable<KeywordMappingBase> keywords)
        {
            var enumerable = keywords as KeywordMappingBase[] ?? keywords.ToArray();

            var tasks = new List<Task<int>>();

            // length == 1 || length == 2
            var lessThanTwoWords = enumerable.Where(_ => _.Key.Length < 2 && _.Key.Length > 0).ToList();
            if (lessThanTwoWords.Any())
                tasks.Add(GetSaveTask(lessThanTwoWords, 1));

            // length in [3,10]
            From3To10.ForEach(
                length =>
                {
                    var toSearch = enumerable.Where(_ => _.Key.Length == length).ToList();
                    if (toSearch.Any())
                        tasks.Add(GetSaveTask(toSearch, length));
                }
            );

            var moreThanTen = enumerable.Where(_ => _.Key.Length > 10).ToList();
            // length > 10
            if (moreThanTen.Any())
                tasks.Add(GetSaveTask(moreThanTen, 1000));
            await Task.WhenAll(tasks);
        }

        public static async Task<IEnumerable<CommonMapping>[]> SearchKeywordMappingsAsync(IEnumerable<string> keywords)
        {
            var enumerable = keywords as string[] ?? keywords.ToArray();

            var tasks = new List<Task<IEnumerable<CommonMapping>>>();

            // length == 1 || length == 2
            var lessThanTwoWords = enumerable.Where(_ => _.Length < 2 && _.Length > 0).ToList();
            if (lessThanTwoWords.Any())
                tasks.Add(GetSearchTask(lessThanTwoWords, 1));

            // length in [3,10]
            From3To10.ForEach(
                length =>
                {
                    var toSearch = enumerable.Where(_ => _.Length == length).ToList();
                    if (toSearch.Any())
                        tasks.Add(GetSearchTask(toSearch, length));
                }
            );

            // length > 10
            var moreThanTen = enumerable.Where(_ => _.Length > 10).ToList();
            if (moreThanTen.Any())
                tasks.Add(GetSearchTask(moreThanTen, 1000));
            return await Task.WhenAll(tasks);
        }

        private static Task<int> GetDeleteTask(long id, int length)
        {
            return KeywordMappingDaoFactory.GetKeywordMappingDao(length).DeleteById(id);
        }

        private static Task<int> GetSaveTask(IEnumerable<KeywordMappingBase> toSave, int length)
        {
            return KeywordMappingDaoFactory.GetKeywordMappingDao(length)
                .SaveMultipleAsync(toSave);
        }

        private static Task<IEnumerable<CommonMapping>> GetSearchTask(IEnumerable<string> toSearch, int length)
        {
            var enumerable = toSearch as string[] ?? toSearch.ToArray();
            return enumerable.Any()
                ? KeywordMappingDaoFactory.GetKeywordMappingDao(length)
                    .SearchByKeywordsAsync(enumerable)
                : null;
        }

        private static readonly List<int> From3To10 = new List<int> {3, 4, 5, 6, 7, 8, 9, 10};
    }
}