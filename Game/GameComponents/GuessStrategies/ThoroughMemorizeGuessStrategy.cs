using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.GameComponents.GuessStrategies
{
    public class ThoroughMemorizeGuessStrategy : ThoroughGuessStrategy, ICheaterStrategy
    {
        List<int> _memorizedNumbers = new List<int>();

        public ThoroughMemorizeGuessStrategy(GameRestriction res) : base(res)
        {
        }

        public override int GuessNumber()
        {
            int guessedNumber;
            do
            {
                guessedNumber = base.GuessNumber();
            }
            while (_memorizedNumbers.Contains(guessedNumber));

            return base.GuessNumber();
        }

        public void OnNumberGuessedHandler(object sender, PlayerNumberEventArgs args)
        {
            lock (_memorizedNumbers)
            {
                _memorizedNumbers.Add(args.GuessedNumber);
            }
        }
    }
}
