namespace BasketGame.Core.Game
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