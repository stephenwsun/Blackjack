using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blackjack
{
    public class Game
    {
        private Deck deck;
        public Player Player { get; private set; }

        public Dealer Dealer { get; private set; }

        public Game()
        {
            this.Dealer = new Dealer();
            this.Player = new Player();

            //Play(500, 10);

            

            bool turnComplete = false;

                
            Deal();

            while (turnComplete == false && this.Player.Hand.HardCardTotal < 21)
            {
                Console.WriteLine("Would you like to hit or stand? Press 1 for hit and 2 for stand!");
                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        Hit();
                        turnComplete = false;
                        break;

                    case "2":
                        Stand();
                        turnComplete = true;
                        break;
                }
            }            
        }

        /// <summary>
        /// Creates/shuffles deck and deals opening hand
        /// </summary>
        public void Deal()
        {
            if (this.deck == null)
            {
                this.deck = new Deck();
            }
            else
            {
                this.deck.GenerateDeck();
            }

            // Prints out every card in the deck - debugging only
            //this.deck.cards.ForEach(Console.WriteLine);  
            //Console.WriteLine("\nDone generating random deck\n");

            Console.WriteLine("Balance: " + this.Player.Balance);
            Console.ReadLine();

            // Dealer's hand
            Console.WriteLine("Dealer's Hand");
            this.deck.Deal(this.Dealer.Hand);
            Console.WriteLine("Dealer hand total = " + this.Dealer.Hand.HardCardTotal);
            Console.ReadLine();

            // Player's hand
            Console.WriteLine("Player's Hand");
            this.deck.Deal(this.Player.Hand);
            Console.WriteLine("Player hand total = " + this.Player.Hand.HardCardTotal);
            Console.ReadLine();

            // Print out the rest of the deck for debugging
            //this.deck.cards.ForEach(Console.WriteLine);
            //Console.ReadLine();
        }

        /// <summary>
        /// Hit action for player, deals player one card
        /// </summary>
        public void Hit()
        {
            this.deck.DealOneCard(this.Player.Hand);

            if (this.Player.Hand.HardCardTotal > 21)
            {
                this.Player.Balance -= this.Player.Bet;
                Console.WriteLine("Balance: " + this.Player.Balance);

                Console.WriteLine("Player hand total = " + this.Player.Hand.HardCardTotal);
                Console.WriteLine("Bust! Sorry you lose!");
                Console.ReadLine();
            }
            else if (this.Player.Hand.HardCardTotal == 21 && this.Dealer.Hand.HardCardTotal != 21)
            {
                this.Player.Balance += this.Player.Bet * 2;

                Console.WriteLine("Player hand total = " + this.Player.Hand.HardCardTotal);
                Console.WriteLine("BLACKJACK!!!");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Player hand total = " + this.Player.Hand.HardCardTotal);
                Console.ReadLine();
            }
        }

        /// <summary>
        /// Stand action for player, switches to dealer
        /// </summary>
        public void Stand()
        {
            while (this.Dealer.Hand.HardCardTotal < 17)
            {
                this.deck.DealOneCard(this.Dealer.Hand);
                Console.WriteLine("Dealer hand total = " + this.Dealer.Hand.HardCardTotal);
            }

            if (this.Dealer.Hand.HardCardTotal > 21 || (this.Player.Hand.HardCardTotal > this.Dealer.Hand.HardCardTotal))
            {
                this.Player.Balance += this.Player.Bet * 2;

                Console.WriteLine("Balance: " + this.Player.Balance);
                Console.WriteLine("Dealer hand total = " + this.Dealer.Hand.HardCardTotal);
                Console.WriteLine("Congratulations! You've won!");
                Console.ReadLine();
            }
            else if (this.Dealer.Hand.HardCardTotal == this.Player.Hand.HardCardTotal)
            {
                Console.WriteLine("Balance: " + this.Player.Balance);
                Console.WriteLine("Dealer hand total = " + this.Dealer.Hand.HardCardTotal);
                Console.WriteLine("It's a tie...FeelsBadMan");
                Console.ReadLine();
            }
            else if (this.Player.Hand.HardCardTotal == 21 && this.Dealer.Hand.HardCardTotal != 21)
            {
                this.Player.Balance += this.Player.Bet * 2;                
                Console.WriteLine("Balance: " + this.Player.Balance);

                Console.WriteLine("Player hand total = " + this.Player.Hand.HardCardTotal);
                Console.WriteLine("BLACKJACK!!!");
                Console.ReadLine();
            }
            else
            {
                this.Player.Balance -= this.Player.Bet;
                Console.WriteLine("Balance: " + this.Player.Balance);

                Console.WriteLine("Dealer hand total = " + this.Dealer.Hand.HardCardTotal);
                Console.WriteLine("You lose! Better luck next time!");
                Console.ReadLine();
            }
        }

        public void Play(decimal balance, decimal bet)
        {
            this.Player.Balance = balance;
            this.Player.Bet = bet;

        }
    }

    
}
