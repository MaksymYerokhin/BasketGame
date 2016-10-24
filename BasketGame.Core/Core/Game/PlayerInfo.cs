namespace BasketGame.Core.Game
{
    /// <summary>
    /// Initial player data, represents input
    /// </summary>
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