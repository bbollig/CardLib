using CardLib;
using System.Collections.Generic;
using System.Linq;
using static System.Console;

namespace DrawFlush
{
    class DrawFlush
    {
        static void Main(string[] args)
        {
            Deck deck = new Deck();
            deck.Shuffle();
            List<Card> hand = new List<Card>();
            bool match = false;
            for (int i = 0; i < 1000; i++)
            {
                hand = (List<Card>)deck.DrawFive(false);
                match = Deck.IsFlush(hand);
                WriteLine(string.Join(", ", hand.Select(c => c.suit)));

                if (match)
                {
                    //hand.ForEach(c => Write($"{c.suit} "));
                    WriteLine("Flush!!!!!!!!!!!!!!!");
                    break;
                }
            }

            if (!match)
            {
                WriteLine("No Flush.");
            }
            ReadKey();


            //Book answer:
            //while (true)
            //{
            //    Deck playDeck = new Deck();
            //    playDeck.Shuffle();
            //    bool isFlush = false;
            //    int flushHandIndex = 0;
            //    for (int hand = 0; hand < 10; hand++)
            //    {
            //        isFlush = true;
            //        Suit flushSuit = playDeck.GetCard(hand * 5).suit;
            //        for (int card = 1; card < 5; card++)
            //        {
            //            if (playDeck.GetCard(hand * 5 + card).suit != flushSuit)
            //            {
            //                isFlush = false;
            //            }
            //        }
            //        if (isFlush)
            //        {
            //            flushHandIndex = hand * 5;
            //            break;
            //        }
            //    }
            //    if (isFlush)
            //    {
            //        WriteLine("Flush!!!");
            //        for (int card = 0; card < 5; card++)
            //        {
            //            WriteLine(playDeck.GetCard(flushHandIndex + card));
            //        }
            //    }
            //    else
            //    {
            //        WriteLine("No Flush.");
            //    }
            //    ReadKey();

            //}


        }

    }
}
