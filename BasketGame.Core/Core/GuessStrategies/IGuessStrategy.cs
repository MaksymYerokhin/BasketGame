namespace BasketGame.Core.GuessStrategies
{
    public interface IGuessStrategy
    {
        bool CanGuess { get; set; }

        int GuessNumber();
    }
}