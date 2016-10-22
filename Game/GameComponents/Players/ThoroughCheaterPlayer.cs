using BasketGame.Core.GuessStrategies;

namespace BasketGame.Core.Players
{
    public class ThoroughCheaterPlayer : CheaterPlayer
    {
        public ThoroughCheaterPlayer(string name, ThoroughMemorizeGuessStrategy s) : base(name, s)
        {
        }
    }
}