using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardLib
{
    class Cards : CollectionBase
    {
        public void Add(Card newCard) => List.Add(newCard);
        public void Remove(Card oldCard) => List.Remove(oldCard);

        public Card this[int cardIndex]
        {
            get { return (Card)List[cardIndex]; }
            set { List[cardIndex] = value; }
        }

        /// <summary>
        /// Utility method for copying card instances into another Cards
        /// instance-used in Deck.Shuffle(). This implementation assimes that
        /// source and target collections are ths ame size.
        /// </summary>
        /// <param name="targetCards"></param>
        public void CopyTo(Cards targetCards)
        {
            for (int index = 0; index < this.Count; index++)
            {
                targetCards[index] = this[index];
            }
        }

        /// <summary>
        /// Check to see if the Cards collection contains a partuclar card.
        /// This calls the Contains() method of the ArraList for the collection,
        /// which you access through the InnerList property.
        /// </summary>
        /// <param name="card"></param>
        /// <returns></returns>
        public bool Contains(Card card) => InnerList.Contains(card);
    }
}
