using System;

namespace BasketGame.Core.Helpers
{
    /// <summary>
    /// Provides reliable random which can be used from different threads
    /// </summary>
    public static class ConcurrentRandom
    {
        private static readonly Random _random = new Random(Environment.TickCount);

        public static int Generate(int min, int max)
        {
            lock (_random)
            {
                return _random.Next(min, max);
            }
        }
    }
}