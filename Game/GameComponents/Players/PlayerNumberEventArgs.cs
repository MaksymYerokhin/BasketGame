using System;

namespace BasketGame.Core.Players
{
    public class PlayerNumberEventArgs : EventArgs
    {
        public int GuessedNumber { get; private set; }

        public string PlayerName { get; private set; }

        public PlayerNumberEventArgs(int guessedNumber, string name)
        {
            GuessedNumber = guessedNumber;
            PlayerName = name;
        }
    }
}
