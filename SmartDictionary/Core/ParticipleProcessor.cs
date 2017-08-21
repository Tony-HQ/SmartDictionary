// Copyright © Qiang Huang, All rights reserved.

using System;
using System.Collections.Generic;
using System.Linq;
using SmartDictionary.Common;
using SmartDictionary.Entity;
using SmartDictionary.Properties;

namespace SmartDictionary.Core
{
    public class ParticipleProcessor
    {
        public static IEnumerable<KeywordMappingBase> ParticipleSentence(string sentence, long id)
        {
            if (string.IsNullOrEmpty(sentence))
            {
                throw new ArgumentException(string.Format(Resources.ParticipleProcessor_ParticipleSentence__0__is_empty_or_null, nameof(sentence)), nameof(sentence));
            }

            var holder = new List<KeywordMappingBase>();
            var oneChar = sentence.ToCharArray().Select(_ => _.ToString().ToLowerInvariant()).ToList();

            // one
            var oneDist = GetDistinctCount(oneChar);
            oneDist.ToList().ForEach(pair => holder.Add(Helper.GetKeywordMappingInstance(pair.Key, id, pair.Value)));

            // two
            if (oneChar.Count == 1) return holder;
            var twoChars = CombineCharsToWords(oneChar, 2);
            var twoDist = GetDistinctCount(twoChars);
            twoDist.ToList().ForEach(pair => holder.Add(Helper.GetKeywordMappingInstance(pair.Key, id, pair.Value)));

            // three
            if (oneChar.Count == 2) return holder;
            var threeChars = CombineCharsToWords(oneChar, 3);
            var threeDist = GetDistinctCount(threeChars);
            threeDist.ToList().ForEach(pair => holder.Add(Helper.GetKeywordMappingInstance(pair.Key, id, pair.Value)));

            return holder;
        }

        private static IReadOnlyDictionary<string, int> GetDistinctCount(IEnumerable<string> dumplicatedWords)
        {
            var workingDict = new Dictionary<string, int>();
            foreach (var word in dumplicatedWords)
            {
                if (workingDict.ContainsKey(word))
                {
                    workingDict[word] += 1;
                }
                else
                {
                    workingDict.Add(word, 1);
                }
            }
            return workingDict;
        }

        private static IEnumerable<string> CombineCharsToWords(IEnumerable<string> chars, int number)
        {
            var dumplicatedStrs = new List<string>();
            var enumerable = chars as string[] ?? chars.ToArray();
            for (var i = 0; i < enumerable.Length; i++)
            {
                var word = string.Empty;
                // until the end.
                if (i + number > enumerable.Length) break;
                for (var j = 0; j < number; j++)
                {
                    word += enumerable[i + j];
                }
                dumplicatedStrs.Add(word);
            }
            return dumplicatedStrs;
        }
    }
}