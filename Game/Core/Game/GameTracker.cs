using BasketGame.Core.GuessStrategies;
using BasketGame.Core.Players;
using System;
using System.Threading;

namespace BasketGame.Core.Game
{
    public partial class Game
    {
        public void OnNumberGuessedHandler(object sender, PlayerGuessEventArgs args)
        {
            var player = sender as GenericPlayer<IGuessStrategy>;
            lock (_syncObject)
            {
                _attemptsCount++;
                if (Winner == null)
                {
                    if (args.GuessedNumber == _basket.Weight || _attemptsCount >= Restriction.MaxAttempts)
                    {
                        Winner = player;
                        _finilizeEvent.Set();
                    }
                    else
                    {
                        Console.WriteLine(String.Format("{0}: {1}", args.PlayerName, args.GuessedNumber));
                    }
                }
            }

            var delta = Math.Abs(_basket.Weight - args.GuessedNumber);
            player.Wait(delta);
        }

        public void FinilizeProc()
        {
            _finilizeEvent.WaitOne();

            foreach (var player in Players)
                player.Abort();

            Console.WriteLine(Winner.Name + " won!");
            Console.WriteLine(_attemptsCount);
            Console.WriteLine(_basket.Weight);

            Thread.CurrentThread.Abort();
        }
    }
}
