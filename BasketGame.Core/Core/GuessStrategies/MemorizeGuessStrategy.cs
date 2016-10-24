using BasketGame.Core.Helpers;
using System.Collections.Generic;
using System.Linq;
using BasketGame.Core.Players;
using BasketGame.Core.Game;
using System.Threading;

namespace BasketGame.Core.GuessStrategies
{
    /// <summary>
    /// Does not guess any previously picked numbers.
    /// Initially forms a range of possible numbers,
    /// then removes each picked number from the list
    /// of available.
    /// Works both for Memory player and Cheater player.
    /// For Memory player it handles only own guesses,
    /// cheater is subscribed also for other players guesses.
    /// </summary>
    public class MemorizeGuessStrategy : GenericGuessStrategy, ICheaterStrategy
    {
        protected readonly List<int> _numbersToGuess;

        public MemorizeGuessStrategy(GameRestriction res) : base(res)
        {
            _numbersToGuess = Enumerable.Range(_min, _max - _min + 1).ToList();
        }

        /// <summary>
        /// Choose random index in the list of available numbers
        /// and pick the number placed by this index.
        /// </summary>
        /// <returns>Guessed number</returns>
        public override int GuessNumber()
        {
            var randomIndex = ConcurrentRandom.Generate(0, _numbersToGuess.Count - 1);
            return _numbersToGuess[randomIndex];
        }

        /// <summary>
        /// Handles guess events
        /// </summary>
        /// <param name="sender">Object which emitted the event</param>
        /// <param name="args">Event arguments</param>
        public void OnNumberGuessedHandler(object sender, PlayerGuessEventArgs args)
        {
            lock (_numbersToGuess)
            {                
                _numbersToGuess.Remove(args.GuessedNumber);
            }
        }
    }
}