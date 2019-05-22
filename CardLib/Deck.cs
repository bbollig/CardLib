using System;
using System.Collections.Generic;
using System.Linq;

namespace CardLib
{
    public class Deck
    {
        public Card[] Cards { get; }

        public List<Card> ListTaken { get; private set; } = new List<Card>();

        /// <summary>
        /// Creates a Deck of Cards, ordered by Suit and Rank
        /// </summary>
        public Deck()
        {
            Cards = new Card[52];

            for (int suitVal = 0; suitVal < 4; suitVal++)
            {
                for (int rankVal = 1; rankVal < 14; rankVal++)
                {
                    Cards[suitVal * 13 + rankVal - 1] = new Card((Suit)suitVal,
                                                                (Rank)rankVal);
                }
            }
        }

        /// <summary>
        /// Returns a single Card object at the index specified
        /// </summary>
        /// <param name="cardNum"></param>
        /// <returns></returns>
        public Card GetCard(int cardNum)
        {
            if (cardNum >= 0 && cardNum <= 51)
                return Cards[cardNum];
            else
                throw (new ArgumentOutOfRangeException("cardNum", cardNum,
                            "Value must be between 0 and 51."));
        }

        /// <summary>
        /// Randomly sorts the Deck
        /// </summary>
        public void Shuffle()
        {
            Card[] newDeck = new Card[52];
            bool[] assigned = new bool[52];
            Random sourceGen = new Random();

            for (int i = 0; i < 52; i++)
            {
                int destCard = 0;
                bool foundCard = false;

                while (foundCard == false)
                {
                    destCard = sourceGen.Next(52);
                    if (assigned[destCard] == false)
                        foundCard = true;
                }
                assigned[destCard] = true;
                newDeck[destCard] = Cards[i];
            }
            newDeck.CopyTo(Cards, 0);
        }
        /// <summary>
        /// Draws five cards at Random from the Deck object. Bool parameter persistTaken
        /// enables keeping of a List of Cards that have been drawn from the deck in previous
        /// calls to DrawFive.
        /// </summary>
        /// <param name="persistTaken"></param>
        /// <returns></returns>
        public IEnumerable<Card> DrawFive(bool persistTaken)
        {
            List<Card> fiveCards = new List<Card>();
            List<Card> newDeck = new List<Card>(Cards);

            if (!persistTaken)
            {
                ListTaken = new List<Card>();
            }

            while (fiveCards.Count < 5)
            {
                Random randomNumber = new Random();
                Card card = GetCard(randomNumber.Next(52));
                if (!ListTaken.Contains(card))
                {
                    fiveCards.Add(card);
                    ListTaken.Add(card);
                }
            }
            return fiveCards;
        }

        public static bool IsFlush(IEnumerable<Card> hand)
        {
            //if hand is empty, return false
            if (hand == null) return false;
            //if hand is not equal to 5 return false
            if (hand.Count() != 5) return false;

            Suit suit = hand.First().suit;

            if (hand.Any(c => c.suit != suit))
            {
                return false;
            }

            return true;
        }
    }
}
