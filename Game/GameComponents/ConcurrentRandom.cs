using System;

namespace Game.GameComponents
{
    public static class ConcurrentRandom
    {
        private static Random rand = new Random(Environment.TickCount);

        public static int Generate(int min, int max)
        {
            lock (rand)
                return rand.Next(min, max);
        }
    }
}
