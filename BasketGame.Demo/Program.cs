using BasketGame.Core.Game;
using System;
using System.Collections.Generic;

namespace BasketGame.Demo
{
    internal class Program
    {
        private const int MinPlayers = 2;

        private const int MaxPlayers = 8;

        private const int MinWeight = 40;

        private const int MaxWeight = 140;

        private const int MaxAttempts = 100;

        private const int MaxMilliseconds = 1500;

        private static void Main()
        {
            var game = new Game();
            var restriction = new GameRestriction(MinPlayers, MaxPlayers, MinWeight, MaxWeight, MaxAttempts, MaxMilliseconds);
            ShowPlayerTypes();
            var playersNumber = ReadPlayersNumber(restriction);
            var players = ReadPlayersInfo(playersNumber);

            game.Initialize(players, restriction);
            Console.WriteLine($"Game is started! The real basket weight: {game.GetBasketWeight()}\n");
            var resultState = game.Play();
            Console.WriteLine(resultState.ToString());
        }

        private static void ShowPlayerTypes()
        {
            Console.WriteLine("Available player types numbers:");
            var playerTypes = Enum.GetValues(typeof(PlayerType));
            for (var i = 0; i < playerTypes.Length; i++)
            {
                Console.WriteLine($"{i} - {playerTypes.GetValue(i)}");
            }
            Console.WriteLine("\n");
        }

        private static int ReadPlayersNumber(GameRestriction restriction)
        {
            bool isValid;
            int result;

            do
            {
                Console.Write("Enter players number: ");
                var input = Console.ReadLine();
                isValid = int.TryParse(input, out result);
                isValid = isValid && (result <= restriction.MaxPlayers &&
                                      result >= restriction.MinPlayers);

                if (!isValid)
                {
                    Console.WriteLine($"Type correct integer number between {restriction.MinPlayers} and {restriction.MaxPlayers}.");
                }
            } while (!isValid);
            
            return result;
        }

        private static List<PlayerInfo> ReadPlayersInfo(int playersNumber)
        {
            var players = new List<PlayerInfo>(playersNumber);
            for (var i = 0; i < playersNumber; i++)
            {
                var name = ReadPlayerName(i);
                var inputType = ReadPlayerType(i);

                players.Add(new PlayerInfo(name, inputType));
            }
            return players;
        }

        private static string ReadPlayerName(int i)
        {
            bool isValid;
            string result;

            do
            {
                Console.Write($"Enter Player {i + 1} name: ");
                result = Console.ReadLine();
                isValid = !string.IsNullOrWhiteSpace(result);
                if (!isValid)
                    Console.WriteLine("Name must contain some visible symbols.");
            } while (!isValid);

            return result;
        }

        private static PlayerType ReadPlayerType(int i)
        {
            bool isValid;
            int resultInt;

            do
            {
                Console.Write($"Enter Player {i + 1} type: ");
                var inputType = Console.ReadLine();
                isValid = int.TryParse(inputType, out resultInt);
                isValid = isValid && Enum.IsDefined(typeof(PlayerType), resultInt);
                if (!isValid)
                {
                    Console.WriteLine("Select one of the Player Type numbers provided at the top.");
                }
            } while (!isValid);
            
            return (PlayerType)resultInt;
        }
    }
}