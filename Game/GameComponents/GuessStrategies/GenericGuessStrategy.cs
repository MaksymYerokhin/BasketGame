namespace BasketGame.Core.GuessStrategies
{
    public abstract class GenericGuessStrategy : IGuessStrategy
    {
        protected readonly int _min;

        protected readonly int _max;

        public GenericGuessStrategy(GameRestriction res)
        {
            _min = res.Min;
            _max = res.Max;
        }

        public abstract int GuessNumber();
    }
}