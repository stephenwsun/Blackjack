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
            //this.shuffleDeck();
            //this.shuffleDeck();
        }

        public void GenerateDeck()
        {
            this.cards.Clear();
            this.cards.AddRange(
                Enumerable.Range(1, 4)
                    .SelectMany(s => Enumerable.Range(1, 13).Select(n => new Card((Suit)s, (Rank)n))));
        }

        public void shuffleDeck()
        {

            for(int i = 0; i < cards.Count; i++)
            {
                Card temp = cards[i];
                var rnd = new Random();
                int randomIndex = rnd.Next(i, cards.Count);               
                cards[i] = cards[randomIndex];
                cards[randomIndex] = temp;
            }
        }

    }
}
