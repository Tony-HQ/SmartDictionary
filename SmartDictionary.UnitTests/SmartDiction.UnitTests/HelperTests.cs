// Copyright © Qiang Huang, All rights reserved.

using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartDictionary.Common;

namespace SmartDiction.UnitTests
{
    [TestClass]
    public sealed class HelperTests
    {
        [TestMethod]
        public void TestWordBreker()
        {
            var result = Helper.BreakLongWordsToShort("Helloword", 3).ToList();
            Assert.AreEqual(4, result.Count());
            Assert.AreEqual("Hel", result.FirstOrDefault());
            Assert.AreEqual("ord", result.LastOrDefault());
        }
    }
}