using System;
using System.Threading;
using BasketGame.Core.GuessStrategies;
using BasketGame.Core.Game;

namespace BasketGame.Core.Players
{
    public abstract class GenericPlayer<TGuessStrategy>
        where TGuessStrategy : IGuessStrategy
    {
        private Thread _executingThread;

        private object _sync;

        protected TGuessStrategy _guessStrategy;

        public string Name { get; private set; }

        public event EventHandler<PlayerGuessEventArgs> OnNumberGueesed;

        protected virtual void ThreadProc()
        {
            while (true)
            {
                lock (_sync)
                {
                    var number = _guessStrategy.GuessNumber();
                    if (OnNumberGueesed != null)
                    {
                        OnNumberGueesed(this, new PlayerGuessEventArgs(number, this.Name));
                    }
                }
            }
        }

        public GenericPlayer(string name, TGuessStrategy guessStrategy)
        {
            Name = name;
            _guessStrategy = guessStrategy;
            _executingThread = new Thread(ThreadProc);
        }

        public void Start(GameRestriction g, object sync)
        {
            _sync = sync;
            _executingThread.Start();
        }

        public void Wait(int delta)
        {
            Thread.Sleep(delta);
        }

        public void Abort()
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