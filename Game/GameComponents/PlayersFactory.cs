using Game.GameComponents.GuessStrategies;
using Game.GameComponents.Players;
using System;
using System.Collections.Generic;

namespace Game.GameComponents
{
    public static class PlayersFactory
    {
        private static readonly Dictionary<PlayerType, Func<string, GenericPlayer<IGuessStrategy>>> dic = new Dictionary<PlayerType, Func<string, GenericPlayer<IGuessStrategy>>>();

        static PlayersFactory()
        {
            dic.Add(PlayerType.Cheater, nam => new CheaterPlayer(nam, new MemorizeGuessStrategy(new GameRestriction(0, 0))));
            dic.Add(PlayerType.Memory, nam => new MemoryPlayer(nam, new MemorizeGuessStrategy(new GameRestriction(0, 0))));
            dic.Add(PlayerType.Random, nam => new RandomPlayer(nam, new RandomGuessStrategy(new GameRestriction(0, 0))));
            dic.Add(PlayerType.Thorough, nam => new ThoroughPlayer(nam, new ThoroughGuessStrategy(new GameRestriction(0, 0))));
            dic.Add(PlayerType.ThoroughCheater, nam => new ThoroughCheaterPlayer(nam, new ThoroughMemorizeGuessStrategy(new GameRestriction(0, 0))));
        }

        public static GenericPlayer<IGuessStrategy> GetPlayer(string name, PlayerType type)
        {
            Func<string, GenericPlayer<IGuessStrategy>> gen;
            if (dic.TryGetValue(type, out gen))
                gen(name);
            throw new ArgumentException("There is no registered function to create player for the specified type.", "type");
            //    default:
            //        throw new ArgumentException("Invalid type");
            //}
        }
    }
}
