using BasketGame.Core.GuessStrategies;
using BasketGame.Core.Players;
using System;
using System.Collections.Generic;
using System.Threading;

namespace BasketGame.Core.Game
{
    public partial class Game
    {
        private object _sync = new object();

        private Basket _basket;

        private ManualResetEvent _finalizeEvent;

        private Thread _finilizerThread;

        private readonly GameState State;

        public IGameAnnouncer Announcer;

        public List<GenericPlayer<IGuessStrategy>> Players { get; private set; }

        public GameRestriction Restriction { get; private set; }

        public Game()
        {
            State = new GameState();
        }

        public string Play()
        {
            if (State.Initialized && !_finilizerThread.IsAlive)
            {
                _finalizeEvent.Reset();
                _finilizerThread.Start();

                foreach (var player in Players)
                    player.Start(Restriction, _sync);
            }
            else
            {
                throw new InvalidOperationException("Game instance is not initialized or already running");
            }

            _finalizeEvent.WaitOne();
            return Announcer.AnnounceFinalData(State);
        }

        public void Stop()
        {
            if (_finalizeEvent != null && _finilizerThread != null && _finilizerThread.IsAlive)
            {
                _finalizeEvent.Set();
            }
        }

        ~Game() {
            _finalizeEvent.Dispose();
        }
    }
}