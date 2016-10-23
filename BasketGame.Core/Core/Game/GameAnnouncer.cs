using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketGame.Core.Game
{
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
                ? String.Format("The winner: {0}.\nTotal attempts number: {1}", state.Winner.Name, state.AttemptsNumber)
                : String.Format("The closest to victory was: {0}\nBest guess: {1}", state.ClosestPlayer.Name, state.ClosestGuess.ToString());

            return result;
        }

        public string AnnounceInitialData()
        {
            return String.Format("The real weight of basket: {0}\n", _basket.Weight.ToString());
        }
    }
}
