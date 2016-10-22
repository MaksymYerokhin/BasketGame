using Game.GameComponents.GuessStrategies;
using System;

namespace Game.GameComponents.Players
{
    public class ThoroughCheaterPlayer : CheaterPlayer
    {
        public ThoroughCheaterPlayer(string name, ThoroughMemorizeGuessStrategy s) : base(name, s)
        {
        }

        //protected override int GuessNumber()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
