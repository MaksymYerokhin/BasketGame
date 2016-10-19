using System.Collections.Generic;

namespace Game.GameComponents.Players
{
    public class MemoryPlayer : RandomPlayer
    {
        protected HashSet<int> _memorizedNumbers;

        public MemoryPlayer(string name) : base(name)
        {
            _memorizedNumbers = new HashSet<int>();
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

            lock (_memorizedNumbers)
            {
                _memorizedNumbers.Add(selectedNumber);
            }
            
            return selectedNumber;
        }
    }
}