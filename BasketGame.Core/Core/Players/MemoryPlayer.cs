using BasketGame.Core.GuessStrategies;

namespace BasketGame.Core.Players
{
    public class MemoryPlayer : GenericPlayer<IGuessStrategy>
    {
        public MemoryPlayer(string name, MemorizeGuessStrategy r) : base(name, r)
        {
            OnNumberGuessed += r.OnNumberGuessedHandler;
        }
    }
}