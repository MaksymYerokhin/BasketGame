using Game.GameComponents.GuessStrategies;

namespace Game.GameComponents.Players
{
    public class ThoroughPlayer : GenericPlayer<IGuessStrategy>
    {
        public ThoroughPlayer(string name, ThoroughGuessStrategy q) : base(name, q)
        {
        }
    }
}