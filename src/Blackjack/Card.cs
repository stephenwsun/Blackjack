using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blackjack
{
    public class Card
    {
        public Card(Suit suit, Rank rank)
        {
            this.Suit = suit;
            this.Rank = rank;
            
                     
        }


        public Rank Rank { get; set; }
        public Suit Suit { get; set; }



        public override string ToString()
        {
            string suit = "";

            switch (this.Suit)
            {
                case Suit.Clubs:
                    suit = "Clubs";
                    break;
                case Suit.Diamonds:
                    suit = "Diamonds";
                    break;
                case Suit.Hearts:
                    suit = "Hearts";
                    break;
                case Suit.Spades:
                    suit = "Spades";
                    break;
            }

            var value = (int)this.Rank > 1 && (int)this.Rank < 11 ?
                ((int)this.Rank).ToString() :
                Enum.GetName(typeof(Rank), this.Rank).Substring(0, 1);

            return value + " of " + suit;
        }



    }

    public enum Suit
    {
        Clubs = 1,
        Diamonds = 2,
        Hearts = 3,
        Spades = 4
    }

    public enum Rank
    {
        Ace = 1,
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5,
        Six = 6,
        Seven = 7,
        Eight = 8,
        Nine = 9,
        Ten = 10,
        Jack = 11,
        Queen = 12,
        King = 13
    }
}
