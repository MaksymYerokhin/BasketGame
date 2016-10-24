using System.Collections.Generic;
using BasketGame.Core.Players;
using BasketGame.Core.Game;

namespace BasketGame.Core.GuessStrategies
{
    /// <summary>
    /// Takes numbers iteratively but memorizes and skips already guessed
    /// numbers, own or other players.
    /// </summary>
    public class ThoroughMemorizeGuessStrategy : ThoroughGuessStrategy, ICheaterStrategy
    {
        private List<int> _memorizedNumbers = new List<int>();

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
            return guessedNumber;
        }

        public void OnNumberGuessedHandler(object sender, PlayerGuessEventArgs args)
        {
            lock (_memorizedNumbers)
            {
                if (!_memorizedNumbers.Contains(args.GuessedNumber))
                {
                    _memorizedNumbers.Add(args.GuessedNumber);
                }
            }
        }
    }
}