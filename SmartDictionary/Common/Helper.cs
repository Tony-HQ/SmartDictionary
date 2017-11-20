// Copyright © Qiang Huang, All rights reserved.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Shortcut;
using SmartDictionary.Entity;

namespace SmartDictionary.Common
{
    public static class Helper
    {
        public static Modifiers ParseModifier(string key)
        {
            try
            {
                var modifier = (Modifiers)Enum.Parse(typeof(Modifiers), key);
                return modifier;
            }
            catch (Exception)
            {
                return Modifiers.None;
            }
        }

        public static Keys ParseKey(string input)
        {
            try
            {
                var key = (Keys)Enum.Parse(typeof(Keys), input);
                return key;
            }
            catch (Exception)
            {
                return Keys.None;
            }
        }

        public static IEnumerable<string> BreakLongWordsToShort(string word, int level)
        {
            var result = new List<string>();
            var count = word.Length / level;
            for (var i = 0; i < count; i++)
            {
                result.Add(word.Substring(i, level));
            }
            result.Add(word.Substring(word.Length - level, level));
            return result.Distinct();
        }

        public static ListViewItem[] ConvertSentenceToListViewItem(IEnumerable<Sentence> sentences)
        {
            return sentences.Select(_ =>
                {
                    var item = new ListViewItem(_.Id.ToString());
                    item.SubItems.Add(_.Key);
                    item.SubItems.Add(_.LastUsedTime.ToLocalTime().ToString());
                    return item;
                }
            ).ToArray();
        }

        public static IDictionary<string, int> GetDistinctCount(IEnumerable<string> dumplicatedWords)
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

        public static KeywordMappingBase GetKeywordMappingInstance(string key, long id, int count)
        {
            switch (key.Length)
            {
                case 1: return new OneTwoMapping { Key = key, Id = id, Count = count };
                case 2: return new OneTwoMapping { Key = key, Id = id, Count = count };
                case 3: return new ThreeMapping { Key = key, Id = id, Count = count };
                case 4: return new FourMapping { Key = key, Id = id, Count = count };
                case 5: return new FiveMapping { Key = key, Id = id, Count = count };
                case 6: return new SixMapping { Key = key, Id = id, Count = count };
                case 7: return new SevenMapping { Key = key, Id = id, Count = count };
                case 8: return new EightMapping { Key = key, Id = id, Count = count };
                case 9: return new NineMapping { Key = key, Id = id, Count = count };
                case 10: return new TenMapping { Key = key, Id = id, Count = count };
                default: return new MoreThanTenMapping { Key = key, Id = id, Count = count };
            }
        }
    }
}