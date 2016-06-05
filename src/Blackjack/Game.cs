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
            Deal();

            while (this.Player.Hand.HardCardTotal <= 21) {
                Console.WriteLine("Would you like to hit or stand? Press 1 for hit and 2 for stand!");
                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        Hit();
                        break;

                    case "2":
                        Stand();
                        break;
                }

            }
        }

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

            this.deck.cards.ForEach(Console.WriteLine);

            //Deck newDeck = new Deck();         

            //newDeck.cards.ForEach(Console.WriteLine);

            Console.WriteLine("\nDone generating random deck\n");
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

        public void Hit()
        {
            this.deck.DealOneCard(this.Player.Hand);

            if (this.Player.Hand.HardCardTotal > 21)
            {
                //this.Player.Balance -= this.Player.Bet;
                //this.Dealer.Hand.Show();
                //this.LastState = GameState.DealerWon;
                //this.AllowedActions = GameAction.Deal;

                Console.WriteLine("Player hand total = " + this.Player.Hand.HardCardTotal);
                Console.WriteLine("Bust! Sorry you lose!");
                Console.ReadLine();
            }
            else if (this.Player.Hand.HardCardTotal == 21 && this.Dealer.Hand.HardCardTotal != 21)
            {
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

        public void Stand()
        {
            while (this.Dealer.Hand.SoftCardTotal < 17)
            {
                this.deck.DealOneCard(this.Dealer.Hand);
                Console.WriteLine("Dealer hand total = " + this.Dealer.Hand.SoftCardTotal);
            }

            if (this.Dealer.Hand.HardCardTotal > 21 || (this.Player.Hand.HardCardTotal > this.Dealer.Hand.HardCardTotal))
            {
                //this.Player.Balance += this.Player.Bet;
                //this.LastState = GameState.PlayerWon;

                Console.WriteLine("Dealer hand total = " + this.Dealer.Hand.HardCardTotal);
                Console.WriteLine("Congratulations! You've won!");
                Console.ReadLine();
            }
            else if (this.Dealer.Hand.HardCardTotal == this.Player.Hand.HardCardTotal)
            {
                //this.LastState = GameState.Draw;

                Console.WriteLine("Dealer hand total = " + this.Dealer.Hand.HardCardTotal);
                Console.WriteLine("It's a tie...FeelsBadMan");
                Console.ReadLine();
            }
            else if (this.Player.Hand.HardCardTotal == 21 && this.Dealer.Hand.HardCardTotal != 21)
            {
                Console.WriteLine("Player hand total = " + this.Player.Hand.HardCardTotal);
                Console.WriteLine("BLACKJACK!!!");
                Console.ReadLine();
            }
            else
            {
                //this.Player.Balance -= this.Player.Bet;
                //this.LastState = GameState.DealerWon;

                Console.WriteLine("Dealer hand total = " + this.Dealer.Hand.HardCardTotal);
                Console.WriteLine("You lose! Better luck next time!");
                Console.ReadLine();
            }

            //this.Dealer.Hand.Show();
            //this.AllowedActions = GameAction.Deal;
        }
    }

    
}
