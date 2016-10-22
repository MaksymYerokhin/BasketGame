using BasketGame.Core.Players;

namespace BasketGame.Core.GuessStrategies
{
    public interface ICheaterStrategy
    {
        void OnNumberGuessedHandler(object sender, PlayerNumberEventArgs args);
    }
}
