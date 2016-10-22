using BasketGame.Core.GuessStrategies;

namespace BasketGame.Core.Players
{
    public class ThoroughPlayer : GenericPlayer<IGuessStrategy>
    {
        public ThoroughPlayer(string name, ThoroughGuessStrategy q) : base(name, q)
        {
        }
    }
}