using System;
using System.Threading;

namespace Game.GameComponents.Players
{
    public abstract class GeneralPlayer : IRandomStrategy
    {
        private Thread _executingThread;

        public GameRestriction Restriction { get; private set; }

        public string Name { get; private set; }

        public static event EventHandler<PlayerNumberEventArgs> OnNumberGueesed;

        public GeneralPlayer(string name)
        {
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

        protected abstract int GetNumber();

        protected virtual void ThreadProc()
        {
            while (true)
            {
                var number = GetNumber();
                if (OnNumberGueesed != null)
                    OnNumberGueesed(this, new PlayerNumberEventArgs(number, this.Name));
            }
        }
    }
}
