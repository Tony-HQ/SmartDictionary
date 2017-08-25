// Copyright © Qiang Huang, All rights reserved.

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartDictionary.Common;
using SmartDictionary.DataAccess.Persistence;
using SmartDictionary.Entity;

namespace SmartDiction.UnitTests
{
    [TestClass]
    public sealed class DataAccessTests
    {
        [TestInitialize]
        public async Task SetUp()
        {
            await DataSource.DropAllTables();
            await DataSource.Init();
        }

        [TestMethod]
        public async Task TestKeywordMapping()
        {
            await CommonKeywordMappingDao.SaveAsync(new List<KeywordMappingBase>
            {
                Helper.GetKeywordMappingInstance(Today, 1, 1),
                Helper.GetKeywordMappingInstance(Tommorow, 2, 1)
            });

            var result = await CommonKeywordMappingDao.SearchKeywordMappingsAsync(new List<CommonMapping>
            {
                new CommonMapping {Count = 1, Key = Today},
                new CommonMapping {Count = 1, Key = Tommorow}
            });
            Assert.AreEqual(result.Length, 2);
            var mapping = result.FirstOrDefault();
            Assert.IsNotNull(mapping);
            var commonMappings = mapping as IList<CommonMapping> ?? mapping.ToList();
            Assert.AreEqual(1, commonMappings.Count);
            Assert.AreEqual(1, commonMappings.FirstOrDefault()?.Id);
        }

        [TestMethod]
        public async Task TestKeywordMappingCountSmallThan()
        {
            await CommonKeywordMappingDao.SaveAsync(new List<KeywordMappingBase>
            {
                Helper.GetKeywordMappingInstance(Today, 1, 1),
                Helper.GetKeywordMappingInstance(Tommorow, 2, 1)
            });

            var result = await CommonKeywordMappingDao.SearchKeywordMappingsAsync(new List<CommonMapping>
            {
                new CommonMapping {Count = 2, Key = Today},
                new CommonMapping {Count = 1, Key = Tommorow}
            });
            Assert.AreEqual(2, result.Length);
            var mapping = result.FirstOrDefault(i => !i.Any());
            Assert.IsNotNull(mapping);
            var commonMappings = mapping as IList<CommonMapping> ?? mapping.ToList();
            Assert.AreEqual(0, commonMappings.Count);
        }

        [TestMethod]
        public async Task TestKeywordMappingDelete()
        {
            await CommonKeywordMappingDao.SaveAsync(new List<KeywordMappingBase>
            {
                Helper.GetKeywordMappingInstance(Today, 1, 1),
                Helper.GetKeywordMappingInstance(Tommorow, 2, 1)
            });

            var result = await CommonKeywordMappingDao.SearchKeywordMappingsAsync(new List<CommonMapping>
            {
                new CommonMapping {Count = 1, Key = Today},
                new CommonMapping {Count = 1, Key = Tommorow}
            });
            Assert.AreEqual(result.Length, 2);

            await CommonKeywordMappingDao.DeleteAsync(1);
            await CommonKeywordMappingDao.DeleteAsync(2);

            var result2 = await CommonKeywordMappingDao.SearchKeywordMappingsAsync(new List<CommonMapping>
            {
                new CommonMapping {Count = 1, Key = Today},
                new CommonMapping {Count = 1, Key = Tommorow}
            });
            Assert.AreEqual(result.Length, 2);
            Assert.AreEqual(true, result2.All(i => !i.Any()));
        }

        private const string Today = "today";
        private const string Tommorow = "Tommorow";
    }
}