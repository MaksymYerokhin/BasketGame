using BasketGame.Core.GuessStrategies;
using BasketGame.Core.Players;
using System;
using System.Threading;

namespace BasketGame.Core.Game
{
    /// <summary>
    /// Tracks players guesses, waits the end of the game, making changes to State
    /// </summary>
    public partial class Game
    {
        /// <summary>
        /// Handles all players guesses and makes related changes in game state
        /// </summary>
        /// <param name="sender">Object which emitted the event</param>
        /// <param name="args">Event arguments</param>
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
                        // Here game is finishing, no sense to guess any more
                        // So we prevent guessing for players threads that are
                        // not aborted yet
                        StopPlayersGuessing();
                        // This signal is used for attempts exceeded case
                        _finalizeEvent.Set();
                    }
                }

                player.Wait(currentDelta);
            }
        }
        
        /// <summary>
        /// This method is being executed in a separate thread
        /// and handles the end of the game
        /// </summary>
        private void FinalizeProc()
        {
            // Waits until time is out or the game ends by win or by attempts
            _finalizeEvent.WaitOne(Restriction.MaxMilliseconds);
            lock (State)
            {
                State.Finished = true;
            }

            foreach (var player in Players)
                player.Stop();

            // This signal is used for timeout case
            _finalizeEvent.Set();

            Thread.CurrentThread.Abort();
        }

        /// <summary>
        /// Prevents redundant guessing when game is already finished
        /// but players are not aborted yet
        /// </summary>
        private void StopPlayersGuessing()
        {
            foreach (var player in Players)
                player.StopGuessing();
        }
    }
}