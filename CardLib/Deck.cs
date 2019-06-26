using System;
using System.Collections.Generic;
using System.Linq;

namespace CardLib
{
    public class Deck : ICloneable
    {
        public Cards Cards { get; private set; } = new Cards();

        public Cards ListTaken { get; private set; } = new Cards();

        /// <summary>
        /// Creates a Deck of Cards, ordered by Suit and Rank
        /// </summary>
        public Deck()
        {
            for (int suitVal = 0; suitVal < 4; suitVal++)
            {
                for (int rankVal = 1; rankVal < 14; rankVal++)
                {
                    Cards.Add(new Card((Suit)suitVal, (Rank)rankVal));
                }
            }
        }

        /// <summary>
        /// Creates a new Deck, identical in order to the new Deck being fed as a parameter
        /// </summary>
        /// <param name="newCards"></param>
        private Deck(Cards newCards) => Cards = newCards;

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
            Cards newDeck = new Cards();
            bool[] assigned = new bool[52];
            Random sourceGen = new Random();

            for (int i = 0; i < 52; i++)
            {
                int sourceCard = 0;
                bool foundCard = false;

                while (foundCard == false)
                {
                    sourceCard = sourceGen.Next(52);
                    if (assigned[sourceCard] == false)
                        foundCard = true;
                }
                assigned[sourceCard] = true;
                newDeck.Add(Cards[sourceCard]);
            }
            newDeck.CopyTo(Cards);
        }
        /// <summary>
        /// Draws five cards at Random from the Deck object. Bool parameter persistTaken
        /// enables keeping of a List of Cards that have been drawn from the deck in previous
        /// calls to DrawFive.
        /// </summary>
        /// <param name="persistTaken"></param>
        /// <returns></returns>
        public Cards DrawFive(bool persistTaken)
        {
            Cards fiveCards = new Cards();

            if (!persistTaken)
            {
                ListTaken = new Cards();
            }

            while (fiveCards.Count() < 5)
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

        public static bool IsFlush(Cards hand)
        {
            //if hand is empty, return false
            if (hand == null) return false;
            //if hand is not equal to 5 return false
            if (hand.Count() != 5) return false;

            Suit suit = hand.First()._Suit;

            if (hand.Any(c => c._Suit != suit))
            {
                return false;
            }

            return true;
        }

        public object Clone()
        {
            Deck newDeck = new Deck(Cards.Clone() as Cards);
            return newDeck;
        }
    }
}
