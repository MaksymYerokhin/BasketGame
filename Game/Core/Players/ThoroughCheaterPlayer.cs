using BasketGame.Core.GuessStrategies;

namespace BasketGame.Core.Players
{
    public class ThoroughCheaterPlayer : GenericCheaterPlayer
    {
        public ThoroughCheaterPlayer(string name, ThoroughMemorizeGuessStrategy s) : base(name, s)
        {
        }
    }
}