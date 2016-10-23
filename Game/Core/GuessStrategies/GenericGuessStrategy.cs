﻿using BasketGame.Core.Game;

namespace BasketGame.Core.GuessStrategies
{
    public abstract class GenericGuessStrategy : IGuessStrategy
    {
        protected readonly int _min;

        protected readonly int _max;

        public GenericGuessStrategy(GameRestriction res)
        {
            _min = res.MinWeight;
            _max = res.MaxWeight;
        }

        public abstract int GuessNumber();
    }
}