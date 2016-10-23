using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketGame.Core.Game
{
    public interface IGameAnnouncer
    {
        string AnnounceInitialData();

        string AnnounceFinalData(GameState state);
    }
}
