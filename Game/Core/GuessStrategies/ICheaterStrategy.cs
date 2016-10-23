using BasketGame.Core.Players;

namespace BasketGame.Core.GuessStrategies
{
    public interface ICheaterStrategy : IGuessStrategy
    {
        void OnNumberGuessedHandler(object sender, PlayerGuessEventArgs args);
    }
}
