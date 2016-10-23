using BasketGame.Core.GuessStrategies;
using BasketGame.Core.Players;
using System;
using System.Collections.Generic;
using System.Threading;

namespace BasketGame.Core.Game
{
    public partial class Game
    {
        public void Initialize(ICollection<PlayerInfo> inputs, GameRestriction restriction)
        {
            if (inputs.Count < restriction.MinPlayers ||
                inputs.Count > restriction.MaxPlayers)
            {
                throw new ArgumentException("Players count does not meet minimum or maximum requirement", "inputs");
            }

            Restriction = restriction;

            _basket = new Basket(Restriction.MinWeight, Restriction.MaxWeight);
            Announcer = new GameAnnouncer(_basket);
            Players = new List<GenericPlayer<IGuessStrategy>>(inputs.Count);

            _finilizerThread = new Thread(FinalizeProc);
            _finilizeEvent = new ManualResetEvent(false);

            PlayersFactory.PreparePlayersType(restriction);

            foreach (var input in inputs)
            {
                var newPlayer = PlayersFactory.GetPlayer(input.Name, input.PlayerType);
                Players.Add(newPlayer);
                newPlayer.OnNumberGueesed += OnNumberGuessedHandler;
            }

            foreach (var player in Players)
            {
                var cheaterPlayer = player as GenericCheaterPlayer;
                if (cheaterPlayer != null)
                {
                    cheaterPlayer.SubscribeToOtherPlayersGuesses(Players);
                }
            }


            State.Initialized = true;
        }
    }
}