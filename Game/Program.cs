﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.GameComponents;
namespace Game
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Players types:\n 1 - Thorough\n 2 - Memory\n 3 - Random");
            Console.WriteLine("Players number: ");
            int playersCount = Convert.ToInt32(Console.ReadLine());
            List<Input> l = new List<Input>(playersCount);
            for (int i = 0; i < playersCount; i++)
            {
                Console.WriteLine(String.Format("Enter Player {0} name: ", i));
                string name = Console.ReadLine();
                Console.WriteLine(String.Format("Enter Player {0} type: ", i));
                PlayerType type = (PlayerType)Convert.ToInt32(Console.ReadLine());
                l.Add(new GameComponents.Input(name, type));
            }

            Game.GameComponents.Game game = new Game.GameComponents.Game();
            game.Initialize(l, 40, 140);
            game.Play();
        }
    }
}
