using BasketGame.Core.GuessStrategies;

namespace BasketGame.Core.Players
{
    public class CheaterPlayer : GenericCheaterPlayer
    {
        public CheaterPlayer(string name, MemorizeGuessStrategy r) : base(name, r)
        {
        }
    }
}