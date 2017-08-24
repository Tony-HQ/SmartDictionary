// Copyright © Qiang Huang, All rights reserved.

using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartDictionary.Core;

namespace SmartDiction.UnitTests
{
    [TestClass]
    public sealed class ParticipleTests
    {
        [TestMethod]
        public void TestParticiple_CHS_Sentence()
        {
            var collection = ParticipleProcessor.ParticipleSentence(ChsSentence, 1, 3).ToList();
            Assert.AreEqual(6, collection.Count);
        }

        [TestMethod]
        public void TestParticipleComplicatedSentence()
        {
            var collection = ParticipleProcessor.ParticipleSentence(ComplicatedSentence1, 1, 3).ToList();
            Assert.AreEqual(12, collection.Count(i => i.Key.Length == 1));
            Assert.AreEqual(2, collection.FirstOrDefault(i => i.Key == "a")?.Count);
            Assert.AreEqual(2, collection.FirstOrDefault(i => i.Key == "o")?.Count);
            Assert.AreEqual(2, collection.FirstOrDefault(i => i.Key == "y")?.Count);
            Assert.AreEqual(5, collection.FirstOrDefault(i => i.Key == " ")?.Count);

            Assert.AreEqual(18, collection.Count(i => i.Key.Length == 2));
            Assert.AreEqual(2, collection.FirstOrDefault(i => i.Key == " t")?.Count);
            Assert.AreEqual(2, collection.FirstOrDefault(i => i.Key == "e ")?.Count);

            Assert.AreEqual(19, collection.Count(i => i.Key.Length == 3));
        }

        [TestMethod]
        public void TestParticipleEmpty()
        {
            Assert.ThrowsException<ArgumentException>(() => ParticipleProcessor.ParticipleSentence(string.Empty, 1, 3));
        }

        [TestMethod]
        public void TestParticipleOnechar()
        {
            var collection = ParticipleProcessor.ParticipleSentence(OnecharSentence, 1, 3).ToList();
            Assert.AreEqual(1, collection.Count);
            Assert.AreEqual("1", collection.FirstOrDefault()?.Key);
        }

        [TestMethod]
        public void TestParticipleThreeChar()
        {
            var collection = ParticipleProcessor.ParticipleSentence(ThreecharSentence, 1, 3).ToList();
            Assert.AreEqual(6, collection.Count);
            Assert.IsNotNull(collection.FirstOrDefault(i => i.Key == "23"));
            Assert.IsNotNull(collection.FirstOrDefault(i => i.Key == "12"));
            Assert.IsNotNull(collection.FirstOrDefault(i => i.Key == "123"));
        }

        [TestMethod]
        public void TestParticipleTwoChar()
        {
            var collection = ParticipleProcessor.ParticipleSentence(TwocharSentence, 1, 3).ToList();
            Assert.AreEqual(2, collection.Count);
            Assert.AreEqual(2, collection.FirstOrDefault(i => i.Key == "2")?.Count);
            Assert.IsNotNull(collection.FirstOrDefault(i => i.Key == "22"));
        }

        private const string ChsSentence = "你好测";
        private const string ComplicatedSentence1 = "one day I have to try";
        private const string OnecharSentence = "1";
        private const string ThreecharSentence = "123";
        private const string TwocharSentence = "22";
    }
}