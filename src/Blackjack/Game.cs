using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blackjack
{
    public class Game
    {
        private Deck deck;

        public Game()
        {
            Deal();

            
        }

        public void Deal()
        {
            Deck newDeck = new Deck();

            

            newDeck.cards.ForEach(Console.WriteLine);
            
            Console.ReadLine();
        }
    }

    
}
