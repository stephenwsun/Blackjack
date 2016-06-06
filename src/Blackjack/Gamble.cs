using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blackjack
{
    public class Gamble
    {
        private static decimal balance;
        private static decimal bet;

        // Allows the starting balance to be set and when the Gamble method is called, the current balance will be returned
        public static decimal Balance
        {
            get
            {
                return balance;
            }

            set
            {
                if (balance != value)
                {
                    balance = value;
                }
            }
        }

        // Stack Overflow
        public static decimal Bet
        {
            get
            {
                return bet;
            }

            set
            {
                if (bet == value)
                {
                    return;
                }

                if (value > balance + bet && balance > 0)
                {
                    bet += balance;
                    Balance = 0;
                }
                else if (value < 0 && bet > 0)
                {
                    var temp = bet + balance;
                    bet = 0;
                    Balance = temp;
                }
                else if (value >= 0 && value <= balance + bet)
                {
                    var temp = balance + bet;
                    bet = value;
                    Balance = temp - value;
                }
            }
        }
    }
}
