using BasketGame.Core.Players;

namespace BasketGame.Core
{
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