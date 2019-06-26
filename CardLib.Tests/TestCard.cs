using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CardLib.Tests
{
    [TestClass]
    public class TestCard
    {
        [TestMethod]
        public void TestCardCtor()
        {
            Card card = new Card(Suit.Spade, Rank.King);

            Assert.IsNotNull(card);
            Assert.IsTrue(Suit.Spade == card._Suit && Rank.King == card._Rank);
        }

        [TestMethod]
        public void TestCardToString()
        {
            Card card = new Card(Suit.Spade, Rank.King);
            string stringOut = "The King of Spades";
            Assert.AreEqual(stringOut, card.ToString());
        }

        [TestMethod]
        public void TestCardClone()
        {
            Card cardOne = new Card(Suit.Club, Rank.Jack);
            Card cardTwo = (Card)cardOne.Clone();

            Assert.IsNotNull(cardTwo);
            Assert.IsTrue(cardOne._Suit == cardTwo._Suit &&
                          cardOne._Rank == cardTwo._Rank);
        }

        [TestMethod]
        public void TestCardEquals()
        {
            Card cardOne = new Card(Suit.Club, Rank.Ace);
            Card cardTwo = new Card(Suit.Club, Rank.Ace);
            Card cardThree = new Card(Suit.Heart, Rank.Ace);

            Assert.IsTrue(cardOne.Equals(cardTwo));
            Assert.IsFalse(cardOne.Equals(cardThree));
        }
    }
}
