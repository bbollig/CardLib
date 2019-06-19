using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CardLib.Tests
{
    [TestClass]
    public class TestCards
    {
        [TestMethod]
        public void TestAdd()
        {
            Cards cardList = new Cards();
            Card kingOfSpades = new Card(Suit.Spade, Rank.King);

            Assert.AreEqual(cardList.Count, 0);

            cardList.Add(kingOfSpades);

            Assert.AreNotEqual(cardList.Count, 0);
            Assert.AreEqual(cardList.Count, 1);

            Assert.IsTrue(cardList[0].Equals(kingOfSpades));
            Assert.AreEqual<Card>(kingOfSpades, cardList[0]);
        }
    }
}
