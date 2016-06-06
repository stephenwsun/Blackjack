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
            while (true)
            {

                Game game = new Game();

                game.Play(500, 10);

                Console.WriteLine("Would you like to play again?");
                var playerReply = Console.ReadLine();

                if (playerReply == "Yes")
                {
                    continue;
                }
                else
                {
                    Console.WriteLine("\nGoodbye!");
                    Console.ReadLine();
                    break;
                }
            }
        }
    }
}
