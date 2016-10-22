using BasketGame.Core.Helpers;
using System.Collections.Generic;
using System.Linq;
using BasketGame.Core.Players;

namespace BasketGame.Core.GuessStrategies
{
    public class MemorizeGuessStrategy : GenericGuessStrategy, ICheaterStrategy
    {
        protected readonly List<int> _numbersToGuess;

        public MemorizeGuessStrategy(GameRestriction res) : base(res)
        {
            _numbersToGuess = Enumerable.Range(_min, _max - _min).ToList();
        }

        public override int GuessNumber()
        {
            var randomIndex = ConcurrentRandom.Generate(0, _numbersToGuess.Count - 1);
            return _numbersToGuess[randomIndex];
        }

        public void OnNumberGuessedHandler(object sender, PlayerNumberEventArgs args)
        {
            lock (_numbersToGuess)
            {
                _numbersToGuess.Remove(args.GuessedNumber);
            }
        }
    }
}