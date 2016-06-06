using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blackjack
{
    public class Dealer
    {
        public Hand Hand { get; set; }

        // Creates hand for Dealer
        public Dealer()
        {
            this.Hand = new Hand(isDealer: true);
        }
    }
}
