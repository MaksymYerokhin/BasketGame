using BasketGame.Core.GuessStrategies;

namespace BasketGame.Core.Players
{
    public class RandomPlayer : GenericPlayer<IGuessStrategy>
    {
        public RandomPlayer(string name, RandomGuessStrategy q) : base(name, q)
        {
        }
    }
}