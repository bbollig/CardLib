using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CardLib.Tests
{
    [TestClass]
    public class TestCards
    {
        //Cards.CopyTo functionality is covered by TestShuffle in TestDeck
        //Cards.Clone functionality is covered by TestClone in TestDeck

        [TestMethod]
        public void TestAddRemove()
        {
            Cards cardList = new Cards();
            Card kingOfSpades = new Card(Suit.Spade, Rank.King);
            Card aceOfSpades = new Card(Suit.Spade, Rank.Ace);

            //Test if cardList is empty at creation
            Assert.AreEqual(cardList.Count, 0);

            cardList.Add(kingOfSpades);
            cardList.Add(aceOfSpades);

            //Test if Count adds up properly after adding two cards
            Assert.AreNotEqual(cardList.Count, 0);
            Assert.AreEqual(cardList.Count, 2);

            //Test if the first card is kingOfSpades
            Assert.AreEqual<Card>(kingOfSpades, cardList[0]);

            cardList.Remove(kingOfSpades);

            //After removing kingOfSpades, check count=1 and if aceOfSpades is now in the first position
            Assert.AreEqual(cardList.Count, 1);
            Assert.AreEqual<Card>(aceOfSpades, cardList[0]);

            cardList.RemoveAt(0);

            Assert.AreEqual(cardList.Count, 0);
        }

        [TestMethod]
        public void TestCardsEquals()
        {
            Cards setOne = new Cards();
            Cards setTwo = new Cards();
            Cards setThree = new Cards();

            Card aceOfSpades = new Card(Suit.Spade, Rank.Ace);
            Card kingOfSpades = new Card(Suit.Spade, Rank.King);
            Card queenOfSpades = new Card(Suit.Spade, Rank.Queen);
            Card jackOfSpades = new Card(Suit.Spade, Rank.Jack);
            Card tenOfSpades = new Card(Suit.Spade, Rank.Ten);

            //Test equality of two empty sets
            //Assert.AreEqual<Cards>(setTwo, setOne); <-- Investigate why this fails on empty sets
            Assert.IsTrue(setOne.Equals(setTwo));

            //Add cards to setOne in a particular order
            setOne.Add(aceOfSpades);
            setOne.Add(kingOfSpades);
            setOne.Add(queenOfSpades);
            setOne.Add(jackOfSpades);
            setOne.Add(tenOfSpades);

            //Test if setOne is equal to an empty set
            Assert.IsFalse(setOne.Equals(setTwo));

            //Add the same cards to setTwo in the same order as setOne
            setTwo.Add(aceOfSpades);
            setTwo.Add(kingOfSpades);
            setTwo.Add(queenOfSpades);
            setTwo.Add(jackOfSpades);
            setTwo.Add(tenOfSpades);

            Assert.IsTrue(setOne.Equals(setTwo));

            //Add the same cards to setThree in a _different_ order
            setTwo.Add(kingOfSpades);
            setTwo.Add(jackOfSpades);
            setTwo.Add(tenOfSpades);
            setTwo.Add(aceOfSpades);
            setTwo.Add(queenOfSpades);

            Assert.IsFalse(setOne.Equals(setThree));
        }

        [TestMethod]
        public void TestContains()
        {
            Cards cardList = new Cards();
            Card aceOfSpades = new Card(Suit.Spade, Rank.Ace);

            Assert.IsFalse(cardList.Contains(aceOfSpades));

            cardList.Add(aceOfSpades);

            Assert.IsTrue(cardList.Contains(aceOfSpades));
        }
    }
}
