using Game.GameComponents.GuessStrategies;

namespace Game.GameComponents.Players
{
    public class RandomPlayer : GenericPlayer<IGuessStrategy>
    {
        public RandomPlayer(string name, RandomGuessStrategy q) : base(name, q)
        {
        }
    }
}