using BasketGame.Core.GuessStrategies;

namespace BasketGame.Core.Players
{
    public class CheaterPlayer : GenericCheaterPlayer, IFink
    {
        public CheaterPlayer(string name, MemorizeGuessStrategy r) : base(name, r)
        {
        }
    }
}