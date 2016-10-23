using System;

namespace BasketGame.Core.Helpers
{
    public static class ConcurrentRandom
    {
        private static Random random = new Random(Environment.TickCount);

        public static int Generate(int min, int max)
        {
            lock (random)
            {
                return random.Next(min, max);
            }
        }
    }
}