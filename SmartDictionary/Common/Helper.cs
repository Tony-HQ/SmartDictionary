// Copyright © Qiang Huang, All rights reserved.

using SmartDictionary.Entity;

namespace SmartDictionary.Common
{
    public static class Helper
    {
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