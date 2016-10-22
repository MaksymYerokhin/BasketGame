using System;

namespace BasketGame.Core.Helpers
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