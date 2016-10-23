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
            if (_max < _currentValue) {
                throw new InvalidOperationException("Can't generate more numbers because the upper bound has been reached.");
            }
            return _currentValue++;
        }
    }
}
