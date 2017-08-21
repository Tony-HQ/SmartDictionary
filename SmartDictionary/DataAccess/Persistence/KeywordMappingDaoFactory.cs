// Copyright © Qiang Huang, All rights reserved.

using System.Collections.Concurrent;
using SmartDictionary.Entity;
using SmartDictionary.Interface;

namespace SmartDictionary.DataAccess.Persistence
{
    public static class KeywordMappingDaoFactory
    {
        public static IKeywordMappingDao GetKeywordMappingDao(int key)
        {
            return Dictionary.GetOrAdd(key, CreateKeywordMappingDao);
        }

        private static IKeywordMappingDao CreateKeywordMappingDao(int key)
        {
            switch (key)
            {
                case 1: return new OneTwoMappingDao();
                case 2: return new OneTwoMappingDao();
                case 3: return new ThreeMappingDao();
                case 4: return new FourMappingDao();
                case 5: return new FiveMappingDao();
                case 6: return new SixMappingDao();
                case 7: return new SevenMappingDao();
                case 8: return new EightMappingDao();
                case 9: return new NineMappingDao();
                case 10: return new TenMappingDao();
                default: return new MoreThanTenMappingDao();
            }
        }

        private static readonly ConcurrentDictionary<int, IKeywordMappingDao> Dictionary
            = new ConcurrentDictionary<int, IKeywordMappingDao>();
    }

    public class OneTwoMappingDao : KeywordMappingDao<OneTwoMapping>
    {
    }

    public class ThreeMappingDao : KeywordMappingDao<ThreeMapping>
    {
    }

    public class FourMappingDao : KeywordMappingDao<FourMapping>
    {
    }

    public class FiveMappingDao : KeywordMappingDao<FiveMapping>
    {
    }

    public class SixMappingDao : KeywordMappingDao<SixMapping>
    {
    }

    public class SevenMappingDao : KeywordMappingDao<SevenMapping>
    {
    }

    public class EightMappingDao : KeywordMappingDao<EightMapping>
    {
    }

    public class NineMappingDao : KeywordMappingDao<NineMapping>
    {
    }

    public class TenMappingDao : KeywordMappingDao<TenMapping>
    {
    }

    public class MoreThanTenMappingDao : KeywordMappingDao<MoreThanTenMapping>
    {
    }
}