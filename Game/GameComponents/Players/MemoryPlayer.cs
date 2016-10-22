using Game.GameComponents.GuessStrategies;
using System.Collections.Generic;

namespace Game.GameComponents.Players
{
    public class MemoryPlayer : GenericPlayer<IGuessStrategy>
    {
        //protected HashSet<int> _memorizedNumbers;

        public MemoryPlayer(string name, MemorizeGuessStrategy r) : base(name, r)
        {
            //_memorizedNumbers = new HashSet<int>();
            this.OnNumberGueesed += r.OnNumberGuessedHandler;
        }

        //protected override int GuessNumber()
        //{
            //int generatedNumber;

            //do
            //{
            //    generatedNumber = base.GuessNumber();
            //}
            //while (_excludedNumbers.Contains(generatedNumber));

            //return generatedNumber;




            //int min = Restriction.Min;
            //int max = Restriction.Max;
            ////int maxSteps = max - min + 1;
            //int selectedNumber = min;

            //while (true)
            //{
            //    //maxSteps--;
            //    selectedNumber = base.GuessNumber();
            //    bool contains = false;
            //    lock (_memorizedNumbers)
            //    {
            //        contains = _memorizedNumbers.Contains(selectedNumber);
            //    }
            //    if (!contains)
            //    {
            //        break;
            //    }
            //}
            
            //return selectedNumber;
        //}

        //protected void OnNumberGuessedHandler(object sender, PlayerNumberEventArgs args)
        //{
        //    lock (_memorizedNumbers)
        //    {
        //        _memorizedNumbers.Add(args.GuessedNumber);
        //    }
        //}
    }
}