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
            this.GenerateCards();
        }

        public void GenerateCards()
        {
            this.cards.Clear();
            this.cards.AddRange(
                Enumerable.Range(1, 4)
                    .SelectMany(s => Enumerable.Range(1, 13).Select(n => new Card((Suit)s, (Rank)n))));
        }

    }
}
