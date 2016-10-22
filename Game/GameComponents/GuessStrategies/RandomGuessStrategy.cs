using Game.GameComponents.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.GameComponents.GuessStrategies
{
    public class RandomGuessStrategy : GenericGuessStrategy
    {
        public RandomGuessStrategy(GameRestriction res) : base(res)
        {
        }

        public override int GuessNumber()
        {
            return ConcurrentRandom.Generate(_min, _max);
        }
    }
}