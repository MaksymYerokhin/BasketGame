using System;

namespace BasketGame.Core.Players
{
    /// <summary>
    /// Data passed by guess event
    /// </summary>
    public class PlayerGuessEventArgs : EventArgs
    {
        public readonly int GuessedNumber;

        public readonly string PlayerName;

        public PlayerGuessEventArgs(int guessedNumber, string name)
        {
            GuessedNumber = guessedNumber;
            PlayerName = name;
        }
    }
}
