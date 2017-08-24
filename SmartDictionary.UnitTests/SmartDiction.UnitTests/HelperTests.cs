using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
