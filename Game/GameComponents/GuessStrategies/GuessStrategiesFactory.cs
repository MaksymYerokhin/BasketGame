using Game.GameComponents.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.GameComponents.GuessStrategies
{
    public static class GuessStrategiesFactory
    {
        private static readonly Dictionary<GuessStrategiesTypes, Func<GameRestriction, IGuessStrategy>> dic = new Dictionary<GuessStrategiesTypes, Func<GameRestriction, IGuessStrategy>>();

        static GuessStrategiesFactory()
        {
            dic.Add(GuessStrategiesTypes.Random, res => new RandomGuessStrategy(res));
            dic.Add(GuessStrategiesTypes.Thorough, res => new ThoroughGuessStrategy(res));
        }

        public static IGuessStrategy GetGuessStrategy(GameRestriction res, GuessStrategiesTypes type)
        {
            Func<GameRestriction, IGuessStrategy> gen;
            if (dic.TryGetValue(type, out gen))
                gen(res);
            throw new ArgumentException("There is no registered function to create player for the specified type.", "type");
            //        throw new ArgumentException("Invalid type");
        }
    }
}