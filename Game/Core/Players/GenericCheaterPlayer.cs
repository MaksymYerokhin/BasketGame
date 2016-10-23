﻿using BasketGame.Core.GuessStrategies;
using System.Collections.Generic;

namespace BasketGame.Core.Players
{
    public abstract class GenericCheaterPlayer : GenericPlayer<IGuessStrategy>, ICheatingListener
    {
        public GenericCheaterPlayer(string name, ICheaterStrategy guessStrategy) : base(name, guessStrategy)
        {
        }

        public void SubscribeToOtherPlayersGuesses(List<GenericPlayer<IGuessStrategy>> list)
        {
            list.ForEach(x => {
                var guessStrategy = _guessStrategy as ICheaterStrategy;
                if (guessStrategy != null) {
                    x.OnNumberGueesed += guessStrategy.OnNumberGuessedHandler;
                }
            });
        }
    }
}