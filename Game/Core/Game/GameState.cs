using BasketGame.Core.GuessStrategies;
using BasketGame.Core.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketGame.Core.Game
{
    public class GameState
    {
        public int AttemptsNumber;

        public bool Initialized;

        public bool Finished;

        public GenericPlayer<IGuessStrategy> Winner;

        public GenericPlayer<IGuessStrategy> ClosestPlayer;

        public int ClosestGuess;
    }
}
