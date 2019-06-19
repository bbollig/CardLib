using System;

namespace CardLib
{
    public class Card : ICloneable, IEquatable<Card>
    {
        public readonly Suit _Suit;
        public readonly Rank _Rank;

        public Card(Suit newSuit, Rank newRank)
        {
            _Suit = newSuit;
            _Rank = newRank;
        }

        private Card() { }

        public override string ToString() => $"The {_Rank} of {_Suit}s";

        public object Clone() => MemberwiseClone();

        public bool Equals(Card other)
        {
            return _Suit == other._Suit && _Rank == other._Rank;
        }

    }
}
