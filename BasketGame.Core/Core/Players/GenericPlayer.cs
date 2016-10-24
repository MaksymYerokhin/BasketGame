using System;
using System.Threading;
using BasketGame.Core.GuessStrategies;
using BasketGame.Core.Game;

namespace BasketGame.Core.Players
{
    /// <summary>
    /// Provides common logic for all players
    /// </summary>
    /// <typeparam name="TGuessStrategy">Guess Strategy assigned to specific object</typeparam>
    public abstract class GenericPlayer<TGuessStrategy>
        where TGuessStrategy : IGuessStrategy
    {
        private Thread _executingThread;
        
        protected TGuessStrategy _guessStrategy;

        public string Name { get; }

        public event EventHandler<PlayerGuessEventArgs> OnNumberGuessed;

        /// <summary>
        /// This method is being executed in a separate thread
        /// and handles the process of current player guessing
        /// </summary>
        protected virtual void ThreadProc()
        {
            while (_guessStrategy.CanGuess)
            {
                var number = _guessStrategy.GuessNumber();
                OnNumberGuessed?.Invoke(this, new PlayerGuessEventArgs(number, Name));
            }
        }

        protected GenericPlayer(string name, TGuessStrategy guessStrategy)
        {
            Name = name;
            _guessStrategy = guessStrategy;
            _executingThread = new Thread(ThreadProc);
        }

        public void Start(GameRestriction g)
        {
            _executingThread.Start();
        }

        /// <summary>
        /// Prevents redundant guessing when game is already finished
        /// but players are not aborted yet
        /// </summary>
        public void StopGuessing()
        {
            _guessStrategy.CanGuess = false;
        }

        public void Wait(int delta)
        {
            // This method is raised in event handler
            // so here there is _executingThread context
            Thread.Sleep(delta);
        }

        public void Stop()
        {
            var thread = _executingThread;
            if (thread != null)
            {
                thread.Abort();
                _executingThread = null;
            }
        }
    }
}