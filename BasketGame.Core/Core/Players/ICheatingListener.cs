using BasketGame.Core.GuessStrategies;
using System.Collections.Generic;

namespace BasketGame.Core.Players
{
    interface ICheatingListener
    {
        void SubscribeToOtherPlayersGuesses(List<GenericPlayer<IGuessStrategy>> list);
    }
}