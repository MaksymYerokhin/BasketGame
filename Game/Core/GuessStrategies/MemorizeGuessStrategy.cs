using BasketGame.Core.Helpers;
using System.Collections.Generic;
using System.Linq;
using BasketGame.Core.Players;
using BasketGame.Core.Game;
using System.Threading;

namespace BasketGame.Core.GuessStrategies
{
    public class MemorizeGuessStrategy : GenericGuessStrategy, ICheaterStrategy
    {
        protected readonly List<int> _numbersToGuess;

        public MemorizeGuessStrategy(GameRestriction res) : base(res)
        {
            _numbersToGuess = Enumerable.Range(_min, _max - _min).ToList();
        }

        public override int GuessNumber()
        {
            //int guessedNumber;
            //if (_numbersToGuess.Count == 0)
            //{
            //    canGuess = false;
            //}
            //else
            //{
            //    guessedNumber = _numbersToGuess[ConcurrentRandom.Generate(0, _numbersToGuess.Count - 1)];
            //}
            var randomIndex = ConcurrentRandom.Generate(0, _numbersToGuess.Count - 1);
            return _numbersToGuess[randomIndex];
        }

        public void OnNumberGuessedHandler(object sender, PlayerGuessEventArgs args)
        {
            lock (_numbersToGuess)
            {
                //System.Console.Write(System.String.Format("Count: {0}; {1}\n", _numbersToGuess.Count.ToString(), args.GuessedNumber.ToString()));
                //for (int i = 0; i < _numbersToGuess.Count; i++)
                //{
                //    System.Console.Write(_numbersToGuess[i].ToString());
                //    System.Console.Write("  ");
                //}
                //System.Console.Write("\n");
                _numbersToGuess.Remove(args.GuessedNumber);
            }
        }
    }
}