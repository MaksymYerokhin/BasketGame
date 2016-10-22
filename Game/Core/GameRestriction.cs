namespace BasketGame.Core
{
    public class GameRestriction
    {
        public int Min { get; private set; }
        public int Max { get; private set; }

        public GameRestriction(int min, int max) {
            this.Min = min;
            this.Max = max;
        }
    }
}
