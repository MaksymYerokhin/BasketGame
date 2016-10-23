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
            Game game = new Game();
            Console.WriteLine("Players types:\n 0 - Thorough\n 1 - Memory\n 2 - Random\n 3 - Cheater\n 4 - Thorough Cheater\n");
            string[] names = { "Max", "Reidan", "Alexander" };
            Console.Write("Players number: ");
            int playersCount = Convert.ToInt32(Console.ReadLine());

            List<PlayerInfo> players = new List<PlayerInfo>(playersCount);
            for (int i = 0; i < playersCount; i++)
            {
                //Console.Write(String.Format("Enter Player {0} name: ", i + 1));
                string name = names[i];//Console.ReadLine();
                Console.Write(String.Format("Enter Player {0} type: ", i + 1));
                PlayerType type = (PlayerType)Convert.ToInt32(Console.ReadLine());
                players.Add(new PlayerInfo(name, type));
            }

            game.Initialize(players, new GameRestriction(1, 8, 40, 60, 14, 1500));
            Console.WriteLine(game.Announcer.AnnounceInitialData());
            var result = game.Play();
            Console.WriteLine(result);
        }
    }
}