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

            Console.WriteLine("Done generating random deck");

            Console.WriteLine("Dealer's Hand");
            this.deck.Deal(this.Dealer.Hand);

            Console.ReadLine();

            Console.WriteLine("Player's Hand");
            this.deck.Deal(this.Player.Hand);
            
            Console.ReadLine();

            this.deck.cards.ForEach(Console.WriteLine);

            Console.ReadLine();

        }
    }

    
}
