using BasketGame.Core.GuessStrategies;
using System.Collections.Generic;

namespace BasketGame.Core.Players
{
    public abstract class GenericCheaterPlayer : GenericPlayer<IGuessStrategy>, IFink
    {
        public GenericCheaterPlayer(string name, ICheaterStrategy guessStrategy) : base(name, guessStrategy)
        {
        }

        public void SubscribeToOtherPlayersGuesses(List<GenericPlayer<IGuessStrategy>> list)
        {
            list.ForEach(x => {
                x.OnNumberGueesed += _guessStrategy.OnNumberGuessedHandler;
            });
        }
    }
}
