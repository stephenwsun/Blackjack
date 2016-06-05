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
    }
}
