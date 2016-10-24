using BasketGame.Core.GuessStrategies;
using System.Collections.Generic;

namespace BasketGame.Core.Players
{
    public interface ICheatingListener
    {
        void SubscribeToOtherPlayersGuesses(List<GenericPlayer<IGuessStrategy>> list);
    }
}