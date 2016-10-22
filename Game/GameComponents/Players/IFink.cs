using Game.GameComponents.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.GameComponents.Players
{
    interface IFink
    {
        void SubscribeToOtherPlayersGuesses(List<GenericPlayer<IGuessStrategy>> list);
    }
}