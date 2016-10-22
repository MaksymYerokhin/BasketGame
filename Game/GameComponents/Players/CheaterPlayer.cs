using BasketGame.Core.GuessStrategies;
using System.Collections.Generic;

namespace BasketGame.Core.Players
{
    public class CheaterPlayer : MemoryPlayer, IFink
    {
        public CheaterPlayer(string name, MemorizeGuessStrategy r) : base(name, r)
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