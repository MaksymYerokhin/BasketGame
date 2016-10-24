using BasketGame.Core.GuessStrategies;
using System.Collections.Generic;

namespace BasketGame.Core.Players
{
    public abstract class GenericCheaterPlayer : GenericPlayer<IGuessStrategy>, ICheatingListener
    {
        protected GenericCheaterPlayer(string name, ICheaterStrategy guessStrategy) : base(name, guessStrategy)
        {
        }

        public void SubscribeToOtherPlayersGuesses(List<GenericPlayer<IGuessStrategy>> players)
        {
            players.ForEach(player => {
                var guessStrategy = _guessStrategy as ICheaterStrategy;
                if (guessStrategy != null) {
                    player.OnNumberGuessed += guessStrategy.OnNumberGuessedHandler;
                }
            });
        }
    }
}