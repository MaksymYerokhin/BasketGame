using System;

namespace BasketGame.Core
{
    [Flags]
    public enum PlayerType
    {
        Thorough = 1 << 0,
        Memory = 1 << 1,
        Random = 1 << 2,
        Cheater = 1 << 3,
        ThoroughCheater = Thorough | Cheater
    }

    public class Input
    {
        public string Name { get; private set; }
        public PlayerType PlayerType { get; private set; }

        public Input(string name, PlayerType type)
        {
            Name = name;
            PlayerType = type;
        }
    }
}
