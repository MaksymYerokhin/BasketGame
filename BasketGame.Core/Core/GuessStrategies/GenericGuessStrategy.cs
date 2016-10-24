using BasketGame.Core.Game;

namespace BasketGame.Core.GuessStrategies
{
    /// <summary>
    /// Provides common part of logic used by all strategies
    /// </summary>
    public abstract class GenericGuessStrategy : IGuessStrategy
    {
        protected readonly int _min;

        protected readonly int _max;

        public bool CanGuess { get; set; } = true;

        protected GenericGuessStrategy(GameRestriction res)
        {
            _min = res.MinWeight;
            _max = res.MaxWeight;
        }

        public abstract int GuessNumber();
    }
}