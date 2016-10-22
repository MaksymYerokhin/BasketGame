using Game.GameComponents.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.GameComponents.GuessStrategies
{
    public class ThoroughGuessStrategy : GenericGuessStrategy
    {
        private int _currentValue;

        public ThoroughGuessStrategy(GameRestriction res) : base(res)
        {
            _currentValue = res.Min;
        }

        public override int GuessNumber()
        {
            if (_max < _currentValue) {
                _currentValue = _min;
            }
            return _currentValue++;
        }
    }
}
