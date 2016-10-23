using BasketGame.Core.Players;

namespace BasketGame.Core
{
    public class PlayerInfo
    {
        public readonly string Name;

        public readonly PlayerType PlayerType;

        public PlayerInfo(string name, PlayerType type)
        {
            Name = name;
            PlayerType = type;
        }
    }
}