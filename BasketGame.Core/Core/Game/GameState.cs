using BasketGame.Core.GuessStrategies;
using BasketGame.Core.Players;

namespace BasketGame.Core.Game
{
    /// <summary>
    /// Represents current state of the game
    /// </summary>
    public class GameState
    {
        public int AttemptsNumber;

        public GenericPlayer<IGuessStrategy> Winner;

        public GenericPlayer<IGuessStrategy> ClosestPlayer;

        public int ClosestGuess;

        public override string ToString()
        {
            var hasWinner = Winner != null;
            var result = hasWinner
                ? $"The winner: {Winner.Name}.\nTotal attempts number: {AttemptsNumber}."
                : $"The closest to victory was: {ClosestPlayer.Name}.\nBest guess: {ClosestGuess}.";

            return result;
        }
    }
}