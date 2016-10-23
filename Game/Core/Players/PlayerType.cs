using System;

namespace BasketGame.Core.Players
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
}
