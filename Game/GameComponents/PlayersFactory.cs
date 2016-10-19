using Game.GameComponents.Players;
using System;

namespace Game.GameComponents
{
    public static class PlayersFactory
    {
        public static GeneralPlayer GetPlayer(string name, PlayerType type)
        {
            switch (type)
            {
                case PlayerType.Cheater:
                    return new CheaterPlayer(name);
                case PlayerType.Memory:
                    return new MemoryPlayer(name);
                case PlayerType.Random:
                    return new RandomPlayer(name);
                case PlayerType.Thorough:
                    return new ThoroughPlayer(name);
                case PlayerType.ThoroughCheater:
                    return new ThoroughCheaterPlayer(name);
                default:
                    throw new ArgumentException("Invalid type");
            }
        }
    }
}
