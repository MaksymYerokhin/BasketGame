using BasketGame.Core.Game;
using System;
using System.Collections.Generic;

namespace BasketGame.Demo
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var game = new Game();
            Console.WriteLine("Players types:\n 0 - Thorough\n 1 - Memory\n 2 - Random\n 3 - Cheater\n 4 - Thorough Cheater\n");
            Console.Write("Enter players number: ");
            var playersNumber = Convert.ToInt32(Console.ReadLine());

            var players = new List<PlayerInfo>(playersNumber);
            for (var i = 0; i < playersNumber; i++)
            {
                Console.Write($"Enter Player {i + 1} name: ");
                var name = Console.ReadLine();
                Console.Write($"Enter Player {i + 1} type: ");
                var type = (PlayerType)Convert.ToInt32(Console.ReadLine());
                players.Add(new PlayerInfo(name, type));
            }

            game.Initialize(players, new GameRestriction(2, 8, 40, 140, 100, 1500));
            Console.WriteLine(game.Announcer.AnnounceInitialData());
            var result = game.Play();
            Console.WriteLine(result);
        }
    }
}