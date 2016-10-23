using BasketGame.Core.GuessStrategies;
using BasketGame.Core.Players;
using System;
using System.Collections.Generic;
using System.Threading;

namespace BasketGame.Core.Game
{
    public partial class Game
    {
        public void Initialize(ICollection<Input> inputs, GameRestriction restriction)
        {
            if (inputs.Count < restriction.MinPlayers || 
                inputs.Count > restriction.MaxPlayers)
            {
                throw new ArgumentException("Players count does not meet minimum or maximum requirement", "inputs");
            }

            Restriction = restriction;

            _basket = new Basket(Restriction.MinWeight, Restriction.MaxWeight);
            Players = new List<GenericPlayer<IGuessStrategy>>(inputs.Count);

            _finilizerThread = new Thread(FinilizeProc);
            _finilizeEvent = new ManualResetEvent(false);

            foreach (var input in inputs)
            {
                var newPlayer = PlayersFactory.GetPlayer(input.Name, input.PlayerType);
                Players.Add(newPlayer);
                newPlayer.OnNumberGueesed += OnNumberGuessedHandler;
            }

            _initialized = true;
        }
    }
}