// Copyright © Qiang Huang, All rights reserved.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmartDictionary.Common;
using SmartDictionary.DataAccess.Persistence;
using SmartDictionary.Entity;

namespace SmartDictionary.Core
{
    public sealed class CoreService
    {
        public static async Task SaveSentence(string sentence)
        {
            var sentenceId = await SentenceDao.SaveAsync(
                new Sentence
                {
                    CreatedTime = DateTime.Now,
                    Key = sentence,
                    LastUsedTime = DateTime.Now
                });

            var toSaves = ParticipleProcessor.ParticipleSentence(sentence, sentenceId, 3);
            await CommonKeywordMappingDao.SaveAsync(toSaves);
        }

        public static async Task<IEnumerable<Sentence>> SearchBySentence(string sentence, int level)
        {
            var dictionary = Helper.GetDistinctCount(sentence.Split(' '));
            // remove longer keyword
            PreProcessOnDictionary(ref dictionary, level);
            var searchMappings = dictionary.Select(pair => new CommonMapping
            {
                Count = pair.Value,
                Key = pair.Key
            });

            // get keyword mapping result
            var allResult = await CommonKeywordMappingDao.SearchKeywordMappingsAsync(searchMappings);
            var allMappings = new List<CommonMapping>();
            foreach (var tableResult in allResult)
            {
                allMappings.AddRange(tableResult);
            }

            // filter all sentence ids that do not contain all keywords.
            var firstFilter = allMappings.Select(mapping => mapping.Id).Distinct().ToList();
            var secondFilter = new List<long>();
            firstFilter.ForEach(id =>
            {
                if (allMappings.Count(mapping => mapping.Id == id) == dictionary.Count)
                {
                    secondFilter.Add(id);
                }
            });

            var sentences = await SentenceDao.GetByIdsAsync(secondFilter);

            // sentence need to contain all longer keywords.
            var longerKeywords = dictionary.Where(pair => pair.Key.Length > level).ToList();
            return sentences.Where(s =>
            {
                var notContained = false;
                foreach (var longerKeyword in longerKeywords)
                {
                    notContained = !s.Key.Contains(longerKeyword.Key);
                }
                return !notContained;
            });
        }

        private static void PreProcessOnDictionary(ref IDictionary<string, int> dictionary, int level)
        {
            var longerKeywords = dictionary.Where(pair => pair.Key.Length > level).ToList();
            foreach (var longerKeyword in longerKeywords)
            {
                // delete longger key
                dictionary.Remove(longerKeyword.Key);
                var shortKeys = Helper.BreakLongWordsToShort(longerKeyword.Key, level);
                foreach (var shortKey in shortKeys)
                {
                    dictionary.Add(shortKey, longerKeyword.Value);
                }
            }
        }
    }
}