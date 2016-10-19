using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.GameComponents.Players
{
    public class CheaterPlayer : MemoryPlayer
    {
        public CheaterPlayer(string name) : base(name)
        {
            GeneralPlayer.OnNumberGueesed += OnNumberGuessedHandler;
        }

        protected override int GetNumber()
        {
            int min = Restriction.Min;
            int max = Restriction.Max;
            int maxSteps = max - min + 1;
            int selectedNumber = min;

            while (maxSteps > 0)
            {
                maxSteps--;
                selectedNumber = base.GetNumber();
                bool contains = false;
                lock (_memorizedNumbers)
                {
                    contains = _memorizedNumbers.Contains(selectedNumber);
                }
                if (!contains)
                {
                    break;
                }
            }
            
            return selectedNumber;
        }

        public void OnNumberGuessedHandler(object sender, PlayerNumberEventArgs args)
        {
            lock (_memorizedNumbers)
            {
                _memorizedNumbers.Add(args.GuessedNumber);
            }
        }
    }
}