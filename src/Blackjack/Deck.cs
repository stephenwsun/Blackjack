using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blackjack
{
    public class Deck
    {
        public List<Card> cards = new List<Card>(52);

        public Deck()
        {
            this.GenerateDeck();
            this.shuffleDeck();
        }

        /// <summary>
        /// Creates a deck of 52 cards
        /// </summary>
        public void GenerateDeck()
        {
            this.cards.Clear();
            this.cards.AddRange(
                Enumerable.Range(1, 4)
                    .SelectMany(s => Enumerable.Range(1, 13).Select(n => new Card((Suit)s, (Rank)n))));
        }

        /// <summary>
        /// Shuffles the cards in the deck using Fisher-Yates  modern algorithm.  
        /// </summary>

        /*************************************************************************************
          Modern algorithm reduces the algorithm's time complexity to O(n), compared to O(n2).
             
          To shuffle an array a of n elements (indices 0..n-1):
             
          for i from n−1 downto 1 do
              j ← random integer such that 0 ≤ j ≤ i
              exchange a[j] and a[i]
        *************************************************************************************/

        public void shuffleDeck()
        {
            Card temp;
            int count = cards.Count;
            var rnd = new Random();

            for (int i = count - 1; i > 0; i--)
            {
                int rndNum = rnd.Next(0, i + 1);
                temp = cards[i];
                cards[i] = cards[rndNum];
                cards[rndNum] = temp;
            }
        }

        public void Deal(Hand hand)
        {
            //List<Card> firstTwoCards = cards.GetRange(0,2);

            //firstTwoCards.ForEach(Console.WriteLine);

            var card = this.cards.First();
            hand.AddCard(card);
            Console.WriteLine(card);

            //Console.WriteLine("________________");
            //Console.WriteLine("|              |");
            //Console.WriteLine("| {0} {1}   |", card.Rank, card.Suit);
            //Console.WriteLine("|              |");
            //Console.WriteLine("|              |");
            //Console.WriteLine("|              |");
            //Console.WriteLine("|              |");
            //Console.WriteLine("|              |");
            //Console.WriteLine("|              |");
            //Console.WriteLine("|              |");
            //Console.WriteLine("________________");

            this.cards.Remove(card);

            card = this.cards.First();

            hand.AddCard(card);
            Console.WriteLine(card);
            this.cards.Remove(card);
        }
    }
}
