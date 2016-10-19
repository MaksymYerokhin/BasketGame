using System;

namespace Game.GameComponents.Players
{
    public class ThoroughPlayer : GeneralPlayer
    {
        private int _currentNumber;

        public ThoroughPlayer(string name) : base(name)
        {
            _currentNumber = Restriction.Min;
        }

        protected override int GetNumber()
        {
            return _currentNumber++;
        }
    }
}
