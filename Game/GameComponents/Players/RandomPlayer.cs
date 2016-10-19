using System;

namespace Game.GameComponents.Players
{
    public class RandomPlayer : GeneralPlayer
    {
        public RandomPlayer(string name) : base(name)
        {
        }
        
        protected override int GetNumber()
        {
            int min = Restriction.Min;
            int max = Restriction.Max;
            
            return ConcurrentRandom.Generate(min, max);
        }
    }
}