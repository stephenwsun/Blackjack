using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blackjack
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Title = "Blackjack Game by Stephen Sun";

            Console.WriteLine("\nWelcome to the game of BlackJack\n");
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("You have $500 in your account");
            Console.WriteLine("All bets are currently $10");
            Console.WriteLine("----------------------------------------------------\n");


            // Set how much money you want in your account and how much you want to bet for each hand
            Game.Gamble(500, 10);

            while (Player.Balance > 0)
            {
                Game game = new Game();

                Console.WriteLine("Would you like to play again? Press any key to continue...ESC to quit");

                if (Console.ReadKey().Key != ConsoleKey.Escape)
                {
                    continue;
                }
                else
                {
                    Console.WriteLine("\nGoodbye! Bring more money next time!");
                    Console.ReadLine();
                    break;
                }
            }
        }
    }
}
