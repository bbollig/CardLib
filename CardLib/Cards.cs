using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardLib
{
    public class Cards : CollectionBase, IEnumerable<Card>, ICloneable, IEquatable<Cards>
    {
        public void Add(Card newCard) => List.Add(newCard);
        public void Remove(Card oldCard) => List.Remove(oldCard);

        public Card this[int cardIndex]
        {
            get { return (Card)List[cardIndex]; }
            set { List[cardIndex] = value; }
        }

        //LINQ expects types that implement IEnumerable<t> and CollectionBase does not. 
        //To make CollectionBase support Linq, simply adding the parent and adding implementatoin
        //fixes this.
        IEnumerator<Card> IEnumerable<Card>.GetEnumerator()
        {
            foreach (Card card in List)
            {
                yield return card;
            }
        }

        /// <summary>
        /// Utility method for copying card instances into another Cards
        /// instance-used in Deck.Shuffle(). This implementation assumes that
        /// source and target collections are ths same size.
        /// </summary>
        /// <param name="targetCards"></param>
        public void CopyTo(Cards targetCards)
        {
            for (int index = 0; index < targetCards.Count(); index++)
            {
                targetCards[index] = this[index];
            }
        }

        public bool Equals(Cards other)
        {
            if (other == null)
                return false;
            if (List.Count != other.Count)
                return false;

            for (int i = 0; i < List.Count; i++)
            {
                if (!List[i].Equals((Card)other.List[i]))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Check to see if the Cards collection contains a partuclar card.
        /// This calls the Contains() method of the ArraList for the collection,
        /// which you access through the InnerList property.
        /// </summary>
        /// <param name="card"></param>
        /// <returns></returns>
        public bool Contains(Card card) => InnerList.Contains(card);

        /// <summary>
        /// Returns a new set of Cards in identical order to the originating set
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            Cards newCards = new Cards();

            foreach (Card sourceCard in List)
            {
                //Cards is a strongly typed Collection Class and Clone returns an object so here we 
                //must cast the object returned by Clone to Card while adding it to newCards
                newCards.Add((Card)sourceCard.Clone());
            }

            return newCards;
        }
    }
}
