using System;

namespace BasketGame.Core.Game
{
    /// <summary>
    /// Forms game data in string representation
    /// </summary>
    public class GameAnnouncer : IGameAnnouncer
    {
        private readonly Basket _basket;

        public GameAnnouncer(Basket basket) {
            _basket = basket;
        }

        public string AnnounceFinalData(GameState state)
        {
            var hasWinner = state.Winner != null;
            var result = hasWinner
                ? $"The winner: {state.Winner.Name}.\nTotal attempts number: {state.AttemptsNumber}"
                : $"The closest to victory was: {state.ClosestPlayer.Name}\nBest guess: {state.ClosestGuess.ToString()}";

            return result;
        }

        public string AnnounceInitialData()
        {
            return $"The real weight of basket: {_basket.Weight.ToString()}\n";
        }
    }
}
