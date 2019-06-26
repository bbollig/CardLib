using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace CardLib.Tests
{
    [TestClass]
    public class TestDeck
    {
        [TestMethod]
        public void TestGetCard()
        {
            var testDeck = new Deck();
            var aceOfClubs = new Card(Suit.Club, Rank.Ace);
            var topCard = testDeck.GetCard(0);

            Assert.IsTrue(aceOfClubs._Suit == topCard._Suit && aceOfClubs._Rank == topCard._Rank);
        }

        [TestMethod]
        public void TestShuffle()
        {
            var testDeck = new Deck();
            var testDeckCardSequence = testDeck.Cards.ToList();
            
            testDeck.Shuffle();

            Assert.IsFalse(testDeckCardSequence.SequenceEqual(testDeck.Cards));
        }

        [TestMethod]
        public void FlushEmptyHand()
        {
            var hand = new Cards();
            Assert.IsFalse(Deck.IsFlush(hand));
        }

        [TestMethod]
        public void FlushNullHand()
        {
            Cards hand = null;
            Assert.IsFalse(Deck.IsFlush(hand));
        }

        [TestMethod]
        public void TestFlushCardNumbers()
        {
            Card one = new Card(Suit.Club, Rank.Ace);
            Card two = new Card(Suit.Club, Rank.Deuce);
            Card three = new Card(Suit.Club, Rank.Three);
            Card four = new Card(Suit.Club, Rank.Four);
            Card five = new Card(Suit.Club, Rank.Five);
            Card six = new Card(Suit.Club, Rank.Six);
            
            //Test sending less than 5
            var hand = new Cards { one, two, three, four };
            Assert.IsFalse(Deck.IsFlush(hand));
            
            //Test a five card hand
            hand.Add(five);
            Assert.IsTrue(Deck.IsFlush(hand));
            
            //Test more than 5
            hand.Add(six);
            Assert.IsFalse(Deck.IsFlush(hand));
        }

        [TestMethod]
        public void TestFlush()
        {
            Card one = new Card(Suit.Club, Rank.Ace);
            Card two = new Card(Suit.Club, Rank.Deuce);
            Card three = new Card(Suit.Club, Rank.Three);
            Card four = new Card(Suit.Club, Rank.Four);
            Card five = new Card(Suit.Club, Rank.Five);
            Card heart = new Card(Suit.Heart, Rank.Six);
            
            //Test 4 clubs, one heart
            var hand = new Cards { one, two, three, four, heart };
            Assert.IsFalse(Deck.IsFlush(hand));

            hand.Remove(heart);
            hand.Add(five);
            //Test 5 clubs
            Assert.IsTrue(Deck.IsFlush(hand));
        }

        [TestMethod]
        public void TestClone()
        {
            Deck deck1 = new Deck();

            //Clone deck1 into deck2 and check that all cards in both decks are equal
            Deck deck2 = (Deck)deck1.Clone();

            for (int i = 0; i < deck1.Cards.Count; i++)
            {
                Assert.IsTrue(deck1.GetCard(i).Equals(deck2.GetCard(i)));
            }

            //Now after a shuffle of deck one, check to ensure most positions in both decks are 
            //not the same card. Cannot use a for loop here because there is a small chance that 
            //sometimes the test will fail because the odds of the same card ending up in the 
            //same position after a Shuffle are possible.
            deck1.Shuffle();

            Assert.IsFalse(deck1.GetCard(0).Equals(deck2.GetCard(0)) && 
                           deck1.GetCard(5).Equals(deck2.GetCard(5)) &&
                           deck1.GetCard(25).Equals(deck2.GetCard(25)) &&
                           deck1.GetCard(51).Equals(deck2.GetCard(51)));

            //Now clone the shuffled deck1 into deck3 and check if each of the cards in both decks 
            //are the same card in each position
            Deck deck3 = (Deck)deck1.Clone();

            for (int i = 0; i < deck3.Cards.Count; i++)
            {
                Assert.IsTrue(deck1.GetCard(i).Equals(deck3.GetCard(i)));
            }
        }

    }
}
