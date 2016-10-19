using Game.GameComponents.Players;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Game.GameComponents
{
    public class Game
    {
        private List<GeneralPlayer> _players;
        private Basket _basket;

        private ManualResetEvent _finilizeEvent;
        private Thread _finilizerThread;

        public GameRestriction restr;

        private object _syncObject = new object();

        public void Initialize(List<Input> inputs, int min, int max)
        {
            _basket = new Basket(min, max);
            restr = new GameRestriction(min, max);

            _players = new List<GeneralPlayer>();

            // ?? mb not static
            GeneralPlayer.OnNumberGueesed += OnNumberGuessedHandler;

            _finilizerThread = new Thread(FinilizeProc);
            _finilizeEvent = new ManualResetEvent(false);
            _finilizerThread.Start();

            foreach (var input in inputs)
                _players.Add(PlayersFactory.GetPlayer(input.Name, input.PlayerType));
        }

        public void Play()
        {
            foreach (var player in _players)
                player.Start(restr);
        }

        public void OnNumberGuessedHandler(object sender, PlayerNumberEventArgs args)
        {
            var player = sender as GeneralPlayer;
            lock (_syncObject)
            {
                if (args.GuessedNumber == _basket.Weight)
                {
                    Console.WriteLine(player.Name + "won!");
                    Console.WriteLine(_basket.Weight);
                    _finilizeEvent.Set();
                }
                else
                {
                    Console.WriteLine(String.Format("{0}: {1}", args.PlayerName, args.GuessedNumber));
                }
            }

            var delta = Math.Abs(_basket.Weight - args.GuessedNumber);
            player.Wait(delta);
        }

        public void FinilizeProc()
        {
            _finilizeEvent.WaitOne();

            foreach (var player in _players)
                player.Abort();
        }
    }
}