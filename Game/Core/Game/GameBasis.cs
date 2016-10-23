using BasketGame.Core.GuessStrategies;
using BasketGame.Core.Players;
using System;
using System.Collections.Generic;
using System.Threading;

namespace BasketGame.Core.Game
{
    public partial class Game
    {
        #region private fields
        
        private Basket _basket;

        private int _attemptsCount;

        private ManualResetEvent _finilizeEvent;

        private object _syncObject = new object();

        private Thread _finilizerThread;

        private bool _initialized;

        #endregion

        public ICollection<GenericPlayer<IGuessStrategy>> Players { get; private set; }

        public GenericPlayer<IGuessStrategy> Winner { get; private set; }

        public GameRestriction Restriction { get; private set; }

        public void Play()
        {
            if (_initialized && !_finilizerThread.IsAlive)
            {
                _finilizeEvent.Reset();
                _finilizerThread.Start();

                foreach (var player in Players)
                    player.Start(Restriction);
            }
            else
            {
                throw new InvalidOperationException("Game instance is not initialized or already running");
            }
        }

        public void Stop()
        {
            if (_finilizeEvent != null && _finilizerThread != null && _finilizerThread.IsAlive)
            {
                _finilizeEvent.Set();
            }
        }
    }
}