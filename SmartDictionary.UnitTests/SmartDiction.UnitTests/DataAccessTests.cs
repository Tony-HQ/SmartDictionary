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
                Helper.GetKeywordMappingInstance(Today, 1,1),
                Helper.GetKeywordMappingInstance(Tommorow, 2,1)
            });

            var result = await CommonKeywordMappingDao.SearchKeywordMappingsAsync(new List<string> { Today });
            Assert.AreEqual(result.Length, 1);
            var mapping = result.FirstOrDefault();
            Assert.IsNotNull(mapping);
            var commonMappings = mapping as IList<CommonMapping> ?? mapping.ToList();
            Assert.AreEqual(1, commonMappings.Count);
            Assert.AreEqual(1, commonMappings.FirstOrDefault()?.Id);
        }

        private const string Today = "today";
        private const string Tommorow = "Tommorow";
    }
}