using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.GameComponents.GuessStrategies
{
    public interface ICheaterStrategy
    {
        void OnNumberGuessedHandler(object sender, PlayerNumberEventArgs args);
    }
}
