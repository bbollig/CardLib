using System;

namespace CardLib
{
    public class Card : ICloneable
    {
        public readonly Suit suit;
        public readonly Rank rank;

        public Card(Suit newSuit, Rank newRank)
        {
            suit = newSuit;
            rank = newRank;
        }
        private Card() { }

        public object Clone() => MemberwiseClone();

        public override string ToString() => $"The {rank} of {suit}s";
    }
}
