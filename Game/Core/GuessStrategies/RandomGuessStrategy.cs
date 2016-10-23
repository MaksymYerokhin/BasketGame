using BasketGame.Core.Game;
using BasketGame.Core.Helpers;

namespace BasketGame.Core.GuessStrategies
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