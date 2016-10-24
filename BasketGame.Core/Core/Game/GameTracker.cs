using BasketGame.Core.GuessStrategies;
using BasketGame.Core.Players;
using System;
using System.Threading;

namespace BasketGame.Core.Game
{
    public partial class Game
    {
        private void OnNumberGuessedHandler(object sender, PlayerGuessEventArgs args)
        {
            var player = sender as GenericPlayer<IGuessStrategy>;
            if (player != null)
            {
                var currentDelta = Math.Abs(_basket.Weight - args.GuessedNumber);

                lock (State)
                {
                    if (!State.Finished && State.Winner == null && State.AttemptsNumber < Restriction.MaxAttempts)
                    {
                        State.AttemptsNumber++;
                        if (args.GuessedNumber == _basket.Weight)
                        {
                            State.Winner = player;
                            // This signal is used for victory case
                            _finalizeEvent.Set();
                        }
                        else
                        {
                            var previousDelta = Math.Abs(_basket.Weight - State.ClosestGuess);
                            if (previousDelta > currentDelta || State.ClosestPlayer == null)
                            {
                                State.ClosestPlayer = player;
                                State.ClosestGuess = args.GuessedNumber;
                            }
                        }
                    }
                    else
                    {
                        StopPlayersGuessing();
                        // This signal is used for attempts exceeded case
                        _finalizeEvent.Set();
                    }
                }

                player.Wait(currentDelta);
            }
        }

        private void FinalizeProc()
        {
            _finalizeEvent.WaitOne(Restriction.MaxMilliseconds);
            lock (State)
            {
                State.Finished = true;
            }

            foreach (var player in Players)
                player.Abort();

            // This signal is used for timeout case
            _finalizeEvent.Set();

            Thread.CurrentThread.Abort();
        }

        private void StopPlayersGuessing()
        {
            foreach (var player in Players)
                player.StopGuessing();
        }
    }
}