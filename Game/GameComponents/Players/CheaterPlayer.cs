using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.GameComponents;
using Game.GameComponents.GuessStrategies;

namespace Game.GameComponents.Players
{
    public class CheaterPlayer : MemoryPlayer, IFink
    {
        public CheaterPlayer(string name, MemorizeGuessStrategy r) : base(name, r)
        {
        }

        //protected override int GetNumber()
        //{
        //    int min = Restriction.Min;
        //    int max = Restriction.Max;
        //    int maxSteps = max - min + 1;
        //    int selectedNumber = min;

        //    while (maxSteps > 0)
        //    {
        //        maxSteps--;
        //        selectedNumber = base.GetNumber();
        //        bool contains = false;
        //        lock (_memorizedNumbers)
        //        {
        //            contains = _memorizedNumbers.Contains(selectedNumber);
        //        }
        //        if (!contains)
        //        {
        //            break;
        //        }
        //    }
            
        //    return selectedNumber;
        //}
        
        public void SubscribeToOtherPlayersGuesses(List<GenericPlayer<IGuessStrategy>> list)
        {
            list.ForEach(x => {
                x.OnNumberGueesed += _guessStrategy.OnNumberGuessedHandler;
            });
        }
    }
}