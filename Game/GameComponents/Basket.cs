namespace Game.GameComponents
{
    class Basket
    {
        public int Weight { get; private set; }

        public Basket(int min, int max)
        {
            Weight = ConcurrentRandom.Generate(min, max);
        }
    }
}