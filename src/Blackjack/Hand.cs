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

        public int SoftCardTotal
        {
            get
            {  
                // If there's an ace, then evaluate as 11
                // Otherwise, if the int value of a card is between 0 and 11, then int value will be used for calculation. Otherwise, it will evaluate to 10 (e.g. J, Q, K)
                return this.cards.Select(cardValue => (int)cardValue.Rank ==1 ? 11 : (int)cardValue.Rank > 1 && (int)cardValue.Rank < 11 ? (int)cardValue.Rank : 10).Sum();
            }
        }

        public int HardCardTotal
        {
            get
            {
                // Get card total from SoftCardTotal
                var hardCardTotal = this.SoftCardTotal;

                // Count the number of aces in the deck
                var numberOfAces = this.cards.Count(cardValue => cardValue.Rank == Rank.Ace);

                // While there's an ace in the player's hand and the card total is greater than 21, we want Ace value to equal 1 by subtracting 10 from the card total
                while(numberOfAces-- > 0 && hardCardTotal > 21)
                {
                    hardCardTotal -= 10;
                }

                return hardCardTotal;
            }
        }
    }
}
