// Copyright © Qiang Huang, All rights reserved.

using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartDictionary.Core;
using SmartDictionary.DataAccess.Persistence;

namespace SmartDiction.UnitTests
{
    [TestClass]
    public sealed class CoreTests
    {
        [TestInitialize]
        public async Task SetUp()
        {
            await DataSource.DropAllTables();
            await DataSource.Init();
        }

        [TestMethod]
        public async Task TestWordBreker()
        {
            await CoreService.SaveSentence("Helloword", 3);
            await CoreService.SaveSentence("Hel word", 3);
            await CoreService.SaveSentence("Hel", 3);

            var searchResults = (await CoreService.SearchBySentence("hel word", 3).ConfigureAwait(false)).ToList();
            Assert.IsNotNull(searchResults.FirstOrDefault(i => i.Key == "Helloword"));
            Assert.IsNotNull(searchResults.FirstOrDefault(i => i.Key == "Hel word"));
            Assert.IsNull(searchResults.FirstOrDefault(i => i.Key == "Hel"));

            var searchResults2 = (await CoreService.SearchBySentence("hel", 3).ConfigureAwait(false)).ToList();
            Assert.IsNotNull(searchResults2.FirstOrDefault(i => i.Key == "Helloword"));
            Assert.IsNotNull(searchResults2.FirstOrDefault(i => i.Key == "Hel word"));
            Assert.IsNotNull(searchResults2.FirstOrDefault(i => i.Key == "Hel"));
        }
    }
}