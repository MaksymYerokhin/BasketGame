using BasketGame.Core;
using BasketGame.Core.Game;
using BasketGame.Core.Players;
using System;
using System.Collections.Generic;

namespace BasketGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Players types:\n 1 - Thorough\n 2 - Memory\n 3 - Random\n 4 - Cheater");
            Console.WriteLine("Players number: ");
            int playersCount = Convert.ToInt32(Console.ReadLine());
            List<Input> l = new List<Input>(playersCount);
            for (int i = 0; i < playersCount; i++)
            {
                Console.WriteLine(String.Format("Enter Player {0} name: ", i));
                string name = Console.ReadLine();
                Console.WriteLine(String.Format("Enter Player {0} type: ", i));
                PlayerType type = (PlayerType)Convert.ToInt32(Console.ReadLine());
                l.Add(new Input(name, type));
            }

            Game game = new Game();
            game.Initialize(l, new GameRestriction(2, 8, 40, 140, 100, 1500));
            game.Play();
        }
    }
}
