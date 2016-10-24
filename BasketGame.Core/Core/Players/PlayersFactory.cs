using BasketGame.Core.Game;
using BasketGame.Core.GuessStrategies;
using System;
using System.Collections.Generic;

namespace BasketGame.Core.Players
{
    public static class PlayersFactory
    {
        private static readonly Dictionary<PlayerType, Func<string, GenericPlayer<IGuessStrategy>>> playerCreators = new Dictionary<PlayerType, Func<string, GenericPlayer<IGuessStrategy>>>();

        public static void PreparePlayersType(GameRestriction restriction)
        {
            playerCreators.Add(PlayerType.Cheater, name => new CheaterPlayer(name, new MemorizeGuessStrategy(restriction)));
            playerCreators.Add(PlayerType.Memory, name => new MemoryPlayer(name, new MemorizeGuessStrategy(restriction)));
            playerCreators.Add(PlayerType.Random, name => new RandomPlayer(name, new RandomGuessStrategy(restriction)));
            playerCreators.Add(PlayerType.Thorough, name => new ThoroughPlayer(name, new ThoroughGuessStrategy(restriction)));
            playerCreators.Add(PlayerType.ThoroughCheater, name => new ThoroughCheaterPlayer(name, new ThoroughMemorizeGuessStrategy(restriction)));
        }

        public static GenericPlayer<IGuessStrategy> GetPlayer(string name, PlayerType type)
        {
            Func<string, GenericPlayer<IGuessStrategy>> creator;
            if (playerCreators.TryGetValue(type, out creator))
            {
                return creator(name);
            }
            
            throw new ArgumentException("There is no player type as selected in parameter or there is no delegate added for it", "type");
        }
    }
}