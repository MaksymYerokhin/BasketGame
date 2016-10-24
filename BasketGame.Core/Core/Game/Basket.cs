using BasketGame.Core.Helpers;

namespace BasketGame.Core.Game
{
    /// <summary>
    /// Represents the object of basket
    /// </summary>
    public class Basket
    {
        public readonly int Weight;

        public Basket(int min, int max)
        {
            Weight = ConcurrentRandom.Generate(min, max);
        }
    }
}