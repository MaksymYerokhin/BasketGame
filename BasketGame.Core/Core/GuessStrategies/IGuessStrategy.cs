namespace BasketGame.Core.GuessStrategies
{
    public interface IGuessStrategy
    {
        bool canGuess { get; set; }

        int GuessNumber();
    }
}