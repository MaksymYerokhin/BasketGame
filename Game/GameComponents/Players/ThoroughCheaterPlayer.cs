using System;

namespace Game.GameComponents.Players
{
    public class ThoroughCheaterPlayer : GeneralPlayer
    {
        public ThoroughCheaterPlayer(string name) : base(name)
        {
        }

        protected override int GetNumber()
        {
            throw new NotImplementedException();
        }
    }
}
