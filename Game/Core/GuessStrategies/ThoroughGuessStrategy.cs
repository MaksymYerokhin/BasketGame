using BasketGame.Core.Game;
using System;

namespace BasketGame.Core.GuessStrategies
{
    public class ThoroughGuessStrategy : GenericGuessStrategy
    {
        private int _currentValue;

        public ThoroughGuessStrategy(GameRestriction res) : base(res)
        {
            _currentValue = res.MinWeight;
        }

        public override int GuessNumber()
        {
            if (_max <= _currentValue)
            {
                throw new InvalidOperationException("Cannot guess any more number because the current value reached the maximum");
            }
            return ++_currentValue;
        }
    }
}
