using System;
using System.Threading;
using BasketGame.Core.GuessStrategies;

namespace BasketGame.Core.Players
{
    public abstract class GenericPlayer<TGuessStrategy>
        where TGuessStrategy : IGuessStrategy
    {
        private Thread _executingThread;

        protected TGuessStrategy _guessStrategy;

        public GameRestriction Restriction { get; private set; }

        public string Name { get; private set; }

        public event EventHandler<PlayerNumberEventArgs> OnNumberGueesed;

        //public static explicit operator GenericPlayer<TGuessStrategy>(CheaterPlayer v)
        //{
        //    return new GenericPlayer<TGuessStrategy>(v.Name, (IGuessStrategy)v._guessStrategy);
        //}

        public GenericPlayer(string name, TGuessStrategy guessStrategy)
        {
            _guessStrategy = guessStrategy;
            Name = name;
            _executingThread = new Thread(ThreadProc);
        }

        public void Start(GameRestriction g)
        {
            Restriction = g;
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
        
        protected virtual void ThreadProc()
        {
            while (true)
            {
                var number = _guessStrategy.GuessNumber();
                if (OnNumberGueesed != null)
                    OnNumberGueesed(this, new PlayerNumberEventArgs(number, this.Name));
            }
        }
    }
}