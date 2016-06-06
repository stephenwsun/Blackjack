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

            bool playerTurnComplete = false;
            

            Deal();

            while (playerTurnComplete == false && this.Player.Hand.HardCardTotal < 21)
            {
                Console.WriteLine("\nWould you like to Hit or Stand? Press ENTER for Hit and SPACEBAR for Stand!");
                var userInput = Console.ReadKey();

                switch (userInput.Key)
                {
                    case ConsoleKey.Enter:
                        Hit();
                        playerTurnComplete = false;
                        break;

                    case ConsoleKey.Spacebar:
                        Stand();
                        playerTurnComplete = true;
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

            //Console.WriteLine("Balance: $" + Player.Balance);
            Console.WriteLine("Press any key to start playing...");
            Console.ReadLine();

            // Dealer's hand
            Console.WriteLine("------------------");
            Console.WriteLine("Dealer's Hand");
            Console.WriteLine("------------------");
            this.deck.DealDealer(this.Dealer.Hand);

            // Prints out the dealer's card total for opening hand - debugging only
            //Console.WriteLine("Dealer hand total = " + this.Dealer.Hand.HardCardTotal);
            //Console.ReadLine();

            // Player's hand
            Console.WriteLine("------------------");
            Console.WriteLine("Your Hand");
            Console.WriteLine("------------------");
            this.deck.Deal(this.Player.Hand);

            // Prints out the player's card total for opening hand - debugging only
            Console.WriteLine("\nYou have " + this.Player.Hand.HardCardTotal);
            //Console.ReadLine();

            // Print out the rest of the deck - debugging only
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
                Player.Balance -= Player.Bet;
                
                Console.WriteLine("You have " + this.Player.Hand.HardCardTotal);
                Console.WriteLine("Bust! Sorry you lose!");
                Console.WriteLine("Current Account Balance: $" + Player.Balance);
                Console.ReadLine();
            }
            else if (this.Player.Hand.HardCardTotal == 21 && this.Dealer.Hand.HardCardTotal != 21)
            {
                Player.Balance += Player.Bet * 2;
                
                Console.WriteLine("You have " + this.Player.Hand.HardCardTotal);
                Console.WriteLine("BLACKJACK!!!");
                Console.WriteLine("Current Account Balance: $" + Player.Balance);
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("You have " + this.Player.Hand.HardCardTotal);
                Console.ReadLine();
            }
        }

        /// <summary>
        /// Stand action for player, switches to dealer
        /// </summary>
        public void Stand()
        {
            Console.WriteLine("\nDealer has " + this.Dealer.Hand.HardCardTotal + " in hand\n");

            while (this.Dealer.Hand.HardCardTotal < 17)
            {               
                this.deck.DealOneCard(this.Dealer.Hand);
                Console.WriteLine("Dealer has \n" + this.Dealer.Hand.HardCardTotal);
            }

            if (this.Dealer.Hand.HardCardTotal > 21 || (this.Player.Hand.HardCardTotal > this.Dealer.Hand.HardCardTotal))
            {
                Player.Balance += Player.Bet * 2;
               
                //Console.WriteLine("Dealer has " + this.Dealer.Hand.HardCardTotal);
                Console.WriteLine("Congratulations! You've won!");
                Console.WriteLine("\nCurrent Account Balance: $" + Player.Balance);
                Console.ReadLine();
            }

            else if (this.Dealer.Hand.HardCardTotal == this.Player.Hand.HardCardTotal)
            {                
                Console.WriteLine("Dealer has " + this.Dealer.Hand.HardCardTotal);
                Console.WriteLine("It's a tie...FeelsBadMan");
                Console.WriteLine("\nCurrent Account Balance: $" + Player.Balance);
                Console.ReadLine();
            }

            else if (this.Player.Hand.HardCardTotal == 21 && this.Dealer.Hand.HardCardTotal != 21)
            {
                Player.Balance += Player.Bet * 2;
                
                Console.WriteLine("You have " + this.Player.Hand.HardCardTotal);
                Console.WriteLine("BLACKJACK!!!");
                Console.WriteLine("\nCurrent Account Balance: $" + Player.Balance);
                Console.ReadLine();
            }

            else
            {
                Player.Balance -= Player.Bet;
                
                Console.WriteLine("Dealer has " + this.Dealer.Hand.HardCardTotal);
                Console.WriteLine("You lose! Better luck next time!");
                Console.WriteLine("\nCurrent Account Balance: $" + Player.Balance);
                Console.ReadLine();
            }
        }

        /// <summary>
        /// This method is used to set the starting balance for gambling and also individual bet amounts
        /// </summary>
        /// <param name="balance"></param>
        /// <param name="bet"></param>
        public static void Gamble(decimal balance, decimal bet)
        {
            Player.Balance = balance;
            Player.Bet = bet;
        }
    }

    
}
