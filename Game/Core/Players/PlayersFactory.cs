using BasketGame.Core.Game;
using BasketGame.Core.GuessStrategies;
using System;
using System.Collections.Generic;

namespace BasketGame.Core.Players
{
    public static class PlayersFactory
    {
        private static readonly Dictionary<PlayerType, Func<string, GenericPlayer<IGuessStrategy>>> playerCreators = new Dictionary<PlayerType, Func<string, GenericPlayer<IGuessStrategy>>>();
        
        public static void PreparePlayersType(GameRestriction restriction) {
            playerCreators.Add(PlayerType.Cheater, nam => new CheaterPlayer(nam, new MemorizeGuessStrategy(restriction)));
            playerCreators.Add(PlayerType.Memory, nam => new MemoryPlayer(nam, new MemorizeGuessStrategy(restriction)));
            playerCreators.Add(PlayerType.Random, nam => new RandomPlayer(nam, new RandomGuessStrategy(restriction)));
            playerCreators.Add(PlayerType.Thorough, nam => new ThoroughPlayer(nam, new ThoroughGuessStrategy(restriction)));
            playerCreators.Add(PlayerType.ThoroughCheater, nam => new ThoroughCheaterPlayer(nam, new ThoroughMemorizeGuessStrategy(restriction)));
        }

        public static GenericPlayer<IGuessStrategy> GetPlayer(string name, PlayerType type)
        {
            Func<string, GenericPlayer<IGuessStrategy>> creator;
            if (playerCreators.TryGetValue(type, out creator))
            {
                creator(name);
            }

            throw new ArgumentException("There is no registered function to create player for the specified type.", "type");
        }
    }
}