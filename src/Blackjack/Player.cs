using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blackjack
{
    public class Player : Gamble
    {
        public Hand Hand { get; set; }

        // Creates hand for player
        public Player()
        {
            this.Hand = new Hand(isDealer: false);
        }
    }
}
