using BasketGame.Core.GuessStrategies;
using BasketGame.Core.Players;

namespace BasketGame.Core.Game
{
    public class GameState
    {
        public int AttemptsNumber;

        public bool Initialized;

        public bool Finished;

        public GenericPlayer<IGuessStrategy> Winner;

        public GenericPlayer<IGuessStrategy> ClosestPlayer;

        public int ClosestGuess;
    }
}
