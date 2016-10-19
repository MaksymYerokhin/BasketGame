using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.GameComponents.Players
{
    public class CheaterPlayer : RandomPlayer
    {
        private List<GeneralPlayer> others;

        public CheaterPlayer(string name) : base(name)
        {
        }


    }
}