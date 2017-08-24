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
        public static IEnumerable<KeywordMappingBase> ParticipleSentence(string sentence, long id, int level)
        {
            if (string.IsNullOrEmpty(sentence))
            {
                throw new ArgumentException(
                    string.Format(Resources.ParticipleProcessor_ParticipleSentence__0__is_empty_or_null,
                        nameof(sentence)), nameof(sentence));
            }

            var holder = new List<KeywordMappingBase>();
            var oneChar = sentence.ToCharArray().Select(_ => _.ToString().ToLowerInvariant()).ToList();

            // one
            var oneDist = Helper.GetDistinctCount(oneChar);
            oneDist.ToList().ForEach(pair => holder.Add(Helper.GetKeywordMappingInstance(pair.Key, id, pair.Value)));

            for (var i = 2; i <= level; i++)
            {
                CombineAndAddToHolder(oneChar, id, i, ref holder);
            }
            return holder;
        }

        private static void CombineAndAddToHolder(IEnumerable<string> oneChar, long id, int level,
            ref List<KeywordMappingBase> holder)
        {
            var enumerable = oneChar as IList<string> ?? oneChar.ToList();
            if (enumerable.Count < level) return;
            var chars = CombineCharsToWords(enumerable, level);
            var dist = Helper.GetDistinctCount(chars);
            holder.AddRange(dist.Select(pair => Helper.GetKeywordMappingInstance(pair.Key, id, pair.Value)));
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