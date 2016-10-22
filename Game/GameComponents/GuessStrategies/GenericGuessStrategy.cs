using Game.GameComponents.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.GameComponents.GuessStrategies
{
    public abstract class GenericGuessStrategy : IGuessStrategy
    {
        protected int _min;
        protected int _max;

        public GenericGuessStrategy(GameRestriction res)
        {
            _min = res.Min;
            _max = res.Max;
        }

        public abstract int GuessNumber();
    }
}