using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blackjack
{
    public class Gamble
    {
        private decimal balance;
        private decimal bet;

        public decimal Balance
        {
            get
            {
                return this.balance;
            }

            set
            {
                if (this.balance != value)
                {
                    this.balance = value;
                }
            }
        }

        public decimal Bet
        {
            get
            {
                return this.bet;
            }

            set
            {
                if (this.bet == value)
                {
                    return;
                }

                if (value > this.balance + this.bet && this.balance > 0)
                {
                    this.bet += this.balance;
                    this.Balance = 0;
                }
                else if (value < 0 && this.bet > 0)
                {
                    var temp = this.bet + this.balance;
                    this.bet = 0;
                    this.Balance = temp;
                }
                else if (value >= 0 && value <= this.balance + this.bet)
                {
                    var temp = this.balance + this.bet;
                    this.bet = value;
                    this.Balance = temp - value;
                }
            }
        }
    }
}
