using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.GameComponents
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
