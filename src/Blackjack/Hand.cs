using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blackjack
{
    public class Hand
    {
        public List<Card> cards = new List<Card>();

        public Hand(bool isDealer = false)
        {
            this.IsDealer = isDealer;
        }

        public bool IsDealer { get; set; }

        public void AddCard(Card card)
        {
            this.cards.Add(card);
        }

        public int Total
        {
            get
            {
                // If the int value of a card is between 1 and 10 inclusive, then int value will be used for calculation. Otherwise, it will evaluate to 10 (e.g. J, Q, K)
                return this.cards.Select(c => (int)c.Rank > 1 && (int)c.Rank < 11 ? (int)c.Rank : 10).Sum();
            }
        }

        public int TotalValue
        {
            get
            {
                var totalValue = this.Total;
                var aces = this.cards.Count(c => c.Rank == Rank.Ace);

                while (aces-- > 0 && totalValue > 21)
                {
                    totalValue -= 9;
                }

                return totalValue;
            }
        }
    }
}
